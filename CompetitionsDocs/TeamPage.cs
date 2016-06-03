using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SQLite;

namespace CompetitionsManager
{
    class TeamPage : IFormPage
    {
        public Panel Panel { get; private set; }
        private Team team;
        private bool team_edit_mode = false;
        private bool team_edited = false;
        private List<Sportsman> turistos_in_team = null;
        public List<Sportsman> Turistos_in_team { get { return this.turistos_in_team; } }
        private List<Sportsman> teammates_copies = null;
        public Team Team
        {
            get { return this.team; }
            private set
            {
                this.team = value;
                this.team_edit_mode = this.team != null;
                if(this.team_edit_mode)
                {
                    this.turistos_in_team = this.team.Teammates.ToList();
                    this.teammates_copies = this.team.Teammates.ToList();
                }
            }
        }
        public void TeamCreatingMode(Competitions competitions)
        {
            this.team = null;
            this.team_edit_mode = false;
            this.competitions = competitions;
            this.turistos_in_team = new List<Sportsman>();
        }
        public void TeamEditingMode(Team team, Competitions competitions)
        {
            this.Team = team;
            this.competitions = competitions;
            List<Guid> tr_ids = new List<Guid>();
            foreach (TeamRelations tr in TeamRelations.Items.Values)
                if (tr.Team.Equals(team))
                    tr_ids.Add(tr.Id);
            foreach (Guid id in tr_ids)
                TeamRelations.Items.Remove(id);
            this.team_edit_mode = true;
            this.team_edited = false;
        }
        private Competitions competitions;
        private TreeView catTreeView;
        private SQLiteConnection conn = new SQLiteConnection("Data source = base.db");      
        public TeamPage(Panel panel, TreeView catTreeView)
        {
            this.Panel = panel;
            this.catTreeView = catTreeView;
            LoadCatData();
        }

        Dictionary<int, Category> catDict = new Dictionary<int, Category>();

        public Dictionary<int, Category> CatDict { get { return this.catDict; } }

        private void LoadCatData()
        {
            SQLiteCommand com = new SQLiteCommand(conn);
            this.conn.Open();
            LoadCategories(com);
            foreach (Category cat in Category.Items.Values)
                LoadSportsmans(com, cat);
            this.catTreeView.Sort();
            foreach (TreeNode node in catTreeView.Nodes)
                CheckLeafs(node);
            this.conn.Close();
        }

        private void LoadSportsmans(SQLiteCommand com, Category category)
        {
            com.CommandText = string.Format(@"SELECT * FROM turistos WHERE cat_id='{0}';",
                category.Id.ToString());
            DbDataReader reader = com.ExecuteReader();
            foreach (DbDataRecord tur_record in reader)
            {
                Guid id = Guid.Parse((string)tur_record["id"]);
                string name = (string)tur_record["name"];
                DateTime birthDay = DateTime.Parse((string)tur_record["birth_day"]);
                Qualification qualif = Sportsman.ParseQual((string)tur_record["qualification"]);
                new Sportsman(name, birthDay, qualif, id).Category = category;
            }
            reader.Close();
        }

        private void LoadCategories(SQLiteCommand com)
        {
            com.CommandText = @"SELECT * FROM category";
            DbDataReader reader = com.ExecuteReader();
            Dictionary<Guid, TreeNode> nodes = new Dictionary<Guid, TreeNode>();
            Dictionary<Guid, List<TreeNode>> children = new Dictionary<Guid, List<TreeNode>>();
            foreach (DbDataRecord cat_record in reader)
            {
                Guid id = Guid.Parse((string)cat_record["id"]);
                string name = (string)cat_record["name"];
                string parent_StrId = (string)cat_record["parent_id"];
                Category cat = new Category(name, id);
                TreeNode _newCat = new TreeNode(cat.Name);
                catDict.Add(_newCat.GetHashCode(), cat);
                nodes.Add(cat.Id, _newCat);
                if (parent_StrId == "")
                    catTreeView.Nodes.Add(_newCat);
                else
                {
                    Guid parent_id = Guid.Parse(parent_StrId);
                    if (!children.ContainsKey(parent_id))
                        children[parent_id] = new List<TreeNode>();
                    children[parent_id].Add(_newCat);
                }
            }
            reader.Close();
            foreach (Guid _catId in nodes.Keys)
            {
                TreeNode curr_node = nodes[_catId];
                if (children.ContainsKey(_catId))
                {
                    foreach (TreeNode child in children[_catId])
                        curr_node.Nodes.Add(child);
                }
            }
        }

