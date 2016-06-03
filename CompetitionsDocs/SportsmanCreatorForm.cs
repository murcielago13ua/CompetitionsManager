using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompetitionsManager
{
    internal partial class SportsmanCreatorForm : Form
    {

        public SportsmanCreatorForm(Sportsman turisto = null)
        {
            InitializeComponent();
            this.qualCBox.DataSource = qualList;           
            this.turisto = turisto;           
            if (turisto != null)
            {
                this.oldDate = turisto.BirthDay;
                this.oldName = turisto.Name;
                this.editMode = true;
                this.nameTextBox.Text = this.turisto.Name;
                this.bDayPicker.Value = this.turisto.BirthDay;
                this.qualCBox.SelectedItem = Sportsman.QualToString(this.turisto.Qualification);
            }
        }

        private string[] qualList = {"б/р", "ІІІ-юнацький","ІІ-юнацький","І-юнацький","ІІІ","ІІ","І","КМСУ","МСУ"};
        private bool editMode = false;
        private string oldName;
        private DateTime oldDate;
        internal Sportsman turisto;

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (this.nameTextBox.Text != "")
            {
                if (this.editMode)
                {
                    DialogResult dialRes = MessageBox.Show("Зберегти зміни?",
                        "Підтвердження", MessageBoxButtons.YesNo);
                    if (dialRes == DialogResult.No)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                        return;
                    }
                }
                else
                    this.turisto = new Sportsman("", DateTime.Now, Qualification.b_r);
                turisto.Name = this.nameTextBox.Text;
                turisto.BirthDay = this.bDayPicker.Value;
                turisto.Qualification =
                    Sportsman.ParseQual((string)this.qualCBox.SelectedItem);
                if(Sportsman.Exist(turisto))
                {
                    MessageBox.Show("Такий спортсмен вже існує!");
                    turisto.Name = this.oldName;
                    this.nameTextBox.Text = this.oldName;
                    turisto.BirthDay = this.oldDate;
                    this.bDayPicker.Value = this.oldDate;
                    return;
                }
                MessageBox.Show(this.editMode ? "Зміни збережено" : "Спортсмена створено!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Введіть П.І.Б. спортсмена!");
        }
    }
}
