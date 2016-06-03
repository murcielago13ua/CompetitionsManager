using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsManager
{
    internal class Competitions : Base<Competitions>
    {
        public IEnumerable<Distance> Distances
        {
            get
            {
                foreach (DistToCompetitionsRelations dtcr in DistToCompetitionsRelations.Items.Values)
                    if (dtcr.Competitions.Equals(this))
                        yield return dtcr.Distance;
            }
        }
        public Competitions(string Name,DateTime date) : base(Name)
        {
            this.Date = date;
        }
        public Competitions(string Name, DateTime date, Guid id) : base(Name,id)
        {
            this.Date = date;
        }
        public void AddDistance(Distance distance)
        {
            new DistToCompetitionsRelations(this, distance);
        }
        public short TeammatesCount
        {
            get
            {
                short res = 0;
                foreach (Distance dist in this.Distances)
                    if (dist.TeammatesCount > res)
                        res = dist.TeammatesCount;
                return res;
            }
        }
        public DateTime Date { get; set; }
        public IEnumerable<Team> Teams
        {
            get
            {
                foreach (var team in Team.Items.Values)
                    if (team.Competitions.Equals(this))
                        yield return team;
            }
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;
            Competitions x = (Competitions)obj;
            return this.Name.Equals(x.Name) &&  this.Date.Equals(x.Date);
        }
        public string ToLongString()
        {
            return string.Format("'{0}',дата проведення:'{1}", this.Name, this.Date.ToString());
        }
    }
}
