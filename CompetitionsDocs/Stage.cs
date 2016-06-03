using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CompetitionsManager
{
    internal class Stage : Base<Stage>
    {
        public static string[] simpleStages =
        {
            "Навісна переправа через яр", "Навісна переправа через річку",
            "Переправа по колоді через яр","Переправа по колоді через річку",
            "Крутопохила переправа вниз","Крутопохила переправа вгору","Переправа по вірьовці з перилами",
            "Підйом по схилу","Спуск по схилу","Підйом по вертикальних перилах","Спуск по вертикальних перилах",
            "Підйом по скельній ділянці","Траверс схилу","Траверс скельної ділянки",
            "Подолання перешкоди з використанням маятникової мотузки",
            "Рух по жердинах", "Рух по купинах","Переправа через річку вбрід",
            "Транспортування потерпілого","Переправа на плавзасобах",
        };

        public static string[] SpecStages = { "В`язання вузлів", "Перша медична допомога (теорія)",
            "Перша медична допомога (практика)","Орієнтування",
            "Топографія","Визначення відстані або висоти","Встановлення намету",
            "Розпалювання багаття","Укладка рюкзака"};
        public Distance Distanse
        {
            get
            {
                if (Dist_id != null && Distance.Items.ContainsKey(this.Dist_id))
                    return Distance.Items[Dist_id];
                return null;
            }
        }
        public short Lenght { get; set; }
        private double points;
        public double Points {
            get{ return points; }
            set{ points = value; }
        }
        public Guid Dist_id { get; set; }
        private Stage() : base()
        {
            Lenght = 0;
            Points = 0;
        }
        public Stage(string name, short len)
        {
            this.Name = name;
            Lenght = len;
            Points = 0;
        }
        public Stage(string name, short len,double points)
        {
            this.Name = name;
            this.Lenght = len;
            this.points = points;
        }
        public Stage(string name, short len, double points, Guid id) : base(name,id)
        {
            this.Lenght = len;
            this.points = points;
        }
        public static Stage UniqueStage(string name, double points , short len)
        {
            Stage res = new Stage();
            res.Name = name;
            res.Points = points;
            return res;
        }
        public static Stage ComboStage(string[] simpleStages, short[] Lens, short[] prepareOps)
        {
            Stage res = new Stage();
            res.Name = "Комбо-етап:";
            bool flag = false;
            int i = 0;
            foreach(string sName in simpleStages)
            {
                res.Name += (!flag ? '"' : '+') + sName+'('+Lens[i]+" м) " + (prepareOps[i++] !=0 ? "(нав.) ": "");
                if (!flag)
                    flag = true;
            }
            res.Name += '"';
            foreach (short l in Lens)
                res.Lenght += l;
            return res;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public static IEnumerable<Stage> GetSimpleStages()
        {
            Stage temp;
            foreach (string name in simpleStages)
            {
                temp = new Stage();
                temp.Name = name;
                yield return temp;
            }
        }
        public static IEnumerable<Stage> GetSpecStages()
        {
            Stage temp;
            foreach(string name in SpecStages)
            {
                temp = new Stage();
                temp.Name = name;
                yield return temp;
            }
        }
        public string ToLongString()
        {
            string Res = this.Name;
            if (!this.Name.Equals("В'язання вузлів") && !this.Name.Equals("Перша медична допомога") &&
                    !this.Name.Equals("Рух по купинах") && this.Lenght > 0)
                Res += " ,довжина:" + this.Lenght + " м";
            else if (this.Name.Equals("Рух по жердинах") && this.Lenght > 0)
                Res += " ,кількість прольотів:" + this.Lenght;
            if (Points > 0)
                Res += string.Format(" ({0} б)", this.Points);
            return Res;
        }
        public static Stage Copy(Stage toCopy)
        {
            Stage res = new Stage();
            res.Lenght = toCopy.Lenght;
            res.Name = toCopy.Name;
            res.Points = toCopy.Points;
            return res;
        }
        public static bool IsSimple(Stage st)
        {
            foreach (Stage simpleStage in Stage.GetSimpleStages())
                if (st.Name.Equals(simpleStage.Name))
                    return true;
            return false;
        }
        public static bool IsSpec(Stage st)
        {
            foreach (Stage simpleStage in Stage.GetSpecStages())
                if (st.Name.Equals(simpleStage.Name))
                    return true;
            return false;
        }
    }
}
