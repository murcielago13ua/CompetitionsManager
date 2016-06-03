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
    internal partial class TeamResultForm : Form
    {
        public TeamResultForm(Participation particip)
        {
            InitializeComponent();
            stageResTable.Rows.Clear();
            foreach (StageResult sr in particip.Results)
            {
                stageResTable.Rows.Add(sr.Stage.Name, sr.Time, sr.Penalties, sr.Comment);
            }
            this.particip = particip;
            this.distPenNumUpDown.Value = particip.DistPenalties;
            this.stageResTable.Height = particip.Results.Count * 34;
            this.Height = particip.Results.Count * 50 + 20;
            this.saveBtn.Location = new Point(saveBtn.Location.X, this.stageResTable.Height + 30);
            this.cancelBtn.Location = new Point(cancelBtn.Location.X, this.stageResTable.Height + 30);
            this.label5.Location = new Point(label5.Location.X, this.stageResTable.Height + 34);
            this.distPenNumUpDown.Location = new Point(distPenNumUpDown.Location.X, this.stageResTable.Height + 34);
            this.Text = string.Format("Результати команди '{0}'", this.particip.Team.Name);
        }
        private Participation particip;

        private void checkTime(DataGridViewCellEventArgs e)
        {
            TimeSpan res;
            DataGridViewCell cell = stageResTable.Rows[e.RowIndex].Cells[e.ColumnIndex];
            StageResult sr = this.particip.Results[e.RowIndex];
            if (TimeSpan.TryParse(cell.Value.ToString(), out res))
                sr.Time = res;
            else
                cell.Value = sr.Time;
        }
        private void checkPenalties(DataGridViewCellEventArgs e)
        {
            int pens;
            DataGridViewCell cell = stageResTable.Rows[e.RowIndex].Cells[e.ColumnIndex];
            StageResult sr = this.particip.Results[e.RowIndex];
            if (int.TryParse(cell.Value.ToString(), out pens))
                sr.Penalties = pens;
            else
                cell.Value = sr.Penalties;
        }
        private void checkComments(DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = stageResTable.Rows[e.RowIndex].Cells[e.ColumnIndex];//Комент можна міняти лише з вікна
            cell.Value = this.particip.Results[e.RowIndex].Comment;
        }

        private void stageResTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch(e.ColumnIndex)
            {
                case 1:
                    checkTime(e);
                    break;
                case 2:
                    checkPenalties(e);
                    break;
                default:
                    break;
            }
        }


        internal static string temp_comment = "";
        private void stageResTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DataGridViewCell cell = stageResTable.Rows[e.RowIndex].Cells[e.ColumnIndex];
                temp_comment = cell.Value.ToString();
                new CommentForm(temp_comment).ShowDialog();
                cell.Value = temp_comment;
                this.particip.Results[cell.RowIndex].Comment = temp_comment;
                temp_comment = "";
            }

        }

        private void SaveChangesInBase(SQLiteCommand com, StageResult sr)
        {
            com.CommandText = string.Format(@"UPDATE stage_result SET time='{0}', penalties='{1}', comment='{2}' WHERE id='{3}';",
                sr.Time.ToString(), sr.Penalties.ToString(), sr.Comment, sr.Id.ToString());
            com.ExecuteNonQuery();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.particip.DistPenalties = (int)distPenNumUpDown.Value;
            SQLiteConnection conn = new SQLiteConnection("Data source = base.db");
            SQLiteCommand com = new SQLiteCommand(conn);
            conn.Open();
            com.CommandText = string.Format(@"UPDATE participations SET dist_pens='{0}' WHERE id='{1}';",
                this.particip.DistPenalties, this.particip.Id);
            com.ExecuteNonQuery();
            foreach (StageResult sr in this.particip.Results)
                SaveChangesInBase(com, sr);
            conn.Close();
            MessageBox.Show("Зміни збережено!");
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
