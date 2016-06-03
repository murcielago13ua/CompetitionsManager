using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompetitionsManager
{
    internal partial class DistPropertiesForm : Form
    {
        public DistPropertiesForm(Distance distance)
        {
            InitializeComponent();
            this.distance = distance;
            LoadForm();
        }
        private Distance distance;

        private void LoadForm()
        {
            this.distNameLabel.Text = string.Format("Назва : '{0}'", this.distance.Name);
            this.distType_ClassLabel.Text = string.Format("{0}{1} {2}-го класу", this.distance.Type,
                this.distance.Type.Equals("Рятувальні роботи") ? (this.distance.IsShortDistance ?
                "(коротка дист.)" : "довга дист.") : "", this.distance.Class);
            this.teammatesCountLabel.Text = string.Format("К-сть учасників: {0}", 
                this.distance.TeammatesCount.ToString());
            this.distStagesListBox.DataSource = distance.Stages;
            this.distHeightLabel.Text = string.Format("Набір висоти: {0} м", this.distance.Height.ToString());
            this.distLenghtLabel.Text = string.Format("Довжина: {0} м", this.distance.Lenght.ToString());
            this.penPriceLabel.Text = string.Format("Ціна штрафного бала: {0} c",this.distance.PenaltyPrice.ToString());
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
