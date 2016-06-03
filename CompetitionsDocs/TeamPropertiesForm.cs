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
    internal partial class TeamPropertiesForm : Form
    {
        public TeamPropertiesForm(Team team)
        {
            InitializeComponent();
            this.team = team;
            LoadForm();
        }
        private Team team;

        private void LoadForm()
        {
            this.teamNameLabel.Text = string.Format("Назва :'{0}'", this.team.Name);
            this.teamCouchLabel.Text = string.Format("Тренер : {0}", this.team.CoachName);
            this.teammatesListBox.DataSource = this.team.Teammates.ToArray();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
