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
    internal partial class CatAddForm : Form
    {
        public CatAddForm(bool subCategory = false)
        {
            InitializeComponent();
            if(subCategory)
            {
                this.label1.Text = "Назва підкатегорії";
                this.createBtn.Text = "Створити підкатегорію";
            }
        }
        public CatAddForm(Category toEdit)
        {
            InitializeComponent();
            this.toEdit = toEdit;
            this.createBtn.Text = "Зберегти зміни";
            this.oldName = toEdit.Name;
            this.nameTextBox.Text = toEdit.Name;
        }

        private Category toEdit;
        private string oldName;
        internal string category_name;

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "")
            {
                this.category_name = nameTextBox.Text;
                if (toEdit == null)
                    this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Введіть назву!");
        }

        private void CatAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.toEdit != null)
            {
                DialogResult dialRes = MessageBox.Show("Зберегти зміни?", "Підтвердження", MessageBoxButtons.YesNo);
                if (dialRes == DialogResult.No) { this.toEdit.Name = oldName; this.DialogResult = DialogResult.Cancel; }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Зміни збережено!");
                }
            }
        }
    }
}
