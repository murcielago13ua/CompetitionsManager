using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Common;
using System.IO;

namespace CompetitionsManager
{
    internal partial class CompCreationForm : Form
    {
        public CompCreationForm()
        {
            InitializeComponent();            
        }

        public CompCreationForm(Competitions toEdit)
        {
            InitializeComponent();
            this.compDatePicker.Value = toEdit.Date;
            this.oldDate = toEdit.Date;
            this.textBox1.Text = toEdit.Name;
            this.oldName = toEdit.Name;
            this.toEdit = toEdit;
            this.choseBtn.Text = "Зберегти зміни";
        }

        public Competitions competitions;
        private Competitions toEdit;
        private string oldName;
        private DateTime oldDate;

        private void SaveCompetitions(Competitions toSave)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = base.db");
            conn.Open();
            SQLiteCommand command = new SQLiteCommand(conn);
            command.CommandText = string.Format(@"INSERT INTO competitions VALUES('{0}','{1}','{2}');",
                toSave.Id.ToString(),toSave.Name,toSave.Date.ToString());
            command.ExecuteNonQuery();
            foreach(Distance distance in toSave.Distances)
            {
                command.CommandText = string.Format(@"INSERT INTO competitions_to_dist_relations VALUES('{0}','{1}');",
                    toSave.Id.ToString(),distance.Id.ToString());
                command.ExecuteNonQuery();
            }
            conn.Close();
        }

        private void SaveChanges(Competitions toSave)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = base.db");
            conn.Open();
            SQLiteCommand command = new SQLiteCommand(conn);
            command.CommandText = string.Format(@"UPDATE competitions SET name='{0}',date='{1}'",
                toSave.Name,toSave.Date.ToString());
            command.ExecuteNonQuery();
            conn.Close();
        }

        private void choseBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (this.toEdit == null)
                {
                    string name = textBox1.Text;
                    DateTime date = compDatePicker.Value;
                    Competitions comp = new Competitions(name, date);
                    SaveCompetitions(comp);
                    this.competitions = comp;
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Змагання створено!");
                }
                this.Close();
            }
            else
                MessageBox.Show("Введіть назву змагань!");
        }

        private void CompCreationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (toEdit != null && textBox1.Text != "")
            {
                DialogResult dial = MessageBox.Show("Підтвердження", "Зберегти зміни?",
                    MessageBoxButtons.YesNo);
                if (dial == DialogResult.Yes)
                {
                    toEdit.Name = textBox1.Text;
                    toEdit.Date = compDatePicker.Value;
                    SaveChanges(toEdit);
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Зміни збережено!");
                }
                else
                {
                    toEdit.Name = oldName;
                    toEdit.Date = oldDate;
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            this.textBox1.ResetText();
            this.compDatePicker.ResetText();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
