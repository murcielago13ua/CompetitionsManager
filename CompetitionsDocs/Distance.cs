using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompetitionsManager
{
    internal class Distance : Base<Distance>
    {
        private double diff = 0;
        public double Dificult {
            get
            {
                double res = 0;
                foreach (Stage st in this.Stages)
                    res += st.Points;
                res += this.IsShortDistance ? (int)Height / 10 : (int)Height / 100;
                diff = res;
                return res;
            }
        }
        public bool IsShortDistance { get; set; }
        public string Type { get; set; }
        private string getClassByStages()
        {
            string res = "";
            string[] temp = { "н\\к","1А", "1Б", "2А", "2Б", "3А" };
            List<string> stage_diffs = temp.ToList();
            string[] classes = { "I","II","III","IV","V" };
            Dictionary<string, int> stages = new Dictionary<string, int>();
            foreach (string key in stage_diffs)
                stages.Add(key, 0);
            Regex regex = new Regex(@"(н\\к|1А|1Б|2А|2Б|3А)"), regex2 = new Regex(@"з самонаведенням");
            int sam_nav = 0;
            foreach (Stage st in this.Stages)
            {
                if(regex.IsMatch(st.Name))
                    stages[regex.Match(st.Name).Value] += 1;
                if (regex2.IsMatch(st.Name)) sam_nav += 1;
            }
            string classByDiff = getClassByDiff();
            res = classByDiff;
            int i = classes.ToList().IndexOf(classByDiff);
            while (i > 1)
            {
                if (checkClass(stages, sam_nav, res)) break;
                res = classes[--i];
            }
            return res;
        }
        private string getClassByDiff()
        {
            double difficult = this.Dificult;
            if (difficult >= 20 && difficult < 35)
                return "I";
            else if (difficult >= 35 && difficult < 50)
                return "II";
            else if (difficult >= 50 && difficult < 70)
                return "III";
            else if (difficult >= 70 && difficult < 100)
                return "IV";
            else if (difficult >= 100)
                return "V";
            return "";
        }
        public string Class
        {
            get
            {
                return getClassByStages();
            }
        }
        private bool checkClass(Dictionary<string,int> stages,int sam_nav, string klass)
        {
            int a3 = stages["3А"], b2 = stages["2Б"], a2 = stages["2А"], b1 = stages["1Б"], a1 = stages["1А"];
            switch (klass)
            {                
                case "V":
                    if (a3 + b2 >= 4 && a3 >= 2 && sam_nav >= 5)
                        return true;
                    return false;
                case "IV":
                    if (a3 + b2 >= 3 && a3 >= 1 && sam_nav >= 4)
                        return true;
                    return false;
                case "III":
                    if (a3 + b2 + a2 >= 3 && a3 + b2 >=2 && sam_nav >=3)
                        return true;
                    return false;
                case "II":
                    if (a3 + b2 + a2 + b1 >= 3 && a3 + b2 + a2 >= 2 && sam_nav >=2)
                        return true;
                    return false;
                default:
                    return true;
            }
        }
        public short TeammatesCount { get; set; }
        public int Lenght { get; set; }
        public int Height { get; set; }
        public int PenaltyPrice { get; set; }
        public IEnumerable<Competitions> Competitions
        {
            get
            {
                foreach (DistToCompetitionsRelations dtcr in DistToCompetitionsRelations.Items.Values)
                    if (dtcr.Distance.Equals(this))
                        yield return dtcr.Competitions;
            }
        }
        public List<Stage> Stages { get; private set; }
        
        public Distance(string name, string distanceType, List<Stage> stages, short teammatesCount) : base(name)
        {
            this.Name = name;
            this.Type = distanceType;
            this.TeammatesCount = teammatesCount;
            this.IsShortDistance = !this.Type.Equals("Крос-похід?");
            this.Stages = new List<Stage>();
            foreach (Stage stage in stages)
            {
                stage.Dist_id = this.Id;
                Stages.Add(stage);
            }
        }       
        public Distance(string name, string distanceType, List<Stage> stages, short teammatesCount, Guid guid) : base(name, guid)
        {
            this.Name = name;
            this.Type = distanceType;
            this.TeammatesCount = teammatesCount;
            this.IsShortDistance = !this.Type.Equals("Крос-похід?");
            this.Stages = new List<Stage>();
            foreach (Stage stage in stages)
            {
                stage.Dist_id = this.Id;
                Stages.Add(stage);
            }
        }
        public override string ToString()
        {
            string a = getClassByStages();
            string long_short = this.IsShortDistance ? "Кор. дист." : "Довга дист.";
            if (!this.Type.Equals("Рятувальні роботи")) long_short = "";
            string t = "";
            switch(this.Type)
            {
                case "Командна смуга перешкод":
                    t = "ком. смуга";
                    break;
                case "Особиста смуга перешкод":
                    t = "особиста смуга";
                    break;
                case "Рятувальні роботи":
                    t = "рят. роботи";
                    break;
                default:
                    t = this.Type.ToLower();
                    break;
            }
            return long_short + " " + t + " '" + this.Name + "'" + string.Format(" {0} клас({1} балів)", this.Class == "" ? "<?>" : this.Class,
                this.Dificult);
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;
            Distance x = (Distance)obj;
            return x.Name.Equals(this.Name);
        }
        public void CopyFrom(Distance dist)
        {
            this.Type = dist.Type;
            this.TeammatesCount = dist.TeammatesCount;
            this.IsShortDistance = dist.IsShortDistance;
        }
    }
}
