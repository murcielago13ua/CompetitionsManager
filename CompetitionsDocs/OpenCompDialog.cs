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
    public partial class OpenCompDialog : Form
    {
        public OpenCompDialog()
        {
            InitializeComponent();
            this.compComboBox.Items.AddRange(Competitions.Items.Values.ToArray());
            if(this.compComboBox.Items.Count > 0)
                this.compComboBox.SelectedItem = this.compComboBox.Items[0];
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        internal Competitions competition { get; private set; }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.competition = this.compComboBox.SelectedItem as Competitions;
            if (this.competition == null) this.DialogResult = DialogResult.Cancel;
            else this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
