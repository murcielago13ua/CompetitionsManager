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
    class DistancePage : IFormPage
    {
        public Panel Panel { get; private set; }
        private List<Stage> stages = new List<Stage>();
        public List<Stage> Stages { get { return this.stages; } }
        private List<Stage> copies = new List<Stage>();
        public List<Stage> templ_stages = new List<Stage>();
        private Distance distance;
        public Distance LastCreatedDistance { get; private set; }
        private SQLiteConnection conn = new SQLiteConnection("Data source = base.db");
        private bool editMode = false;
        public bool EditMode { get { return this.editMode; } }
        private bool editingEnded = false;
        public void DistanceCreatingMode()
        {
            this.distance = null;
            this.stages = new List<Stage>();
            this.editMode = false;
            this.editingEnded = false;
        }
        public void DistanceEditMode(Distance distance)
        {
            this.distance = distance;
            this.stages = distance.Stages.ToList();
            this.copies = distance.Stages.ToList();
            this.editMode = true;
            this.DelStageRelations(this.distance);
            this.editingEnded = false;
        }
        public DistancePage(Panel panel)
        {
            this.Panel = panel;     
            LoadStages();
        }

        private void LoadStages()
        {
            templ_stages.AddRange(Stage.GetSimpleStages().ToList());
            templ_stages.AddRange(Stage.GetSpecStages().ToList());
            templ_stages.AddRange(LoadUserStages().ToList());
        }

        private IEnumerable<Stage> LoadUserStages()
        {
            SQLiteCommand com = new SQLiteCommand(conn);
            conn.Open();
            com.CommandText = @"SELECT * FROM user_stages";
            DbDataReader reader = com.ExecuteReader();
            foreach (DbDataRecord rec in reader)
            {
                Stage stage = new Stage(rec["name"].ToString(), 0);
                stage.Points = double.Parse(rec["difficult"].ToString());
                yield return stage;
            }
            conn.Close();
        }

        private void DelStageRelations(Distance dist)
        {             
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            com.CommandText = string.Format(@"DELETE FROM stages WHERE [dist_id]='{0}';", dist.Id.ToString());
            com.ExecuteNonQuery();
            conn.Close();
            dist.Stages.Clear();
        }

        public static string[] distTypes =
        {
            "Командна смуга перешкод",
            "Особиста смуга перешкод",
            "Крос-похід",
            "Рятувальні роботи",
        };

        public void MoveUp(Stage stage)
        {
            if (stages.Count < 2) return;
            int index = stages.IndexOf(stage);
            if (index == 0) return;
            Stage temp = stages[index - 1];
            stages[index - 1] = stage;
            stages[index] = temp;
        }

        public void MoveDown(Stage stage)
        {
            if (stages.Count < 2) return;
            int index = stages.IndexOf(stage);
            if (index == stages.Count - 1) return;
            Stage temp = stages[index + 1];
            stages[index + 1] = stage;
            stages[index] = temp;
        }

        public void SaveUserStageInBase(Stage st)
        {
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            com.CommandText = string.Format(@"INSERT INTO user_stages VALUES('{0}',{1})",
                st.Name, st.Points);
            com.ExecuteNonQuery();
            conn.Close();
        }

        public void RemoveUserStageFromBase(Stage st)
        {
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            com.CommandText = string.Format(@"DELETE FROM user_stages WHERE name='{0}' AND difficult={1}",
                st.Name, st.Points);
            com.ExecuteNonQuery();
            conn.Close();
        }

        public bool ParseJ(Stage stage, string text)
        {
            try
            {
                short j_count = short.Parse(text);
                if (j_count < 0)
                {
                    MessageBox.Show("Введіть додатнє число в поле кількості жердин!");
                    return false;
                }
                stage.Lenght = j_count;
                stage.Points += j_count;
                if (j_count > 10)
                    stage.Points = 10;
                stage.Name += " 1Б";
                MessageBox.Show("Етап створено!");
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Введіть кількість жердин!");
                return false;
            }
        }

        public void ParsePlavZas(Stage stage)
        {
            stage.Points = 4;
            stage.Name += " 1А";
            MessageBox.Show("Етап додано!");
        }

        public void ParseKupini(Stage stage)
        {
            stage.Points = 2;
            stage.Name += " н/к";
            MessageBox.Show("Етап додано!");
        }

        public void ParseSpecSt(Stage stage)
        {
            switch (stage.Name)
            {
                default:
                    stage.Points = 1;
                    stage.Name += " н/к";
                    break;
                case "Орієнтування":
                    stage.Points = 2;
                    stage.Name += " 1А";
                    break;
                case "В'язання вузлів":
                    stage.Points = 2;
                    stage.Name += " 1А";
                    break;
                case "Перша медична допомога (практика)":
                    stage.Points = 2;
                    stage.Name += " 1А";
                    break;
                case "Топографія":
                    stage.Points = 2;
                    stage.Name += " 1А";
                    break;
            }
            MessageBox.Show("Етап додано!");
        }

        private bool check_spacu(Distance distance)
        {
            DialogResult dialog_res = MessageBox.Show("Зробити рятувальні роботи довгою дистанцією?", "Тип рятувальних робіт", MessageBoxButtons.YesNo);
            if (dialog_res == DialogResult.Yes)
                distance.IsShortDistance = false;
            else
                distance.IsShortDistance = true;
            System.Text.RegularExpressions.Regex regex =
                new System.Text.RegularExpressions.Regex("(з потерпілим)|(потерпілого)");
            string[] classes = { "III", "IV", "V" };
            int[] mins = { 2, 3, 4 };
            int i = 0;
            foreach (Stage st in distance.Stages)
                if (regex.IsMatch(st.Name)) i++;
            int k = classes.ToList().IndexOf(distance.Class);
            if (k < 0)
            {
                MessageBox.Show("Рятувальні роботи повинні бути не нижче III класу");
                return false;
            }
            if (mins[k] > i)
            {
                string _new_type = distance.IsShortDistance ? "Смуга перешкод" : "Крос-похід";
                MessageBox.Show(string.Format("Для проведення рятувальних робіт даного класу\nнеобхідно додати ще {0} етап(ів) з потерпілим. До тих пір тип дистанції змінюється на \"{1}\"", (mins[k] - i).ToString(), _new_type));
                distance.Type = _new_type;
                //DistTypeLstBox.SelectedItem = _new_type;
            }
            return true;
        }

        public bool EndDistanceEditing(string dist_name,string dist_type, short tmCount,int penaltyPrice,int lenght, int height)
        {            
            if (!this.editMode)
            {
                this.distance = new Distance(dist_name, dist_type, this.stages, tmCount);
                this.distance.PenaltyPrice = penaltyPrice;
                this.distance.Lenght = lenght;
                this.distance.Height = height;
                if (dist_type.Equals("Крос-похід")) this.distance.IsShortDistance = false;
                else this.distance.IsShortDistance = true;
                if (distance.Type.Equals("Рятувальні роботи") && !check_spacu(distance))
                {
                    Distance.Items.Remove(this.distance.Id);
                    this.distance = null;
                    return false;
                }
                SaveInBase(this.distance);                
                this.LastCreatedDistance = this.distance;
            }
            else
            {
                distance.Name = dist_name;
                distance.Type = dist_type;
                distance.TeammatesCount = tmCount;
                distance.PenaltyPrice = penaltyPrice;
                distance.Lenght = lenght;
                distance.Height = height;
                foreach (var stage in this.stages)
                {
                    stage.Dist_id = this.distance.Id;
                    this.distance.Stages.Add(stage);
                }
                if (distance.Type.Equals("Рятувальні роботи") && !check_spacu(distance))
                {
                    this.distance.Stages.Clear();
                    return false;
                }
                SaveChanges(this.distance);
            }
            this.editingEnded = true;
            return true;
        }

        public void CancelDistanceEditing()
        {
            if (this.editMode)
            {
                foreach (Stage st in this.copies)
                    this.distance.Stages.Add(st);
                SaveChanges(this.distance);
            }
            this.editingEnded = true;
        }

        private void SaveInBase(Distance distance)
        {
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            com.CommandText = string.Format(@"INSERT INTO distances VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');",
                distance.Id.ToString(), distance.Name, distance.Type, distance.IsShortDistance.ToString(),
                distance.Dificult.ToString(), distance.Lenght, distance.Height, distance.TeammatesCount, distance.PenaltyPrice);
            com.ExecuteNonQuery();
            foreach (Stage stage in distance.Stages)
            {
                com.CommandText = string.Format(@"INSERT INTO stages VALUES('{0}','{1}','{2}','{3}','{4}');",
                    stage.Id.ToString(), stage.Name, stage.Lenght, stage.Points.ToString(), distance.Id.ToString());
                com.ExecuteNonQuery();
            }
            conn.Close();
        }

        private void SaveChanges(Distance distance)
        {
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            com.CommandText = string.Format(@"UPDATE distances SET name='{0}',type='{1}',is_short='{2}',difficult='{3}',teammates='{4}',len={5},height={6},penalty_price={7} WHERE id='{8}';",
                distance.Name, distance.Type, distance.IsShortDistance.ToString(), distance.Dificult,
                distance.TeammatesCount, distance.Lenght, distance.Height, distance.PenaltyPrice, distance.Id.ToString());
            com.ExecuteNonQuery();
            AddNewStageRelationsInBase(distance);
            conn.Close();
        }

        private void AddNewStageRelationsInBase(Distance distance)
        {
            SQLiteCommand com = new SQLiteCommand(conn);
            foreach (Stage st in distance.Stages)
            {
                com.CommandText = string.Format(@"INSERT INTO stages VALUES('{0}','{1}','{2}','{3}','{4}');",
                    st.Id.ToString(), st.Name, st.Lenght, st.Points.ToString(), distance.Id.ToString());
                com.ExecuteNonQuery();
            }
        }

        public void Open()
        {
            MainForm.Instance.Controls.Add(this.Panel);
            this.Panel.BringToFront();
        }
        public void Close()
        {            
            if (this.editMode && !this.editingEnded)
                this.CancelDistanceEditing();
            this.distance = null;
            this.stages.Clear();
            this.copies.Clear();
            MainForm.Instance.Controls.Remove(this.Panel);
        }
    }
}
