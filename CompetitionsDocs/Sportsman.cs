using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsManager
{
    public enum Qualification { b_r ,III_jun, II_jun, I_jun, III, II, I, KMSU, MSU };
    class Sportsman : Base<Sportsman>
    {        
        public DateTime BirthDay { get; set; }
        public Qualification Qualification { get; set; }
        public Team Team
        {
            get
            {
                foreach (TeamRelations tr in TeamRelations.Items.Values)
                    if (tr.Sportsman.Equals(this))
                        return tr.Team;
                return null;
            }
        }
        public Sportsman(string name, DateTime birthDay,Qualification qualification) : base (name)
        {
            this.BirthDay = birthDay;
            this.Qualification = qualification;
        }
        public Sportsman(string name, DateTime birthDay, Qualification qualification,Guid id) : base(name,id)
        {
            this.BirthDay = birthDay;
            this.Qualification = qualification;
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;
            Sportsman x = (Sportsman)obj;
            return this.Name.Equals(x.Name) && this.BirthDay.Equals(x.BirthDay);
        }
        public override string ToString()
        {
            return this.Name + ", " + BirthDay.ToShortDateString() + ", розряд:" + 
                QualToString(this.Qualification);
        }
        public double GetRank()
        {
            double rank = 0;
            switch (this.Qualification)
            {
                case Qualification.III_jun:
                    rank = 0.1;
                    break;
                case Qualification.II_jun:
                    rank = 0.3;
                    break;
                case Qualification.I_jun:
                    rank = 1;
                    break;
                case Qualification.III:
                    rank = 1;
                    break;
                case Qualification.II:
                    rank = 3;
                    break;
                case Qualification.I:
                    rank = 10;
                    break;
                case Qualification.KMSU:
                    rank = 30;
                    break;
                case Qualification.MSU:
                    rank = 100;
                    break;
                default:
                    break;
            }
            return rank;
        }
        public static Qualification ParseQual(string qual)
        {
            switch(qual)
            {
                default:
                    return Qualification.b_r;
                case "ІІІ - юнацький":
                    return Qualification.III_jun;
                case "ІІ - юнацький":
                    return Qualification.II_jun;
                case "І - юнацький":
                    return Qualification.I_jun;
                case "ІІІ":
                    return Qualification.III;
                case "ІІ":
                    return Qualification.II;
                case "І":
                    return Qualification.I;
                case "КМСУ":
                    return Qualification.KMSU;
                case "МСУ":
                    return Qualification.MSU;
            }
        }
        public static string QualToString(Qualification qual)
        {
            switch (qual)
            {
                default:
                    return "б/р";
                case Qualification.III_jun:
                    return "ІІІ-юнацький";
                case Qualification.II_jun:
                    return "ІІ-юнацький";
                case Qualification.I_jun:
                    return "І-юнацький";
                case Qualification.III:
                    return "ІІІ";
                case Qualification.II:
                    return "ІІ";
                case Qualification.I:
                    return "І";
                case Qualification.KMSU:
                    return "КМСУ";
                case Qualification.MSU:
                    return "МСУ";
            }
        }
        internal static bool Exist(Sportsman turisto)
        {
            foreach (Sportsman toCheck in Sportsman.Items.Values)
            {
                if (turisto.Equals(toCheck) && !turisto.Id.Equals(toCheck.Id))
                    return true;
            }
            return false;
        }
        public Category Category { get; set; }
    }
}
