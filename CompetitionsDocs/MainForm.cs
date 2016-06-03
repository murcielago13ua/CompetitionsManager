using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace CompetitionsManager
{
    public partial class MainForm : Form
    {        
        private Stack<IFormPage> pages = new Stack<IFormPage>();
        private static MainForm instance = null;
        public static MainForm Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainForm();
                return instance;
            }
        }
        private Thread word_thread = null, start_prot_thread = null, excel_res_thread = null;
        private Competitions competitions;
        private CompetitionsPage compPage;
        private DistancePage distPage;
        private TeamPage teamPage;
        private DistResultsPage distResPage = null;
        private SQLiteConnection conn;
        private MainForm()
        {
            InitializeComponent();
            if (!File.Exists("base.db"))
                CreateTables();
            this.conn = new SQLiteConnection("Data source = base.db");             
            LoadAllDistances();
            CreatePages();
            LoadCompetitions();
            EnableMainMenuButtons();
        }

        private void EnableMainMenuButtons()
        {
            if (this.compPage.getFullFreeDistances().Count == 0)
            {
                this.editDistMBtn.Enabled = false;
                this.delDistMBtn.Enabled = false;
            }
            this.fileMenuItem.Enabled = false;
            this.createDistConditionsMBtn.Enabled = false;
            this.createStartProtMBtn.Enabled = false;
            this.createDistResMBtn.Enabled = false;
            this.teamMenuItem.Enabled = false;
            this.addDistMBtn.Enabled = false;
            this.addDistMBtn.Enabled = false;
            this.backMBtn.Enabled = false;
            if (Competitions.Items.Count == 0) this.runCompMenuBtn.Enabled = false;
        }

        private  void CreateTables()
        {
            SQLiteConnection.CreateFile("base.db");
            this.conn = new SQLiteConnection("Data source = base.db");
            conn.Open();
            SQLiteCommand command = new SQLiteCommand(conn);
            command.CommandText = @"CREATE TABLE distances([id] CHAR, [name] CHAR, [type] CHAR,[is_short] CHAR, [difficult] CHAR, [len] TINYINT, [height] TINYINT, [teammates] TINYINT, [penalty_price] INT);";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE stages([id] CHAR, [name] CHAR,[len] TINYINT, [difficult] CHAR,[dist_id] CHAR);";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE user_stages([name] CHAR, [difficult] DOUBLE)";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE competitions([id] CHAR, [name] CHAR, [date] CHAR)";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE competitions_to_dist_relations([comp_id] CHAR, [dist_id] CHAR);";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE turistos([id] CHAR, [name] CHAR, [birth_day] CHAR, [qualification] CHAR, [cat_id] CHAR);";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE category([id] CHAR, [name] CHAR, [parent_id] CHAR);";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE teams([id] CHAR, [name] CHAR, [couch] CHAR, [comp_id] CHAR);";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE team_relations([team_id] CHAR, [turisto_id] CHAR);";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE stage_result([id] CHAR, [stage_id] CHAR, [time] CHAR, [penalties] TINYINT, [comment] TEXT, [participation_id] CHAR );";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE participations([id] CHAR,[dist_pens] INT, [dist_id] CHAR, [team_id] CHAR);";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE participation_relations([participation_id] CHAR, [turisto_id] CHAR);";
            command.ExecuteNonQuery();
            conn.Close();
        }

        private void CreatePages()
        {
            this.compPage = new CompetitionsPage(this.competitionsPanel, this.compDatePicker);
            this.teamPage = new TeamPage(this.teamPanel, this.catTreeView);
            this.distPage = new DistancePage(this.distancePanel);
            this.distTypeLstBox.DataSource = DistancePage.distTypes;
            toolTip.SetToolTip(distStagesLstBox, "Змінювати порядок етапів можна за допомогою клавіш 'W','S'");
            this.stageTemplLBox.DataSource = this.distPage.templ_stages.ToList();
        }

        private void LoadCompetitions()
        {
            var com = new SQLiteCommand(this.conn);
            conn.Open();
            com.CommandText = @"SELECT * FROM competitions;";
            var comp_reader = com.ExecuteReader();
            foreach (DbDataRecord comp_record in comp_reader)
            {
                Guid comp_id = Guid.Parse(comp_record["id"].ToString());
                string name = comp_record["name"].ToString();
                DateTime date = DateTime.Parse(comp_record["date"].ToString());
                var competitions = new Competitions(name, date, comp_id);
                LoadCompDistances(competitions);
            }
            comp_reader.Close();
            conn.Close();
        }

        private void LoadCompDistances(Competitions comp)
        {
            var com = new SQLiteCommand(this.conn);
            com.CommandText = string.Format(@"SELECT * FROM competitions_to_dist_relations WHERE comp_id='{0}';", comp.Id.ToString());
            var relation_reader = com.ExecuteReader();
            foreach (DbDataRecord relation_rec in relation_reader)
            {
                Guid dist_id = Guid.Parse(relation_rec["dist_id"].ToString());
                comp.AddDistance(Distance.Items[dist_id]);
            }
            relation_reader.Close();
        }

        private void LoadAllDistances()
        {
            conn.Open();
            var com = new SQLiteCommand(conn);
            com.CommandText = @"SELECT * FROM distances;";
            var dist_reader = com.ExecuteReader();
            foreach (DbDataRecord dist_rec in dist_reader)
            {
                Guid dist_id = Guid.Parse(dist_rec["id"].ToString());
                string name = dist_rec["name"].ToString();
                string type = dist_rec["type"].ToString();
                bool _is_short = bool.Parse(dist_rec["is_short"].ToString());
                double diff = double.Parse(dist_rec["difficult"].ToString());
                int len = int.Parse(dist_rec["len"].ToString());
                short height = short.Parse(dist_rec["height"].ToString());
                short teammates_count = short.Parse(dist_rec["teammates"].ToString());
                int penalty_price = int.Parse(dist_rec["penalty_price"].ToString());
                var dist = new Distance(name, type, LoadDistStages(dist_id), teammates_count, dist_id);
                dist.Lenght = len;
                dist.Height = height;
                dist.IsShortDistance = _is_short;
            }
            dist_reader.Close();
            conn.Close();
        }

        private List<Stage> LoadDistStages(Guid dist_id)
        {
            var stages = new List<Stage>();
            var com = new SQLiteCommand(conn);
            com.CommandText = string.Format(@"SELECT * FROM stages WHERE dist_id='{0}';", dist_id.ToString());
            var stage_reader = com.ExecuteReader();
            foreach (DbDataRecord stage_rec in stage_reader)
            {
                Guid stage_id = Guid.Parse(stage_rec["id"].ToString());
                string name = stage_rec["name"].ToString();
                short len = short.Parse(stage_rec["len"].ToString());
                double diff = double.Parse(stage_rec["difficult"].ToString());
                var stage = new Stage(name, len, diff, stage_id);
                stage.Dist_id = dist_id;
                stages.Add(stage);
            }
            return stages;
        }       

        private void createDistMenuItem_Click(object sender, EventArgs e)
        {            
            this.distPage.DistanceCreatingMode();
            this.pages.Push(this.distPage);
            this.backMBtn.Enabled = true;
            this.distPage.Open();
            this.distMenuItem.Enabled = false;
        }        

        private void editDistMBtn_Click(object sender, EventArgs e)
        {
            var openDistDialog = new OpenDistanceDialog(this.compPage.getFullFreeDistances());
            if (openDistDialog.ShowDialog() == DialogResult.Cancel) return;
            var distance = openDistDialog.distance;
            this.distPage.DistanceEditMode(distance);
            this.pages.Push(this.distPage);
            this.distNameTBox.Text = distance.Name;
            this.distTypeLstBox.SelectedItem = distance.Type;
            this.distLenTBox.Text = distance.Lenght.ToString();
            this.distHeightTBox.Text = distHeightTBox.Height.ToString();
            this.penPriceTBox.Text = distance.PenaltyPrice.ToString();
            this.tmCountNum.Value = distance.TeammatesCount;
            this.distStagesLstBox.DataSource = this.distPage.Stages.ToList();
            this.distPage.Open();
        }

        private void addDistMBtn_Click(object sender, EventArgs e)
        {
            var free_distances = this.compPage.getFreeDistances(this.competitions);
            var distanceDialogForm = new OpenDistanceDialog(free_distances);
            if (distanceDialogForm.ShowDialog() == DialogResult.OK)
            {
                var selected = distanceDialogForm.distance;
                this.compPage.AddDistanceToComp(selected);
                RefreshCompDistsListBox();
                MessageBox.Show("Дистанція додана!");
                if(this.competitions.Distances.Count() == Distance.Items.Count)
                {
                    this.addDistMBtn.Enabled = false;
                    this.editDistMBtn.Enabled = false;
                    this.delDistMBtn.Enabled = false;
                }
                this.showResBtn.Enabled = true;
                this.createDistConditionsMBtn.Enabled = true;
                this.fileMenuItem.Enabled = true;
            }
        }

        private void removeDistFromCompMBtn_Click(object sender, EventArgs e)
        {
            if (compDistsListBox.SelectedItem != null)
            {
                DialogResult dial = MessageBox.Show("Підтвердження", "Вилучити обрану дистанцію?",
                    MessageBoxButtons.YesNo);
                if (dial == DialogResult.Yes)
                {
                    this.compPage.RemoveDistFromComp(compDistsListBox.SelectedItem as Distance);
                    MessageBox.Show("Дистанцію вилучено!");
                    RefreshCompDistsListBox();
                    this.addDistMBtn.Enabled = true;
                    this.editDistMBtn.Enabled = true;
                    if(this.competitions.Distances.Count() == 0)
                    {
                        this.showResBtn.Enabled = false;
                        this.fileMenuItem.Enabled = false;
                        this.createDistConditionsMBtn.Enabled = false;
                    }
                }
            }
        }

        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void runCompMenuBtn_Click(object sender, EventArgs e)
        {
            var compDialogForm = new OpenCompDialog();
            var compDialog = compDialogForm.ShowDialog(this);
            if (compDialog == DialogResult.OK)
                RunCompetitions(compDialogForm.competition);
        }
        private void RunCompetitions(Competitions comp)
        {
            while (this.pages.Count > 0)
            {
                var last_page = this.pages.Pop();
                last_page.Close();
            }
            this.competitions = comp;            
            this.compPage.Competitions = this.competitions;
            this.compPage.Open();
            pages.Push(this.compPage);
            this.compTeamsListBox.DataSource = this.competitions.Teams.ToList();
            this.compDistsListBox.DataSource = this.competitions.Distances.ToList();
            this.backMBtn.Enabled = true;
            this.compNameLabel.Text = this.competitions.Name;
            EnableCompMButtons();
        }

        private void EnableCompMButtons()
        {
            this.teamMenuItem.Enabled = true;
            if (this.competitions.Distances.Count() == 0)
                this.showResBtn.Enabled = false;
            else
            {
                this.fileMenuItem.Enabled = true;
                this.createDistConditionsMBtn.Enabled = true;
            }
            if (this.competitions.Distances.Count() == Distance.Items.Count)
            {
                this.addDistMBtn.Enabled = false;
                this.editDistMBtn.Enabled = false;
                this.delDistMBtn.Enabled = false;
            }
            else if(Distance.Items.Count > 0)
            {
                this.addDistMBtn.Enabled = true;
                this.editDistMBtn.Enabled = true;
                this.delDistMBtn.Enabled = true;
            }
            
        }

        private void createCompMBtn_Click(object sender, EventArgs e)
        {
            var compCreationForm = new CompCreationForm();
            if(compCreationForm.ShowDialog() == DialogResult.OK)
                RunCompetitions(compCreationForm.competitions);            
        }        

        private void addTeammateBtn_Click(object sender, EventArgs e)
        {
            if (turistosLBox.SelectedItems.Count > 0)
            {
                foreach (Sportsman turisto in turistosLBox.SelectedItems)
                    this.teamPage.AddTeammate(turisto);
                this.RefreshTeammatesListBox();
                RefreshTuristosListBox();
            }
        }

        private void RefreshTeammatesListBox()
        {
            this.teammatesLBox.DataSource = null;
            this.teammatesLBox.DataSource = this.teamPage.Turistos_in_team.ToList();
        }

        private void RefreshTuristosListBox()
        {
            var selectedNode = catTreeView.SelectedNode;
            if (selectedNode == null)
            {
                turistosLBox.DataSource = null;
                return;
            }
            var category = this.teamPage.GetCategoryByNode(selectedNode);
            var temp_list = new List<Sportsman>();
            foreach (var turisto in category.Sportsmans)
                if (!this.teamPage.Turistos_in_team.Contains(turisto))
                    temp_list.Add(turisto);
            this.turistosLBox.DataSource = null;
            this.turistosLBox.DataSource = temp_list;
        }

        private void RefreshCompTeamsListBox()
        {
            this.compTeamsListBox.DataSource = this.competitions.Teams.ToList();
        }

        private void RefreshCompDistsListBox()
        {
            this.compDistsListBox.DataSource = this.competitions.Distances.ToList();
        }

        private void addSubcatMBtn_Click(object sender, EventArgs e)
        {
            if (catTreeView.SelectedNode != null)
            {
                this.teamPage.AddSubCat();
            }
        }

        private void renameCatMBtn_Click(object sender, EventArgs e)
        {
            this.teamPage.RenameCat();
        }        

        private void delCatMBtn_Click(object sender, EventArgs e)
        {
            this.teamPage.DeleteCat();
        }        

        private void addSpMenuItem_Click(object sender, EventArgs e)
        {
            this.teamPage.AddSportsman();
            RefreshTuristosListBox();
        }       

        private void transferToOtherCatMBtn_Click(object sender, EventArgs e)
        {
            Sportsman selected = turistosLBox.SelectedItem as Sportsman;
            if (selected == null) return;
            new CatChangingForm(selected).ShowDialog();
            RefreshTuristosListBox();
        }

        private void remTeammateMBtn_Click(object sender, EventArgs e)
        {
            this.teamPage.RemoveTeammate(teammatesLBox.SelectedItem as Sportsman);            
            RefreshTeammatesListBox();
        }

        private void editTeammateMBtn_Click(object sender, EventArgs e)
        {
            this.teamPage.EditSportsman(teammatesLBox.SelectedItem as Sportsman);
            RefreshTeammatesListBox();
        }

        private void createTeamMenuBtn_Click(object sender, EventArgs e)
        {
            this.teamPage.TeamCreatingMode(this.competitions);
            pages.Push(this.teamPage);
            this.teamPage.Open();
            categoryMenu.Enabled = true;
        }

        private void teamPanelOkBtn_Click(object sender, EventArgs e)
        {
            if (this.teamNameTBox.Text != "" && this.teamCouchTbox.Text != "")
            {
                this.teamPage.EndTeamEditing(this.teamNameTBox.Text, this.teamCouchTbox.Text);
                this.teamPage.Close();
                this.pages.Pop();
                RefreshCompTeamsListBox();
            }
            else
                MessageBox.Show("Введіть усі текстові поля!");
        }       

        private void teamPanelCancelBtn_Click(object sender, EventArgs e)
        {
            this.teamPage.CancelTeamEditing();
            this.teamPage.Close();
            this.pages.Pop();
        }

        private void backMBtn_Click(object sender, EventArgs e)
        {
            if (pages.Count > 0)
            {
                var dialRes = MessageBox.Show("Закрити?", "", MessageBoxButtons.YesNo);
                if (dialRes == DialogResult.Yes)
                {
                    var last_page = pages.Pop();
                    last_page.Close();
                    if (pages.Count == 0) this.backMBtn.Enabled = false;
                }
            }
        }       

        private void catTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshTuristosListBox();
        }

        private void catTreeView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = catTreeView.GetNodeAt(e.Location);
                if (node == null) return;
                if (node.Nodes.Count > 0)  this.addSpMenuItem.Enabled = false;
                else this.addSpMenuItem.Enabled = true;
                if (teamPage.GetCategoryByNode(node).Sportsmans.Count() == 0) this.addSubcatMBtn.Enabled = true;
                else this.addSubcatMBtn.Enabled = false;
                catTreeView.SelectedNode = node;
                categoryMenu.Show(this.catTreeView, e.Location, ToolStripDropDownDirection.Right);
                
            }
        }

        private void turistosLBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = this.turistosLBox.IndexFromPoint(e.Location);
                if (index == -1) return;
                this.turistosLBox.SelectedItems.Clear();
                this.turistosLBox.SetSelected(index, true);
                sportsmanMenu.Show(this.turistosLBox, e.Location, ToolStripDropDownDirection.Right);
            }
        }                             

        private void compTeamsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = this.compTeamsListBox.IndexFromPoint(e.Location);
                if (index == -1) return;
                this.compTeamsListBox.SetSelected(index, true);
                var team = this.compTeamsListBox.SelectedItem as Team;
                if (CanEditTeam(team)) this.editTeamMBtn.Enabled = true;
                else this.editTeamMBtn.Enabled = false;
                compTeamMenu.Show(this.compTeamsListBox, e.Location, ToolStripDropDownDirection.Right);
            }
        }

        private bool CanEditTeam(Team team)
        {
            foreach(var participation in Participation.Items.Values)
            {
                if (participation.Team.Equals(team))
                    return false;
            }
            return true;
        }

        private void editTeamMBtn_Click(object sender, EventArgs e)
        {
            var team = this.compTeamsListBox.SelectedItem as Team;
            if(this.Controls.Contains(this.teamPanel))
            {
                if (MessageBox.Show("Закрити поточну вкладку?", "Підтвердження", MessageBoxButtons.YesNo) ==
                    DialogResult.No)
                {
                    return;
                }
                else
                    this.teamPage.Close();
            }
            this.teamPage.TeamEditingMode(team, this.competitions);
            this.teamNameTBox.Text = team.Name;
            this.teamCouchTbox.Text = team.CoachName;
            this.teamPage.Open();
            this.pages.Push(this.teamPage);
            RefreshTeammatesListBox();
        }     

        private void teammatesLBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int index = this.teammatesLBox.IndexFromPoint(e.Location);
                if (index == -1) return;
                this.teammatesLBox.SetSelected(index, true);
                this.squadeMenu.Show(this.teammatesLBox, e.Location, ToolStripDropDownDirection.Right);
            }
        }

        private void editSportsmanMBtn_Click(object sender, EventArgs e)
        {
            this.teamPage.EditSportsman(this.turistosLBox.SelectedItem as Sportsman);
            RefreshTuristosListBox();
        }        

        private void delSportsmanMBtn_Click(object sender, EventArgs e)
        {
            this.teamPage.DeleteSportsman(turistosLBox.SelectedItem as Sportsman);
            RefreshTuristosListBox();
        }        

        private void delTeamMBtn_Click(object sender, EventArgs e)
        {
            if (this.compPage.DeleteTeam(compTeamsListBox.SelectedItem as Team))
                RefreshCompTeamsListBox();
        }       

        private void compDistsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int index = compDistsListBox.IndexFromPoint(e.Location);
                if (index == -1) return;
                compDistsListBox.SetSelected(index, true);
                var selected = compDistsListBox.SelectedItem as Distance;
                compDistsMenu.Show(compDistsListBox, e.Location, ToolStripDropDownDirection.Right);
            }
        }

        private void showResBtn_Click(object sender, EventArgs e)
        {
            var distance = this.compDistsListBox.SelectedItem as Distance;
            if (distance == null) return;
            if (this.distResPage == null)
                this.distResPage = new DistResultsPage(this.distResPanel, this.competitions, distance);
            else
                this.distResPage.SetDistance(this.competitions, distance);
            this.participsListBox.DataSource = this.distResPage.Participations;            
            this.distResPanelMainLabel.Text = string.Format("Комадни на дистанції '{0}'", distance.Name);
            if (this.distResPage.Participations.Count > 0)
            {
                resTBox.Text = this.distResPage.Participations.First().FullTime.ToString(@"hh\:mm\:ss");
                this.addTeamToDistanceBtn.Enabled = true;
                this.distResPanelSortTeamBtn.Enabled = true;
                this.viewTeamResBtn.Enabled = true;
                this.createStartProtMBtn.Enabled = true;
                this.createDistResMBtn.Enabled = true;
            }       
            else
            {
                this.distResPanelSortTeamBtn.Enabled = false;
                this.viewTeamResBtn.Enabled = false;
            }
            int teams_count = this.competitions.Teams.Count();
            if (teams_count == 0 || (teams_count == this.distResPage.Participations.Count))
                this.addTeamToDistanceBtn.Enabled = false;
            else
                this.addTeamToDistanceBtn.Enabled = true;
            this.fileMenuItem.Enabled = true;
            this.pages.Push(this.distResPage);
            this.distResPage.Open();
        }

        private void viewTeamResBtn_Click(object sender, EventArgs e)
        {
            var curr = participsListBox.SelectedItem as Participation;
            if (curr == null) return;
            this.distResPage.ShowTeamResult(curr); 
            this.resTBox.Text = curr.FullTime.ToString(@"hh\:mm\:ss");
        }

        private void addTeamToDistanceBtn_Click(object sender, EventArgs e)
        {
            this.distResPage.OpenTeamAddingForm();
            this.participsListBox.DataSource = null;
            this.participsListBox.DataSource = this.distResPage.Participations;
            if(this.distResPage.Participations.Count > 0)
            {
                this.createStartProtMBtn.Enabled = true;
                this.createDistResMBtn.Enabled = true;
                this.viewTeamResBtn.Enabled = true;
                this.distResPanelSortTeamBtn.Enabled = true;
            }
            if (this.distResPage.Participations.Count == this.competitions.Teams.Count())
                this.addTeamToDistanceBtn.Enabled = false;
        }

        private void distPanelAddStageBtn_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = this.stagePage;
        }

        private void RefreshTemplStLBox()
        {
            this.stageTemplLBox.DataSource = this.distPage.templ_stages.ToList();
        }

        private void distPanelCreateUniqueStBtn_Click(object sender, EventArgs e)
        {
            var unStageEditForm = new UniqueStageEditForm();
            if (unStageEditForm.ShowDialog() == DialogResult.OK)
            {
                this.distPage.templ_stages.Add(unStageEditForm.stage);
                this.distPage.SaveUserStageInBase(unStageEditForm.stage);
            }
            RefreshTemplStLBox();
        }

        private void distPanelDelUserStBtn_Click(object sender, EventArgs e)
        {
            Stage toDel = (Stage)this.stageTemplLBox.SelectedItem;
            this.distPage.RemoveUserStageFromBase(toDel);
            this.distPage.templ_stages.Remove(toDel);
            Stage.Items.Remove(toDel.Id);
            RefreshTemplStLBox();
            MessageBox.Show("Етап видалено!");
        }

        private void distPanelChoseStageBtn_Click(object sender, EventArgs e)
        {
            Stage toAdd = Stage.Copy(this.stageTemplLBox.SelectedItem as Stage);
            if (Stage.IsSimple(toAdd))
            {
                try
                {
                    if (toAdd.Name.Equals("Рух по жердинах"))
                    {
                        if (!this.distPage.ParseJ(toAdd, this.stageLenTBox.Text)) return;
                    }
                    else if (toAdd.Name.Equals("Переправа на плавзасобах")) this.distPage.ParsePlavZas(toAdd);
                    else if (toAdd.Name.Equals("Рух по купинах")) this.distPage.ParseKupini(toAdd);
                    else
                    {
                        toAdd.Lenght = (short)(this.stageLenTBox.Enabled ? short.Parse(this.stageLenTBox.Text) : 1);
                        if (toAdd.Lenght <= 0 && this.stageLenTBox.Enabled)
                            throw new OverflowException();
                        if (new StageParamsForm(toAdd).ShowDialog() == DialogResult.Cancel) return;
                    }
                    if (toAdd.Points == 0)
                        MessageBox.Show("Даний етап не відповідає рекомендаціям з правил,\nтому не можливо визначити його бальну оцінку.\nЕтап не вплине на складність дистанції");
                    this.distPage.Stages.Add(toAdd);
                }
                catch (FormatException)
                {
                    MessageBox.Show("У полі \"Довжина етапу\"\nnотрібно вводити додатнє число!");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Надто велика/мала довжина етапу!");
                }

            }
            else
            {
                if (Stage.IsSpec(toAdd)) this.distPage.ParseSpecSt(toAdd);
                distPage.Stages.Add(toAdd);
            }
            RefreshDistStagesLBox();
        }

        private void distPanelCancelBtn_Click(object sender, EventArgs e)
        {
            if (this.distPage.EditMode)
                this.distPage.CancelDistanceEditing();
            this.distPage.Close();
            this.pages.Pop();
        }

        private void distPanelCreateDistanceBtn_Click(object sender, EventArgs e)
        {
            if (createDistanceAction() && !this.distPage.EditMode)
                AfterDistanceCreating();
        }

        private void AfterDistanceCreating()
        {
            if (this.competitions == null) return;
            var dialRes = MessageBox.Show("Додати дистанцію на змагання?", "Підтверження", MessageBoxButtons.YesNo);
            if (dialRes == DialogResult.Yes)
            {
                this.compPage.AddDistanceToComp(this.distPage.LastCreatedDistance);
                RefreshCompDistsListBox();
                MessageBox.Show("Дистанція додана!");
                if (this.competitions.Distances.Count() == Distance.Items.Count)
                {
                    this.addDistMBtn.Enabled = false;
                    this.editDistMBtn.Enabled = false;
                }
                this.createDistConditionsMBtn.Enabled = true;
            }
            this.addDistMBtn.Enabled = true;
            this.editDistMBtn.Enabled = true;
            this.delDistMBtn.Enabled = true;
        }

        private bool createDistanceAction()
        {
            if (distNameTBox.Text != "")
            {
                if (this.distPage.Stages.Count >= 1)
                {
                    try
                    {
                        string type = (string)distTypeLstBox.SelectedItem;
                        short tmCount = (short)this.tmCountNum.Value;
                        int penaltyPrice = int.Parse(penPriceTBox.Text);
                        int lenght = int.Parse(distLenTBox.Text);
                        int height = int.Parse(distHeightTBox.Text);
                        if (this.distPage.EndDistanceEditing(this.distNameTBox.Text, type,
                            tmCount, penaltyPrice, lenght, height))
                        {
                            this.distPage.Close();
                            this.pages.Pop();
                            return true;
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Некоректні числові дані!");
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("Надто багато учасників");
                    }
                }
                else
                    MessageBox.Show("Додайте етапи на дистанцію");
            }
            else
                MessageBox.Show("Введіть усі текстові поля!");
            return false;
        }

        private void stageTemplLBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stage selected = stageTemplLBox.SelectedItem as Stage;
            bool isSimple = Stage.IsSimple(selected), isSpec = Stage.IsSpec(selected);
            if (selected.Name.Equals("Рух по жердинах"))
            {
                this.lenLabel.Text = "Кількість прольотів";
                this.stageLenTBox.Enabled = true;
            }
            else if (isSpec|| selected.Name.Equals("Рух по купинах") || selected.Name.Equals("Переправа на плавзасобах"))
                this.stageLenTBox.Enabled = false;
            else if (isSimple)
            {
                this.lenLabel.Text = "Довжина етапу";
                this.stageLenTBox.Enabled = true;
            }
            else
                this.stageLenTBox.Enabled = false;
            if (isSimple || isSpec)
                this.distPanelDelUserStBtn.Enabled = false;
            else
                this.distPanelDelUserStBtn.Enabled = true;
        }

        private void RefreshDistStagesLBox()
        {
            this.distStagesLstBox.DataSource = this.distPage.Stages.ToList();
        }

        private void distStagesLstBox_KeyDown(object sender, KeyEventArgs e)
        {
            Stage selected = distStagesLstBox.SelectedItem as Stage;
            if (selected == null) return;
            if (e.KeyCode == Keys.W)
            {
                this.distPage.MoveUp(selected);
                RefreshDistStagesLBox();
                distStagesLstBox.SelectedItem = selected;
            }
            else if (e.KeyCode == Keys.S)
            {
                this.distPage.MoveDown(selected);
                RefreshDistStagesLBox();
                distStagesLstBox.SelectedItem = selected;
            }
        }       

        private void remStageMBtn_Click(object sender, EventArgs e)
        {
            this.distPage.Stages.Remove(distStagesLstBox.SelectedItem as Stage);
            RefreshDistStagesLBox();
        }

        private void distStagesLstBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int index = this.distStagesLstBox.IndexFromPoint(e.Location);
                if (index == -1) return;
                this.distStagesLstBox.SetSelected(index, true);
                this.distMenu.Show(this.distStagesLstBox, e.Location, ToolStripDropDownDirection.Right);
            }
        }

        private void MainForm_ControlAdded(object sender, ControlEventArgs e)
        {
            this.backMBtn.Enabled = true;
            if (e.Control == this.teamPanel)
                this.teamMenuItem.Enabled = false;
            else if (e.Control == this.distancePanel)
                this.distMenuItem.Enabled = false;     
        }

        private void MainForm_ControlRemoved(object sender, ControlEventArgs e)
        {
            var panel = e.Control;
            if (panel == competitionsPanel)
            {
                this.delCompMenuBtn.Enabled = false;
                this.fileMenuItem.Enabled = false;
                this.teamMenuItem.Enabled = false;
                this.addDistMBtn.Enabled = false;
                this.fileMenuItem.Enabled = false;
            }
            else if (panel == distResPanel)
            {
                this.createStartProtMBtn.Enabled = false;
                this.createDistResMBtn.Enabled = false;
                this.participsListBox.DataSource = null;
                this.resTBox.ResetText();
            }
            else if (panel == teamPanel)
            {
                this.teamNameTBox.ResetText();
                this.teamCouchTbox.ResetText();
                this.teammatesLBox.DataSource = null;
                this.turistosLBox.DataSource = null;
                this.teamMenuItem.Enabled = true;
            }
            else if (panel == distancePanel)
            {
                this.distNameTBox.ResetText();
                this.distLenTBox.ResetText();
                this.distHeightTBox.ResetText();
                this.penPriceTBox.ResetText();
                this.tmCountNum.Value = 1;
                this.distStagesLstBox.DataSource = null;
                this.distMenuItem.Enabled = true;
            }
            if (this.pages.Count == 0)
                this.backMBtn.Enabled = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            while (this.pages.Count > 0)
            {
                if (MessageBox.Show("Закрити вкладку?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                var last_page = this.pages.Pop();
                last_page.Close();
            }
        }

        private void delDistMBtn_Click(object sender, EventArgs e)
        {
            var distDialogForm = new OpenDistanceDialog(this.compPage.getFullFreeDistances());
            if(distDialogForm.ShowDialog() == DialogResult.OK)
            {
                var distance = distDialogForm.distance;
                DelDistance(distance);
            }
        }

        private void DelDistance(Distance dist)
        {
            DelDistFromBase(dist);
            List<Guid> st_ids = new List<Guid>();
            foreach (Stage st in dist.Stages)
                st_ids.Add(st.Id);
            foreach (Guid id in st_ids)
                Stage.Items.Remove(id);
            st_ids.Clear();
            DelParticips(dist);
            var dtcr_ids = new List<Guid>();
            foreach (var dtcr in DistToCompetitionsRelations.Items.Values)
                if (dtcr.Distance.Equals(dist))
                    dtcr_ids.Add(dtcr.Id);
            foreach(Guid dtcr_id in dtcr_ids)
                DistToCompetitionsRelations.Items.Remove(dtcr_id);
            Distance.Items.Remove(dist.Id);
        }

        private void DelDistFromBase(Distance dist)
        {
            SQLiteCommand com = new SQLiteCommand(conn);
            conn.Open();
            com.CommandText = string.Format(@"DELETE FROM stages WHERE dist_id='{0}'",
                    dist.Id.ToString());
            com.ExecuteNonQuery();
            foreach (Stage st in dist.Stages)
            {
                com.CommandText = string.Format(@"DELETE FROM stage_result WHERE stage_id='{0}'",
                    st.Id.ToString());
                com.ExecuteNonQuery();
            }
            DelDistanceParticipsFromBase(com, dist);
            com.CommandText = string.Format(@"DELETE FROM competitions_to_dist_relations WHERE dist_id='{0}'",
                dist.Id.ToString());
            com.ExecuteNonQuery();
            com.CommandText = string.Format(@"DELETE FROM distances WHERE id='{0}'", dist.Id.ToString());
            com.ExecuteNonQuery();
            conn.Close();
        }

        private void DelParticips(Distance dist)
        {
            List<Guid> part_ids = new List<Guid>();
            foreach (Participation particip in Participation.Items.Values)
                if (particip.Distance.Equals(dist))
                    part_ids.Add(particip.Id);
            foreach (Guid id in part_ids)
                Participation.Items.Remove(id);
        }

        private void DelDistanceParticipsFromBase(SQLiteCommand com, Distance dist)
        {
            com.CommandText = string.Format(@"SELECT * FROM participations WHERE dist_id='{0}'",
                dist.Id.ToString());
            DbDataReader reader = com.ExecuteReader();
            foreach (DbDataRecord part_rec in reader)
            {
                Guid part_id = Guid.Parse(part_rec["id"].ToString());
                SQLiteCommand eraser = new SQLiteCommand(com.Connection);
                eraser.CommandText = string.Format(@"DELETE FROM participation_relations WHERE participation_id='{0}'",
                part_id.ToString());
                eraser.ExecuteNonQuery();
                eraser.Reset();
            }
            reader.Close();
            com.CommandText = string.Format(@"DELETE FROM participations WHERE dist_id='{0}'",
                dist.Id.ToString());
            com.ExecuteNonQuery();
        }

        private void createUmovuMBtn_Click(object sender, EventArgs e)
        {
            if (word_thread != null && word_thread.IsAlive) return;
            var distDialogForm = new OpenDistanceDialog(this.competitions.Distances.ToList());
            if (distDialogForm.ShowDialog() == DialogResult.OK)
            {
                var distance = distDialogForm.distance;
                SaveFileDialog sfdial = new SaveFileDialog();
                sfdial.Filter = "Документ word (doc)|*.doc|Документ word (docx)|*.docx";
                sfdial.Title = "Введіть назву файла та його місце збереження";
                DialogResult res = sfdial.ShowDialog();
                if (res != DialogResult.Cancel && res != DialogResult.Abort)
                {
                    (File.Create(sfdial.FileName)).Close();
                    var creator = new DistConditionsCreator(sfdial.FileName, distance);
                    word_thread = new Thread(new ThreadStart(creator.CreateDoc));
                    word_thread.Start();
                }
            }
        }

        private void createDistResMBtn_Click(object sender, EventArgs e)
        {
            if (excel_res_thread != null && excel_res_thread.IsAlive) return;
            SaveFileDialog sfdial = new SaveFileDialog();
            sfdial.Filter = "Документ Excel (xlsx)|*.xlsx";
            sfdial.Title = "Введіть назву файла та його місце збереження";
            DialogResult res = sfdial.ShowDialog();
            if (res != DialogResult.Cancel && res != DialogResult.Abort)
            {
                (File.Create(sfdial.FileName)).Close();
                SortRes();
                DialogResult need_full_time = MessageBox.Show("Записувати загальний час?\nЯкщо оберете \"ні\", то буде записано час роботи на кожному етапі.", "", MessageBoxButtons.YesNo);
                var creator = new ExcelResultCreator(sfdial.FileName, this.distResPage.Participations, need_full_time == DialogResult.Yes ? true : false);
                excel_res_thread = new Thread(new ThreadStart(creator.CreateResultExcelDoc));
                excel_res_thread.Start();
            }
        }

        private void SortRes()
        {
            this.distResPage.SortResults(reverseSortChecker.Checked);
            RefreshPartListBox();
        }

        private void RefreshPartListBox()
        {
            participsListBox.DataSource = null;
            participsListBox.DataSource = this.distResPage.Participations;
        }

        private void distResPanelSortTeamBtn_Click(object sender, EventArgs e)
        {
            SortRes();
        }

        private void delCompMenuBtn_Click(object sender, EventArgs e)
        {
            var compDialogForm = new OpenCompDialog();
            if (compDialogForm.ShowDialog() == DialogResult.Yes)
            {
                var comp = compDialogForm.competition;
                RemCompetitions(comp);
                if (Competitions.Items.Count == 0)
                {
                    this.runCompMenuBtn.Enabled = false;
                    this.delCompMenuBtn.Enabled = false;
                }
                MessageBox.Show("Змагання видалено!");
            }
        }
        
        private void RemCompetitions(Competitions toRem)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = base.db");
            conn.Open();
            SQLiteCommand command = new SQLiteCommand(conn);                        
            RemTeamsFromBase(command, toRem);
            RemRelations(toRem);
            command.CommandText = string.Format(@"DELETE FROM competitions_to_dist_relations WHERE [comp_id]='{0}';", toRem.Id.ToString());
            command.ExecuteNonQuery();
            command.CommandText = string.Format(@"DELETE FROM team_to_competitions_relations WHERE [comp_id]='{0}';", toRem.Id.ToString());
            command.ExecuteNonQuery();
            command.CommandText = string.Format(@"DELETE FROM competitions WHERE [id]='{0}';", toRem.Id.ToString());
            command.ExecuteNonQuery();
            conn.Close();
            Competitions.Items.Remove(toRem.Id);
        }

        private void RemTeamsFromBase(SQLiteCommand com, Competitions comp)
        {
            List<Guid> team_guids = new List<Guid>();
            com.CommandText = string.Format(@"SELECT * FROM team_to_competitions_relations WHERE comp_id='{0}'",
                comp.Id.ToString());
            DbDataReader reader = com.ExecuteReader();
            foreach (DbDataRecord record in reader)
                team_guids.Add(Guid.Parse(record["team_id"].ToString()));
            reader.Close();
            foreach (Guid team_id in team_guids)
            {
                RemParticipsFromBase(com, team_id);
                com.CommandText = string.Format(@"DELETE FROM team_relations WHERE team_id='{0}'", team_id.ToString());
                com.ExecuteNonQuery();
                com.CommandText = string.Format(@"DELETE FROM teams WHERE id='{0}'", team_id.ToString());
                com.ExecuteNonQuery();
            }
        }

        private void RemParticipsFromBase(SQLiteCommand com, Guid team_id)
        {
            List<Guid> turisto_guids = new List<Guid>();
            com.CommandText = string.Format(@"SELECT * FROM team_relations WHERE team_id='{0}'",
                team_id.ToString());
            DbDataReader reader = com.ExecuteReader();
            foreach (DbDataRecord record in reader)
                turisto_guids.Add(Guid.Parse(record["turisto_id"].ToString()));
            reader.Close();
            var part_ids = new List<Guid>();
            com.CommandText = string.Format(@"SELECT * FROM participations WHERE team_id='{0}';",
                team_id.ToString());
            reader = com.ExecuteReader();
            foreach (DbDataRecord rec in reader) part_ids.Add(Guid.Parse(rec["id"].ToString()));
            reader.Close();
            foreach (Guid turisto_id in turisto_guids)
            {
                com.CommandText = string.Format(@"DELETE FROM participation_relations WHERE turisto_id='{0}'",
                    turisto_id.ToString());
                com.ExecuteNonQuery();
            }
            com.CommandText = string.Format(@"DELETE FROM participations WHERE team_id='{0}'", team_id.ToString());
            com.ExecuteNonQuery();
            foreach(var part_id in part_ids)
            {
                com.CommandText = string.Format(@"DELETE FROM stage_result WHERE participation_id='{0}';", part_id.ToString());
                com.ExecuteNonQuery();
            }
        }

        private void RemRelations(Competitions competitions)
        {
            List<Guid> dtcrToRem = new List<Guid>();
            foreach (DistToCompetitionsRelations dtcr in DistToCompetitionsRelations.Items.Values)
                if (dtcr.Competitions.Equals(competitions))
                    dtcrToRem.Add(dtcr.Id);
            foreach (Guid dtcrId in dtcrToRem)
                DistToCompetitionsRelations.Items.Remove(dtcrId);
        }

        private void teamPanelAddCatBtn_Click(object sender, EventArgs e)
        {
            this.teamPage.AddCat();
        }

        private void distPropMBtn_Click(object sender, EventArgs e)
        {
            new DistPropertiesForm(this.compDistsListBox.SelectedItem as Distance).ShowDialog();
        }

        private void teamPropMBtn_Click(object sender, EventArgs e)
        {
            new TeamPropertiesForm(this.compTeamsListBox.SelectedItem as Team).ShowDialog();
        }

        private void participsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int index = this.participsListBox.IndexFromPoint(e.Location);
                if (index == -1) return;
                this.participsListBox.SetSelected(index, true);
                this.participMenu.Show(this.participsListBox, e.Location, ToolStripDropDownDirection.Right);
            }
        }

        private void participPropMBtn_Click(object sender, EventArgs e)
        {
            new ParticipPropForm(this.participsListBox.SelectedItem as Participation).ShowDialog();
        }

        private void participsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (participsListBox.SelectedItem != null)
            {
                var selected = participsListBox.SelectedItem as Participation;
                resTBox.Text = (selected).FullTime.ToString(@"hh\:mm\:ss");
            }
        }

        private void createStartProtMBtn_Click(object sender, EventArgs e)
        {
            if (start_prot_thread != null && start_prot_thread.IsAlive) return;
            SaveFileDialog sfdial = new SaveFileDialog();
            sfdial.Filter = "Документ Excel (xlsx)|*.xlsx";
            sfdial.Title = "Введіть назву файла та його місце збереження";
            DialogResult res = sfdial.ShowDialog();
            if (res != DialogResult.Cancel && res != DialogResult.Abort)
            {
                (File.Create(sfdial.FileName)).Close();
                var creator = new ExcelStartProtocolCreator(sfdial.FileName, this.distResPage.Participations);
                start_prot_thread = new Thread(new ThreadStart(creator.CreateLotExcelDoc));
                start_prot_thread.Start();
            }
        }
    }
}
