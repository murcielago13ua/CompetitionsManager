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
    class CompetitionsPage : IFormPage
    {
        public Panel Panel { get; private set; }
        private Competitions competitions;
        private DateTimePicker dt_picker;
        public Competitions Competitions
        {
            get { return this.competitions; }
            set
            {
                this.competitions = value;
                this.dt_picker.Value = this.competitions.Date;
                LoadTeamsData();
            }
        }
        private SQLiteConnection conn = new SQLiteConnection("Data source = base.db");
        public CompetitionsPage(Panel panel, DateTimePicker dt_picker)
        {
            this.Panel = panel;
            this.dt_picker = dt_picker;
        }
        
        public List<Distance> getFullFreeDistances()
        {
            var res = new List<Distance>();
            foreach (var distance in Distance.Items.Values)
                if (distance.Competitions.Count() == 0) res.Add(distance);
            return res;
        }

        public List<Distance> getFreeDistances(Competitions comp)
        {
            var result = new List<Distance>();
            foreach (var distance in Distance.Items.Values)
                if (!distance.Competitions.Contains(comp))
                    result.Add(distance);
            return result;
        }

        private void LoadTeamsData()
        {
            var teams = new List<Team>();
            conn.Open();
            var com = new SQLiteCommand(conn);
            com.CommandText = string.Format(@"SELECT * FROM teams WHERE comp_id = '{0}'",
                this.competitions.Id.ToString());
            DbDataReader reader = com.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                Guid team_id = Guid.Parse(record["id"].ToString());
                string name = record["name"].ToString();
                string coach_name = record["couch"].ToString();
                teams.Add(new Team(name, coach_name, GetTeammates(team_id), this.competitions.Id, team_id));                
            }
            reader.Close();
            foreach (var team in teams)
            {
                foreach (Distance dist in this.competitions.Distances)
                    LoadParticips(com, team.Id, dist.Id);
            }
            conn.Close();
        }

        private List<Sportsman> GetTeammates(Guid team_id)
        {
            var com = new SQLiteCommand(this.conn);
            List<Guid> turisto_ids = new List<Guid>();
            List<Sportsman> turistos = new List<Sportsman>();
            com.CommandText = string.Format(@"SELECT * FROM team_relations WHERE team_id = '{0}'", team_id);
            DbDataReader team_reader = com.ExecuteReader();
            foreach (DbDataRecord team_record in team_reader)
                turisto_ids.Add(Guid.Parse((string)team_record["turisto_id"]));
            team_reader.Close();
            foreach (Guid turisto_id in turisto_ids)
                turistos.Add(Sportsman.Items[turisto_id]);
            return turistos;
        }

        private void LoadParticips(SQLiteCommand com, Guid team_id, Guid dist_id)
        {
            com.CommandText = string.Format(@"SELECT * FROM participations WHERE team_id='{0}' AND dist_id='{1}'",
                team_id.ToString(), dist_id.ToString());
            DbDataReader reader = com.ExecuteReader();
            Dictionary<Guid, int> part_prots = new Dictionary<Guid, int>();
            foreach (DbDataRecord part_rec in reader)
            {
                Guid id = Guid.Parse((string)part_rec["id"]);
                part_prots.Add(id, (int)part_rec["dist_pens"]);
            }
            reader.Close();
            foreach (Guid part_id in part_prots.Keys)
            {
                com.CommandText = string.Format(@"SELECT * FROM stage_result WHERE participation_id='{0}'",
                    part_id.ToString());
                reader = com.ExecuteReader();
                List<StageResult> srs = new List<StageResult>();
                foreach (DbDataRecord st_res in reader)
                {
                    Guid id = Guid.Parse((string)st_res["id"]);
                    Guid stage_id = Guid.Parse((string)st_res["stage_id"]);
                    TimeSpan time = TimeSpan.Parse((string)st_res["time"]);
                    int pens = int.Parse(st_res["penalties"].ToString());
                    string comment = (string)st_res["comment"];
                    StageResult sr = new StageResult(Stage.Items[stage_id], time, comment, id);
                    sr.AddPenalty(pens);
                    srs.Add(sr);
                }
                reader.Close();
                Participation part = new Participation(team_id, new List<Sportsman>(),
                    Distance.Items[dist_id], part_id);
                part.DistPenalties = part_prots[part_id];
                part.Results.AddRange(srs);
                GetParticipants(com, part);
            }
        }

        private void GetParticipants(SQLiteCommand com, Participation particip)
        {
            com.CommandText = string.Format(@"SELECT * FROM participation_relations WHERE participation_id='{0}'",
                particip.Id.ToString());
            DbDataReader reader = com.ExecuteReader();
            List<Guid> turistos_ids = new List<Guid>();
            foreach (DbDataRecord tur_rec in reader)
                turistos_ids.Add(Guid.Parse((string)tur_rec["turisto_id"]));
            reader.Close();
            foreach (Guid id in turistos_ids)
                particip.AddParticipant(Sportsman.Items[id]);
        }

        public void AddDistanceToComp(Distance distance)
        {
            this.competitions.AddDistance(distance);
            SQLiteCommand com = new SQLiteCommand(conn);
            conn.Open();
            com.CommandText = string.Format(@"INSERT INTO competitions_to_dist_relations VALUES('{0}','{1}')",
                this.competitions.Id.ToString(), distance.Id.ToString());
            com.ExecuteNonQuery();
            conn.Close();
        }

        public void RemoveDistFromComp(Distance distance)
        {
            conn.Open();
            DelDistRelations(conn, distance);
            conn.Close();
        }

        private void DelDistRelations(SQLiteConnection conn, Distance distance)
        {
            SQLiteCommand com = new SQLiteCommand(conn);
            com.CommandText = string.Format(@"DELETE FROM competitions_to_dist_relations WHERE dist_id='{0}'",
                distance.Id.ToString());
            com.ExecuteNonQuery();
            DelParticipsFromBase(com, distance);
            foreach (Team team in this.competitions.Teams)
                DelPartisips(team);
            Guid dtcr_to_rem = distance.Id;
            foreach (DistToCompetitionsRelations dtcr in DistToCompetitionsRelations.Items.Values)
            {
                if (dtcr.Distance.Id.Equals(distance.Id))
                {
                    dtcr_to_rem = dtcr.Id;
                    break;
                }
            }
            DistToCompetitionsRelations.Items.Remove(dtcr_to_rem);
        }

        private void DelParticipsFromBase(SQLiteCommand com, Distance dist)
        {
            com.CommandText = string.Format(@"SELECT * FROM participations WHERE dist_id='{0}'",
                dist.Id.ToString());
            DbDataReader reader = com.ExecuteReader();
            foreach (DbDataRecord part_rec in reader)
            {
                Guid part_id = Guid.Parse(part_rec["id"].ToString());
                Guid team_id = Guid.Parse(part_rec["team_id"].ToString());
                SQLiteCommand eraser = new SQLiteCommand(com.Connection);
                DelPartRelFromBase(eraser, part_id);
                eraser.Reset();
                eraser.CommandText = string.Format(@"DELETE FROM stage_result WHERE participation_id='{0}';",
                    part_id.ToString());
                eraser.ExecuteNonQuery();
            }
            reader.Close();
            com.CommandText = string.Format(@"DELETE FROM participations WHERE dist_id='{0}'",
                dist.Id.ToString());
            com.ExecuteNonQuery();
        }

        public bool DeleteTeam(Team team)
        {
            if (team == null) return false;           
            var dial = MessageBox.Show("Підтвердження", "Видалити обрану команду?",
                MessageBoxButtons.YesNo);
            if (dial == DialogResult.Yes)
            {
                DelTeamFromBase(team);
                MessageBox.Show("Команду видалено!");
                return true;
            }
            return false;
        }

        private void DelTeamFromBase(Team team)
        {
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            com.CommandText = string.Format(@"DELETE FROM teams WHERE id='{0}'",
                team.Id.ToString());
            com.ExecuteNonQuery();
            DelTeamRelationsFromBase(team);
            DelPartisips(team);
            conn.Close();
            Team.Items.Remove(team.Id);
        }

        private void DelTeamRelationsFromBase(Team team)
        {
            SQLiteCommand com = new SQLiteCommand(conn);
            com.CommandText = string.Format(@"DELETE FROM team_relations WHERE team_id='{0}'",
                team.Id.ToString());
            com.ExecuteNonQuery();
            List<Guid> tr_ids = new List<Guid>();
            foreach (TeamRelations tr in TeamRelations.Items.Values)
                if (tr.Team.Equals(team))
                    tr_ids.Add(tr.Id);
            foreach (Guid id in tr_ids)
                TeamRelations.Items.Remove(id);
        }

        private void DelPartisips(Team team)
        {
            List<Guid> toRem = new List<Guid>();
            foreach (Participation particip in Participation.Items.Values)
            {
                if (particip.Team.Equals(team))
                {
                    DeleteParticipsFromBase(particip);
                    toRem.Add(particip.Id);
                }
            }
            foreach (Guid id in toRem)
            {
                List<Guid> srs = new List<Guid>();
                foreach (StageResult sr in Participation.Items[id].Results)
                    srs.Add(sr.Id);
                foreach (Guid sr_id in srs)
                    StageResult.Items.Remove(sr_id);
                Participation.Items.Remove(id);
            }
        }
        private void DeleteParticipsFromBase(Participation part)
        {
            var com = new SQLiteCommand(conn);
            com.CommandText = string.Format(@"DELETE FROM stage_result WHERE participation_id='{0}';",
                part.Id.ToString());
            com.ExecuteNonQuery();
            com.CommandText = string.Format(@"DELETE FROM participations WHERE id='{0}';",
                part.Id.ToString());
            com.ExecuteNonQuery();
        }

        private void DelPartRelFromBase(SQLiteCommand eraser, Guid part_id)
        {
            eraser.CommandText = string.Format(@"DELETE FROM participation_relations WHERE participation_id='{0}'",
                part_id.ToString());
            eraser.ExecuteNonQuery();
        }

        private bool CanDeleteTeam(Team team)
        {
            foreach (Participation part in Participation.Items.Values)
            {
                foreach (Distance dist in this.competitions.Distances)
                {
                    if (part.Distance.Equals(dist))
                    {
                        if (part.Team.Equals(team))
                        {
                            MessageBox.Show(string.Format("Не можна видалити команду, оскільки вона змагається\nна дистанції '{0}'",
                                dist.Name));
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void SaveCompetitionsChanges()
        {
            this.competitions.Date = this.dt_picker.Value;
            var com = new SQLiteCommand(this.conn);
            this.conn.Open();
            com.CommandText = string.Format(@"UPDATE competitions SET date='{0}' WHERE id='{1}';",
                this.competitions.Date.ToString(), this.competitions.Id.ToString());
            com.ExecuteNonQuery();
            this.conn.Close();
        }

        public void Open()
        {
            MainForm.Instance.Controls.Add(this.Panel);
            this.Panel.BringToFront();
        }

        public void Close()
        {
            SaveCompetitionsChanges();
            StageResult.Items.Clear();
            Participation.Items.Clear();
            TeamRelations.Items.Clear();
            Team.Items.Clear();
            MainForm.Instance.Controls.Remove(this.Panel);
        }


    }
}
