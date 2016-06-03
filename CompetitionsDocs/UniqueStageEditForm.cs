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
    internal partial class UniqueStageEditForm : Form
    {
        public UniqueStageEditForm()
        {
            InitializeComponent();
        }

        public Stage stage;

        private void createStBtn_Click(object sender, EventArgs e)
        {
            if (stNameTBox.Text != "" && stPointsTBox.Text != "")
            {
                try
                {
                    string name = "*"+stNameTBox.Text;
                    double points = double.Parse(stPointsTBox.Text);
                    this.stage = Stage.UniqueStage(name, points, 0);
                    stNameTBox.ResetText();
                    stPointsTBox.ResetText();
                    MessageBox.Show("Етап створено!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch(FormatException)
                {
                    MessageBox.Show("В полях \"Бальна оцінка етапу\" та  \"Довжина етапу\"\n повинні бути додатні числа!");
                }
                catch(OverflowException)
                {
                    MessageBox.Show("Занадто великі числа!");
                }
            }
            else
                MessageBox.Show("Введіть необхідні дані!");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
