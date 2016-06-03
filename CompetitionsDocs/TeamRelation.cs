using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsManager
{
    class TeamRelations : Base<TeamRelations>
    {
        private Guid _teamId;
        public Team Team
        {
            get { return Team.Items[_teamId]; }
            set { _teamId = value.Id; }
        }

        private Guid _sportsmanId;
        public Sportsman Sportsman
        {
            get { return Sportsman.Items[_sportsmanId]; }
            set { _sportsmanId = value.Id; }
        }

        public TeamRelations(Team team, Sportsman turisto)
        {
            this.Team = team;
            this.Sportsman = turisto;
        }
    }
}