        private void CheckLeafs(TreeNode node)
        {
            if (node.Nodes.Count == 0)
                catDict[node.GetHashCode()].IsLeaf = true;
            else
            {
                catDict[node.GetHashCode()].IsLeaf = false;
                foreach (TreeNode child in node.Nodes) CheckLeafs(child);
            }
        }       

        public Category GetCategoryByNode(TreeNode node)
        {
            return catDict[node.GetHashCode()];
        }

        public void AddTeammate(Sportsman turisto)
        {
            turistos_in_team.Add(turisto);
        }

        public void RemoveTeammate(Sportsman turisto)
        {
            if (turisto == null) return;
            this.turistos_in_team.Remove(turisto);
        }

        public void EndTeamEditing(string team_name, string coach_name)
        {
            if (!this.team_edit_mode)
                this.team = new Team(team_name, coach_name, turistos_in_team, this.competitions.Id);
            else
            {
                this.team.Name = team_name;
                this.team.CoachName = coach_name;
                this.team_edited = true;
            }
            SaveTeam();
        }

        public void CancelTeamEditing()
        {
            if (this.team_edit_mode)
            {
                foreach (Sportsman turisto in teammates_copies)
                    this.team.AddTeammate(turisto);
                teammates_copies.Clear();
            }
        }

        private void SaveTeam()
        {
            if (!this.team_edit_mode)
            {
                if (this.team != null)
                {
                    SaveTeamInBase(this.team);
                    MessageBox.Show("Комадну створено!");
                }
            }
            else
            {
                foreach (Sportsman turisto in turistos_in_team)
                    this.team.AddTeammate(turisto);
                SaveTeamChanges(this.team);
                MessageBox.Show("Зміни збережено!");
            }
        }

        private void SaveTeamInBase(Team team)
        {
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            com.CommandText = string.Format(@"INSERT INTO teams VALUES('{0}','{1}','{2}','{3}');",
                team.Id.ToString(), team.Name, team.CoachName, this.competitions.Id.ToString());
            com.ExecuteNonQuery();
            SaveTeamRelations(com, team);
            conn.Close();
        }

        private void SaveTeamRelations(SQLiteCommand com, Team team)
        {
            foreach (Sportsman turisto in team.Teammates)
            {
                com.CommandText = string.Format(@"INSERT INTO team_relations VALUES('{0}','{1}')",
                    team.Id.ToString(), turisto.Id.ToString());
                com.ExecuteNonQuery();
            }
        }

        private void SaveTeamChanges(Team team)
        {
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            com.CommandText = string.Format(@"UPDATE teams SET name='{0}',couch='{1}' WHERE id='{2}'",
                team.Name, team.CoachName, team.Id.ToString());
            com.ExecuteNonQuery();
            DelOldTeamRelations(com, team);
            foreach (Sportsman turisto in team.Teammates)
            {
                com.CommandText = string.Format(@"INSERT INTO team_relations VALUES('{0}','{1}')",
                    team.Id.ToString(), turisto.Id.ToString());
                com.ExecuteNonQuery();
            }
            conn.Close();
        }

        private void DelOldTeamRelations(SQLiteCommand com, Team team)
        {
            com.CommandText = string.Format(@"DELETE FROM team_relations WHERE team_id='{0}'",
                team.Id.ToString());
            com.ExecuteNonQuery();
        }

        public void AddCat()
        {
            CatAddForm caForm = new CatAddForm();
            if (caForm.ShowDialog() == DialogResult.OK)
            {
                Category _newCat = new Category(caForm.category_name);
                TreeNode _newNode = new TreeNode(_newCat.Name);
                catTreeView.Nodes.Add(_newNode);
                catDict.Add(_newNode.GetHashCode(), _newCat);
                SaveNode(_newNode, _newNode);
                MessageBox.Show("Категорію додано!");
            }
        }

