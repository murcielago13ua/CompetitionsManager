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
    internal partial class OpenDistanceDialog : Form
    {
        public OpenDistanceDialog(List<Distance> Items)
        {
            InitializeComponent();
            this.distancesListBox.DataSource = Items.ToList();
        }
        public Distance distance;
        private void okBtn_Click(object sender, EventArgs e)
        {
            var selected = this.distancesListBox.SelectedItem as Distance;
            if(selected == null)
                this.DialogResult = DialogResult.Cancel; 
            else
            {
                this.distance = selected;
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void distPropertiesMBtn_Click(object sender, EventArgs e)
        {
            new DistPropertiesForm(this.distancesListBox.SelectedItem as Distance).ShowDialog();
        }

        private void distancesListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int index = this.distancesListBox.IndexFromPoint(e.Location);
                if (index == -1) return;
                this.distancesListBox.SetSelected(index, true);
                this.contextMenuStrip.Show(this.distancesListBox, e.Location, ToolStripDropDownDirection.Right);
            }
        }
    }
}
