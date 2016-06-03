using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsManager
{
    class StageResult : Base<StageResult>
    {
        public TimeSpan Time { get; set; }
        public int Penalties { get; set; }
        public string Comment { get; set; }
        public StageResult(Stage stage,TimeSpan time,string comment) : base("")
        {
            this.Stage = stage;
            this.Time = time;
            this.Comment = comment;
        }
        public StageResult(Stage stage, TimeSpan time,string comment, Guid id) : base("",id)
        {
            this.Stage = stage;
            this.Time = time;
            this.Comment = comment;
        }
        public string GetClearTime()
        {
            return this.Time.ToString(@"hh\:mm\:ss");
        }
        public string GetFullTime()
        {
            TimeSpan ts = new TimeSpan(0, 0, 0);
            ts += TimeSpan.FromSeconds(this.Penalties*Stage.Distanse.PenaltyPrice);
            ts += this.Time;
            return ts.ToString(@"hh\:mm\:ss");
        }
        public void AddPenalty(int penalty)
        {
            this.Penalties += penalty;
        }
        public Stage Stage { get; set; }
        public override string ToString()
        {
            return string.Format("{0},результат:'{1}'", this.Stage.Name, this.GetFullTime());
        }
        public string ToLongString()
        {
            return string.Format("{0} , загальний час:'{1}', час проходження:'{2}'\nКоментарі: '{3}'",
                this.Stage.Name, this.GetFullTime(), this.GetClearTime(),this.Comment);
        }
    }
}