        public void AddSubCat()
        {
            if (catDict[catTreeView.SelectedNode.GetHashCode()].Sportsmans.Count() != 0)
            {
                MessageBox.Show("Підкатегорію можна додавати лише туди,\nде нема збережених спортсменів!");
                return;
            }
            CatAddForm caForm = new CatAddForm(true);
            if (caForm.ShowDialog() == DialogResult.OK)
            {
                Category _newCat = new Category(caForm.category_name);
                TreeNode _newNode = new TreeNode(_newCat.Name);
                TreeNode parent = catTreeView.SelectedNode;
                catDict[parent.GetHashCode()].IsLeaf = false;
                parent.Nodes.Add(_newNode);
                catDict.Add(_newNode.GetHashCode(), _newCat);
                SaveNode(_newNode, parent);
                MessageBox.Show("Додано!");
            }
        }

        private void SaveNode(TreeNode node, TreeNode parent)
        {
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            Category nodeCat = catDict[node.GetHashCode()];
            Category parentCat = catDict[parent.GetHashCode()];
            com.CommandText = string.Format(@"INSERT INTO category VALUES('{0}','{1}','{2}');",
                nodeCat.Id.ToString(), nodeCat.Name,
                parentCat.Equals(nodeCat) ? "" : parentCat.Id.ToString());
            com.ExecuteNonQuery();
            conn.Close();
        }

        public void RenameCat()
        {
            if (catTreeView.SelectedNode != null)
            {
                Category sel_cat = catDict[catTreeView.SelectedNode.GetHashCode()];
                var caForm = new CatAddForm(sel_cat);
                if (caForm.ShowDialog() == DialogResult.OK)
                {
                    sel_cat.Name = caForm.category_name;
                    SaveCategoryChanges(sel_cat);
                    catTreeView.SelectedNode.Text = sel_cat.Name;
                }
            }
        }

