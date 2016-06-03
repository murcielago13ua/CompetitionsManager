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
    internal partial class ParticipPropForm : Form
    {
        public ParticipPropForm(Participation participation)
        {
            InitializeComponent();
            this.participation = participation;
            LoadForm();
        }

        private Participation participation;

        private void LoadForm()
        {
            this.participNameLabel.Text = string.Format("Заявка команди '{0}'", this.participation.Team.Name);
            this.teamRancLabel.Text = string.Format("Ранг команди: {0}",this.participation.TuristosTotalRank.ToString());
            this.participantsListBox.DataSource = this.participation.Participants;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
