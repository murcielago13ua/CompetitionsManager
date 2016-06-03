using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsManager
{
    class DistToCompetitionsRelations : Base<DistToCompetitionsRelations>
    {
        private Guid _distId;
        public Distance Distance
        {
            get { return Distance.Items[_distId]; }
            set { _distId = value.Id; }
        }

        private Guid _competitionsId;
        public Competitions Competitions
        {
            get { return Competitions.Items[_competitionsId]; }
            set { _competitionsId = value.Id; }
        }

        public DistToCompetitionsRelations(Competitions competitions, Distance dist)
        {
            this.Competitions = competitions;
            this.Distance = dist;
        }
    }
}