        private void SaveCategoryChanges(Category cat)
        {
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            com.CommandText = string.Format(@"UPDATE category SET name='{0}' WHERE id='{1}'",
                cat.Name, cat.Id.ToString());
            com.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteCat()
        {
            DialogResult dialRes = MessageBox.Show("Разом із категорією буде видалено всіх спортсменів.\nВидалити?",
                "Підтвердження", MessageBoxButtons.YesNo);
            if (dialRes == DialogResult.Yes)
            {
                DeleteCategory(catTreeView.SelectedNode);
                foreach (TreeNode node in catTreeView.Nodes) CheckLeafs(node);
                MessageBox.Show("Категорію видалено!");
            }
        }       

        public void AddSportsman()
        {
            Category cat = catDict[catTreeView.SelectedNode.GetHashCode()];
            var spCreatorForm = new SportsmanCreatorForm();
            if (spCreatorForm.ShowDialog() == DialogResult.OK)
            {
                var _new_turisto = spCreatorForm.turisto;
                _new_turisto.Category = cat;
                SaveSportsman(cat, _new_turisto);                
            }
        }

        private void SaveSportsman(Category cat, Sportsman turisto)
        {
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            com.CommandText = string.Format(@"INSERT INTO turistos VALUES('{0}','{1}','{2}','{3}','{4}');",
                turisto.Id.ToString(), turisto.Name, turisto.BirthDay.ToString(),
                Sportsman.QualToString(turisto.Qualification), cat.Id.ToString());
            com.ExecuteNonQuery();
            conn.Close();
        }

        public void EditSportsman(Sportsman turisto)
        {
            if (turisto == null) return;
            var sportsmanCretionDialog = new SportsmanCreatorForm(turisto).ShowDialog();
            if (sportsmanCretionDialog == DialogResult.OK)
                SaveSportsmanChanges(turisto);                
        }

        private void SaveSportsmanChanges(Sportsman turisto)
        {
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            com.CommandText = string.Format(
                @"UPDATE turistos SET name='{0}',birth_day='{1}',qualification='{2}' WHERE id='{3}'",
                turisto.Name, turisto.BirthDay.ToString(), Sportsman.QualToString(turisto.Qualification),
                turisto.Id.ToString());
            com.ExecuteNonQuery();
            conn.Close();
        }

        private void DeleteCategory(TreeNode node)
        {
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            DeleteNode(com, node);
            catTreeView.Nodes.Remove(node);
            conn.Close();
        }

        private void DeleteNode(SQLiteCommand com, TreeNode node)
        {
            foreach (TreeNode child in node.Nodes)
                DeleteNode(com, child);
            Category cat = catDict[node.GetHashCode()];
            catDict.Remove(node.GetHashCode());
            DeleteCategoryFromBase(com, cat);
            Category.Items.Remove(cat.Id);
        }        

        private void DeleteCategoryFromBase(SQLiteCommand com, Category cat)
        {
            if (cat.Sportsmans.Count() > 0)
                DeleteSportsmansInCategory(com, cat);
            com.CommandText = string.Format(@"DELETE FROM category WHERE id='{0}'",
                cat.Id.ToString());
            com.ExecuteNonQuery();
        }

        private void DeleteSportsmansInCategory(SQLiteCommand com, Category cat)
        {
            List<Guid> st_ids = new List<Guid>();
            foreach (Sportsman turisto in cat.Sportsmans)
            {
                DeleteTeamRelations(com, turisto);
                st_ids.Add(turisto.Id);
            }
            foreach (Guid turisto_id in st_ids)
                Sportsman.Items.Remove(turisto_id);
            com.CommandText = string.Format(@"DELETE FROM turistos WHERE cat_id='{0}'",
                cat.Id.ToString());
            com.ExecuteNonQuery();
        }

        public void DeleteSportsman(Sportsman turisto)
        {
            if (turisto != null)
            {
                DialogResult dialRes = MessageBox.Show("Видалити спортсмена?",
                "Підтвердження", MessageBoxButtons.YesNo);
                if (dialRes == DialogResult.Yes)
                {
                    RemoveTuristo(turisto);                    
                    MessageBox.Show("Спортсмена видалено!");
                }
            }
        }

        private void RemoveTuristo(Sportsman turisto)
        {
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            DeleteTeamRelations(com, turisto);
            com.CommandText = string.Format(@"DELETE FROM turistos WHERE id='{0}'",
                turisto.Id.ToString());
            com.ExecuteNonQuery();
            conn.Close();
            Sportsman.Items.Remove(turisto.Id);
        }

        private void DeleteTeamRelations(SQLiteCommand com, Sportsman turisto)
        {
            com.CommandText = string.Format(@"SELECT * FROM team_relations WHERE turisto_id='{0}'",
                    turisto.Id.ToString());
            DbDataReader reader = com.ExecuteReader();
            foreach (DbDataRecord team_rec in reader)
            {
                Guid team_id = Guid.Parse(team_rec["team_id"].ToString());
                SQLiteCommand eraser = new SQLiteCommand(com.Connection);
                DeleteParticipations(eraser, team_id);
            }
            reader.Close();
            com.CommandText = string.Format(@"DELETE FROM team_relations WHERE turisto_id='{0}'",
                    turisto.Id.ToString());
            com.ExecuteNonQuery();
        }

        private void DeleteParticipations(SQLiteCommand com, Guid team_id)
        {
            com.CommandText = string.Format(@"SELECT * FROM participations WHERE team_id='{0}'",
                team_id.ToString());
            DbDataReader reader = com.ExecuteReader();
            foreach (DbDataRecord part_rec in reader)
            {
                Guid part_id = Guid.Parse(part_rec["id"].ToString());
                SQLiteCommand eraser = new SQLiteCommand(com.Connection);
                eraser.CommandText = string.Format(@"DELETE FROM stage_result WHERE participation_id='{0}'",
                    part_id.ToString());
                eraser.ExecuteNonQuery();
                eraser.CommandText = string.Format(@"DELETE FROM participation_relations WHERE participation_id='{0}'",
                    part_id.ToString());
                eraser.ExecuteNonQuery();
            }
            reader.Close();
            com.CommandText = string.Format(@"DELETE FROM participations WHERE team_id='{0}'",
                team_id.ToString());
            com.ExecuteNonQuery();
        }

        public void Open()
        {
            MainForm.Instance.Controls.Add(this.Panel);
            this.Panel.BringToFront();
        }
        public void Close()
        {
            if (this.team_edit_mode && !this.team_edited)
                CancelTeamEditing();
            MainForm.Instance.Controls.Remove(this.Panel);
        }
    }
}
