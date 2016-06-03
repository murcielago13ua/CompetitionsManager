using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CompetitionsManager
{
    internal partial class StageParamsForm : Form
    {
        public StageParamsForm(Stage stage)
        {
            InitializeComponent();
            this.stage = stage;
            this.Text = this.stage.Name;
            CreateRegexes();
            this.tur1ParamComBox.DataSource = first_tur_walks;
            this.judjeEqipComBox.DataSource = judje_st_equip;
            this.victimCombBox.DataSource = victim_params;
            foreach (Regex regex in this.regexes)
                if (regex.IsMatch(stage.Name))
                {
                    this.creators[regex].Invoke();
                    this.matched = regex;
                    break;
                }
            
        }

        private string[] first_tur_walks = {"на командній страховці","на самостраховці(або імітація перешкоди)"
                ,"без страховки(суддівські перила)" };
        private string[] judje_st_equip = {"Повністю обладнаний суддями","Суддівські перила",
            "Суддівська страховка(супровід)","Відсутнє обладнання" };
        private string[] victim_params = {"Пасивний","Немає(активний)" };
        private string[] slope_params = { "Простий", "Складний" };
        private string[] rock_params = { "Прості скелі", "Середні/складні скелі" };
        private string[] vertDown_params = { "Нічого", "Перестібування" };
        private string[] timber_params = {"Проста колода","Складна колода","Вкладання колоди" };
        private string[] vb_params = { "Без командної страховки", "З командною страховкою" };
        private string[] victim_transp_params = {"Виготовлення кокона","Виготовлення нош","Суддівські ноші" };
        private string[] ticker_params = { "Присутнє", "Відсутнє" };
        private Stage stage;

        private List<Regex> regexes = new List<Regex>();
        private Regex matched = null;
        private delegate void creator();
        private delegate void parser();
        Dictionary<Regex, creator> creators = new Dictionary<Regex, creator>();
        Dictionary<Regex, parser> parsers = new Dictionary<Regex, parser>();
        private bool tur1changed = false;

        private void CreateRegexes()
        {
            Regex regex = new Regex(@"^Навісна");
            regexes.Add(regex);
            creators.Add(regex, CreateNP);
            parsers.Add(regex, ParseNP);
            regex = new Regex(@"^Крутопохила");
            regexes.Add(regex);
            creators.Add(regex, CreateNP);
            parsers.Add(regex, ParseNP);
            regex = new Regex(@"^(Підйом|Траверс|Спуск)( по | )схилу$");
            regexes.Add(regex);
            creators.Add(regex, CreateSlope);
            parsers.Add(regex, ParseSlope);
            regex = new Regex(@"^(Підйом|Траверс)( по | )скель");
            regexes.Add(regex);
            creators.Add(regex, CreateRock);
            parsers.Add(regex, ParseRock);
            regex = new Regex(@"^Спуск по вертикальних");
            regexes.Add(regex);
            creators.Add(regex, CreateVertDown);
            parsers.Add(regex, ParseVertDown);
            regex = new Regex(@"^Підйом по вертикальних");
            regexes.Add(regex);
            creators.Add(regex, CreateVertUp);
            parsers.Add(regex, ParseVertUp);
            regex = new Regex(@"по колоді");
            regexes.Add(regex);
            creators.Add(regex, CreateTimber);
            parsers.Add(regex, ParseTimber);
            regex = new Regex(@"^Переправа по вірьовці з перилами$");
            regexes.Add(regex);
            creators.Add(regex, CreateNP);
            parsers.Add(regex, ParseNP);
            regex = new Regex(@"вбрід");
            regexes.Add(regex);
            creators.Add(regex, CreateVb);
            parsers.Add(regex, ParseVb);
            regex = new Regex(@"^Транспортування потерпілого$");
            regexes.Add(regex);
            creators.Add(regex, CreateTransVict);
            parsers.Add(regex, ParseTransVict);
            regex = new Regex(@"^Подолання перешкоди [\w]+");
            regexes.Add(regex);
            creators.Add(regex, CreateTicker);
            parsers.Add(regex, ParseTicker);
        }

        private void CreateNP()
        {
            reliefComBox.Enabled = false;
        }
        private void ParseNP()
        {
            if (stage.Lenght > 50)
                return;
            stage.Points = 12;
            AddNpLenghts();
            AddFirstWalk();
            AddJudgeEquip();
            AddVictim();
            AddDiff();
        }
        private void CreateSlope()
        {
            reliefComBox.DataSource = slope_params;
        }
        private void ParseSlope()
        {
            if (reliefComBox.SelectedItem.ToString().Equals("Простий"))
                stage.Points = 4;
            else stage.Points = 6;
            SelStageCat();
            AddFirstWalk();
            AddJudgeEquip();
            AddVictim();
            AddDiff();
        }
        private void CreateRock()
        {
            reliefComBox.DataSource = rock_params;
        }
        private void ParseRock()
        {
            if (reliefComBox.SelectedItem.ToString().Equals("Прості скелі"))
                stage.Points = 10;
            else stage.Points = 12;
            SelStageCat();
            AddFirstWalk();
            AddJudgeEquip();
            AddVictim();
            AddDiff();
        }
        private void CreateVertUp()
        {
            reliefComBox.Enabled = false;
        }
        private void ParseVertUp()
        {
            if (stage.Lenght < 10)
                stage.Points = 8;
            else if (stage.Lenght < 30) stage.Points = 10;
            else
            {
                stage.Points = 0;
                return;
            }
            SelStageCat();
            AddFirstWalk();
            AddJudgeEquip();
            AddVictim();
            AddDiff();
        }
        private void CreateVertDown()
        {
            this.tur1ParamComBox.Enabled = false;
        }
        private void ParseVertDown()
        {
            if (stage.Lenght < 25)
                stage.Points = 8;
            else stage.Points = 10;
            SelStageCat();
            AddJudgeEquip();
            AddVictim();
            AddDiff();
        }
        private void CreateTimber()
        {
            label4.Text = "Параметри етапу:";
            reliefComBox.DataSource = timber_params;
        }
        private void ParseTimber()
        {
            if (reliefComBox.SelectedItem.ToString().Equals("Проста колода"))
                stage.Points = 10;
            else stage.Points = 12;
            SelStageCat();
            AddFirstWalk();
            AddDiff();
        }
        private void CreateVb()
        {
            label1.Text = "Рух учасників:";
            tur1ParamComBox.DataSource = vb_params;
            reliefComBox.Enabled = false;
            judjeEqipComBox.Enabled = false;
        }
        private void ParseVb()
        {
            if (tur1ParamComBox.SelectedItem.ToString().Equals("Без командної страховки"))
                stage.Points = 4;
            else stage.Points = 6;
            SelStageCat();
            AddDiff();
        }
        private void CreateTransVict()
        {
            victimCombBox.DataSource = victim_transp_params;
            tur1ParamComBox.Enabled = false;
            judjeEqipComBox.Enabled = false;
            reliefComBox.Enabled = false;
            difCheckBox.Text = "Надання першої допомоги";
        }
        private void ParseTransVict()
        {
            stage.Name += " 1А";
            if (!victimCombBox.SelectedItem.ToString().Equals("Суддівські ноші"))
                stage.Points = 2;
            stage.Points += stage.Lenght / 50.0;
            if (difCheckBox.Enabled)
                stage.Points += 2;
        }
        private void CreateTicker()
        {
            judjeEqipComBox.DataSource = ticker_params;
            victimCombBox.Enabled = false;
            reliefComBox.Enabled = false;
            difCheckBox.Enabled = false;
        }
        private void ParseTicker()
        {
            if (judjeEqipComBox.SelectedItem.ToString().Equals("Присутнє"))
                stage.Points = 4;
            else stage.Points = 6;
            SelStageCat();
            AddFirstWalk();
            AddDiff();
        }

        private void ParseStage()
        {
            if (this.matched != null)
                this.parsers[matched].Invoke();
            MessageBox.Show("Етап створено!");
        }

        private void AddNpLenghts()
        {
            if (stage.Lenght < 20)
            {
                stage.Name += " 2А";
                stage.Points *= 0.8;
            }
            else if (stage.Lenght >= 30 && stage.Lenght < 40)
            {
                stage.Name += " 3А";
                stage.Points *= 1.2;
            }
            else if (stage.Lenght >= 40)
            {
                stage.Name += " 3А";
                stage.Points *= 1.3;
            }
            else
                stage.Name += " 2Б";
        }

        private void AddFirstWalk()
        {
            switch (tur1ParamComBox.SelectedItem.ToString())
            {
                case "на командній страховці":
                    stage.Points += 2;
                    break;
                case "на самостраховці(або імітація перешкоди)":
                    stage.Points++;
                    break;
                default:
                    break;
            }
        }

        private void AddJudgeEquip()
        {
            switch(judjeEqipComBox.SelectedItem.ToString())
            {
                case "Повністю обладнаний суддями":
                    this.stage.Points *= 0.3;
                    break;
                case "Суддівські перила":
                    this.stage.Points *= 0.5;
                    break;
                case "Суддівська страховка(супровід)":
                    this.stage.Points *= 0.8;
                    break;
                default:
                    stage.Name += "(з самонаведенням)";
                    break;
            }
        }

        private void AddVictim()
        {
            if(victimCombBox.SelectedItem.ToString().Equals("Пасивний"))
            {
                stage.Name += " з потерпілим";
                stage.Points *= 1.2;
            }
        }

        private void AddDiff()
        {
            if (difCheckBox.Checked)
                stage.Points *= 1.2;
        }
        
        private void SelStageCat()
        {
            switch ((int)stage.Points)
            {                                   
                case 4:
                    stage.Name += " 1А";
                    break;
                case 6:
                    stage.Name += " 1Б";
                    break;
                case 8:
                    stage.Name += " 2А";
                    break;
                case 10:
                    stage.Name += " 2Б";
                    break;
                case 12:
                    stage.Name += " 3А";
                    break;
                default:
                    stage.Name += " н/к";
                    break;
            }
        }

        private void completeBtn_Click(object sender, EventArgs e)
        {
            if(Stage.IsSimple(stage))
                ParseStage();
            else if(Stage.IsSpec(stage))
            stage.Points = Math.Round(stage.Points, 2);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void reliefComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reliefComBox.SelectedItem.ToString().Equals("Вкладання колоди"))
            {
                tur1changed = true;
                tur1ParamComBox.SelectedItem = "на командній страховці";
                tur1ParamComBox.Enabled = false;
                judjeEqipComBox.Enabled = false;
            }
            else if(tur1changed)
            {
                tur1changed = false;
                tur1ParamComBox.Enabled = true;
                judjeEqipComBox.Enabled = true;
            }
        }
    }
}
