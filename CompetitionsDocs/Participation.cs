using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsManager
{
    internal class Participation : Base<Participation>
    {
        internal class Comparer : IComparer<Participation>
        {
            public Comparer() { }
            public int Compare(Participation some, Participation other)
            {
                TimeSpan some_ft = some.FullTime, other_ft = other.FullTime;
                if (some_ft.Equals(other_ft))
                {
                    int some_pens = some.TotalPenalties, other_pens = other.TotalPenalties;
                    if (some_pens == other_pens) return 0;
                    if (some_pens > other_pens) return 1;
                    return -1;
                }
                if (some_ft > other_ft) return 1;
                return -1;
            }
        }
        internal class ReverseComparer : IComparer<Participation>
        {
            public ReverseComparer() { }
            public int Compare(Participation some, Participation other)
            {
                TimeSpan some_ft = some.FullTime, other_ft = other.FullTime;
                if (some_ft.Equals(other_ft))
                {
                    int some_pens = some.TotalPenalties, other_pens = other.TotalPenalties;
                    if (some_pens == other_pens) return 0;
                    if (some_pens > other_pens) return 1;
                    return -1;
                }
                if (some_ft > other_ft) return -1;
                return 1;
            }
        }
        public List<Sportsman> Participants { get; private set; }
        public double TuristosTotalRank
        {
            get
            {
                double rank = 0;
                foreach (Sportsman turisto in this.Participants)
                    rank += turisto.GetRank();
                return Math.Round(rank * 4 / this.Participants.Count, 2);
            }
        }
        public List<StageResult> Results { get; set; }
        public TimeSpan FullTime
        {
            get
            {
                TimeSpan res = new TimeSpan(0, 0, 0, 0, 0);
                foreach (StageResult sr in this.Results)
                    res += TimeSpan.Parse(sr.GetFullTime());
                res += TimeSpan.FromSeconds(this.DistPenalties * Distance.PenaltyPrice);
                return res;
            }
        }
        private Guid distId;
        public Distance Distance
        {
            get { return Distance.Items[distId]; }
            set { distId = value.Id; }
        }
        private Guid teamId;
        public int DistPenalties { get; set; }
        public int TotalPenalties
        {
            get
            {
                int res = DistPenalties;
                foreach (StageResult sr in this.Results)
                    res += sr.Penalties;
                return res;
            }
        }
        public Team Team
        {
            get
            {
                if (Team.Items.ContainsKey(this.teamId))
                    return Team.Items[this.teamId];
                return null;
            }
        }

        public Participation(Guid teamId,List<Sportsman> participants, Distance distance) : base("")
        {
            this.Participants = new List<Sportsman>();
            this.Participants.AddRange(participants);
            this.Distance = distance;
            this.teamId = teamId;
            this.Results = new List<StageResult>();
        }

        public Participation(Guid teamId, List<Sportsman> participants, Distance distance, Guid id) : base("",id)
        {
            this.Participants = new List<Sportsman>();
            this.Participants.AddRange(participants);
            this.Distance = distance;
            this.teamId = teamId;
            this.Results = new List<StageResult>();
        }

        public void AddParticipant(Sportsman turisto)
        {
            this.Participants.Add(turisto);
        }

        public override string ToString()
        {
            return string.Format("{0}, ранг команди:{1}", this.Team.Name, this.TuristosTotalRank);
        }

        public StageResult this[Guid stage_id]
        {
            get
            {
                foreach (StageResult sr in this.Results)
                    if (sr.Stage.Id.Equals(stage_id))
                        return sr;
                return null;
            }
        }
    }
}
