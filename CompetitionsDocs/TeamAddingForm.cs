using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SQLite;

namespace CompetitionsManager
{
    internal partial class TeamAddingForm : Form
    {
        private Competitions competitions;
        private Distance distance;
        private List<Team> teams = new List<Team>();
        private Team current_team = null;
        public List<Participation> participations = new List<Participation>();
        public TeamAddingForm(Competitions competitions, Distance distance)
        {
            InitializeComponent();
            this.competitions = competitions;
            this.distance = distance;
            foreach(var team in competitions.Teams)
            {
                bool flag = true;
                foreach(var participation in Participation.Items.Values)
                {
                    if(participation.Distance.Equals(this.distance) && participation.Team.Equals(team))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    this.teams.Add(team);
            }
            this.teamsListBox.DataSource = teams;
        }

        private void RefreshTeamsListBox()
        {
            this.teamsListBox.DataSource = null;
            this.teamsListBox.DataSource = this.teams;
        }

        private void choseBtn_Click(object sender, EventArgs e)
        {
            var team = teamsListBox.SelectedItem as Team;
            if (team == null) return;
            int delta = team.Teammates.Count() - this.distance.TeammatesCount;
            if (delta < 0)
            {
                string message = "Необхідно додати ще ";
                delta = Math.Abs(delta);
                if (delta == 1) message += "одного учасника ";
                else if (delta > 1 && delta < 5) message += string.Format("{0} учасника", delta.ToString());
                else message += string.Format("{0} учасників", delta.ToString());
                message += " для участі на дистанції";
                MessageBox.Show(message);
                return;
            }
            current_team = team;
            if (this.tabControl.TabPages.Contains(this.sportsmansPage))
                this.tabControl.TabPages.Remove(this.sportsmansPage);
            this.turistoCLBox.Items.Clear();
            this.turistoCLBox.Items.AddRange(team.Teammates.ToArray());
            this.sportsmansPage.Text = string.Format("Заявка команди '{0}'", team.Name);
            this.tabControl.TabPages.Add(this.sportsmansPage);
            this.tabControl.SelectedTab = this.sportsmansPage;
            
        }

        private void addParticipBtn_Click(object sender, EventArgs e)
        {
            if (this.turistoCLBox.CheckedItems.Count == distance.TeammatesCount)
            {
                List<Sportsman> turistos = new List<Sportsman>();
                foreach (object obj in this.turistoCLBox.CheckedItems)
                    turistos.Add((Sportsman)obj);
                Participation part = new Participation(this.current_team.Id, turistos, this.distance);
                CreateEmptyResults(part);
                SavePartitipInBase(part);
                MessageBox.Show("Заявку додано!");
                this.teams.Remove(this.current_team);
                RefreshTeamsListBox();
                this.current_team = null;
                this.participations.Add(part);
                this.tabControl.TabPages.Remove(this.sportsmansPage);
            }
            else
            {
                int delta = this.distance.TeammatesCount - this.turistoCLBox.CheckedItems.Count;
                string message = string.Format("Потрібно {0} учасників:{1}",
                    (delta > 0 ? "додати ще" : "прибрати"), Math.Abs(delta));
                MessageBox.Show(message);
            }
            if (this.teams.Count == 0) this.Close();
        }

        private void CreateEmptyResults(Participation particip)
        {
            foreach (Stage stage in this.distance.Stages)
                particip.Results.Add(new StageResult(stage, new TimeSpan(0, 0, 0), ""));
        }

        private void SavePartitipInBase(Participation particip)
        {
            SQLiteConnection conn = new SQLiteConnection("Data source = base.db");
            SQLiteCommand com = new SQLiteCommand(conn);
            conn.Open();
            com.CommandText = string.Format(@"INSERT INTO participations VALUES('{0}','{1}','{2}','{3}')",
                particip.Id.ToString(), 0, particip.Distance.Id.ToString(), particip.Team.Id.ToString());
            com.ExecuteNonQuery();
            foreach (Sportsman turisto in particip.Participants)
            {
                com.CommandText = string.Format(@"INSERT INTO participation_relations VALUES('{0}','{1}')",
                    particip.Id.ToString(), turisto.Id.ToString());
                com.ExecuteNonQuery();
            }
            SaveResultsInBase(com, particip);
            conn.Close();
        }

        private void SaveResultsInBase(SQLiteCommand com, Participation particip)
        {
            foreach (StageResult sr in particip.Results)
            {
                com.CommandText = string.Format(@"INSERT INTO stage_result VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                    sr.Id.ToString(), sr.Stage.Id.ToString(), sr.Time.ToString(), sr.Penalties,
                    sr.Comment, particip.Id.ToString());
                com.ExecuteNonQuery();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.turistoCLBox.Items.Clear();
            this.tabControl.TabPages.Remove(this.sportsmansPage);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
