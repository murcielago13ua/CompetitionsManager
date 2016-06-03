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
    public partial class CommentForm : Form
    {
        public CommentForm(string comment)
        {
            InitializeComponent();
            this.textBox.Text = comment;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            TeamResultForm.temp_comment = this.textBox.Text;
            this.Close();
        }
    }
}
