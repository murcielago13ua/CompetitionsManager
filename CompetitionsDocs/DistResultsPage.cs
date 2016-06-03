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
    class DistResultsPage : IFormPage
    {
        public Panel Panel { get; private set; }
        private List<Participation> particips;
        public List<Participation> Participations { get { return this.particips; } }
        private Competitions competitions;
        private Distance distance;
        public Distance Distance { get { return this.distance; } }
        public void SetDistance(Competitions competitions, Distance distance)
        {
            this.competitions = competitions;
            this.distance = distance;
            this.particips = new List<Participation>();
            var comp_teams = competitions.Teams.ToArray();
            foreach (var part in Participation.Items.Values)
                if (part.Distance.Equals(this.distance) && comp_teams.Contains(part.Team))
                    this.particips.Add(part);
        }
        public DistResultsPage(Panel panel, Competitions competitions, Distance distance)
        {
            this.Panel = panel;
            SetDistance(competitions, distance);
        }

        public void OpenTeamAddingForm()
        {
            var teamAddingForm = new TeamAddingForm(this.competitions, this.distance);
            teamAddingForm.ShowDialog();
            if (teamAddingForm.participations.Count > 0)
                this.particips.AddRange(teamAddingForm.participations);
        }
        public void ShowTeamResult(Participation particip)
        {
            new TeamResultForm(particip).ShowDialog();
        }
        public void SortResults(bool reverse = false)
        {
            if (!reverse)
                this.particips.Sort(new Participation.Comparer());
            else
                this.particips.Sort(new Participation.ReverseComparer());
        }

        public void Open()
        {
            MainForm.Instance.Controls.Add(this.Panel);
            this.Panel.BringToFront();
        }
        public void Close()
        {
            MainForm.Instance.Controls.Remove(this.Panel);
        }
    }
}
