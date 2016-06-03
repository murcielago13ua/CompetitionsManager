using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsManager
{
    internal class Team : Base<Team>
    {
        public string CoachName { get; set; }
        private Guid comp_id;
        public Competitions Competitions { get { return Competitions.Items[this.comp_id]; } }
        public IEnumerable<Sportsman> Teammates
        {
            get
            {
                foreach (TeamRelations tr in TeamRelations.Items.Values)
                    if (this.Equals(tr.Team))
                        yield return tr.Sportsman;
            }
        }        
        public Team(string teamName, string coachName, List<Sportsman> turistos, Guid competitions_id) : base(teamName)
        {
            this.CoachName = coachName;
            this.comp_id = competitions_id;
            foreach (Sportsman sportsman in turistos)
                new TeamRelations(this, sportsman);
        }
        public Team(string teamName, string coachName, List<Sportsman> turistos, Guid competitions_id, Guid id) : base(teamName,id)
        {
            this.CoachName = coachName;
            this.comp_id = competitions_id;
            foreach (Sportsman sportsman in turistos)
                new TeamRelations(this, sportsman);
        }
        public bool RemoveTeammate(Sportsman turisto)
        {
            Guid toRem = turisto.Id;
            foreach (TeamRelations tr in TeamRelations.Items.Values)
                if (tr.Sportsman.Equals(turisto))
                    toRem = tr.Id;
            if (!toRem.Equals(turisto.Id))
            {
                TeamRelations.Items.Remove(toRem);
                return true;
            }
            return false;
        }
        public void AddTeammate(Sportsman turisto)
        {
            new TeamRelations(this, turisto);
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;
            Team x = (Team)obj;
            return this.Name.Equals(x.Name) && this.CoachName.Equals(x.CoachName);
        }
        public override string ToString()
        {
            return Name + ", тренер: " + CoachName;
        }
    }
}
