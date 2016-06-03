using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SQLite;

namespace CompetitionsManager
{
    internal partial class CatChangingForm : Form
    {
        public CatChangingForm(Sportsman turisto)
        {
            InitializeComponent();
            this.toTransfer = turisto;
            this.turistoLabel.Text = string.Format("Спортсмен: {0}", this.toTransfer.Name);
            this.currCatTBox.Text = this.toTransfer.Category.Name;
            this.currCatTBox.Enabled = false;
            LoadCategories();
        }

        private void LoadCategories()
        {
            List<Category> cats = new List<Category>();
            foreach (Category cat in Category.Items.Values)
                if (cat.IsLeaf && ! cat.Equals(toTransfer.Category)) cats.Add(cat);
            this.catsComboBox.DataSource = cats;
        }

        private Sportsman toTransfer;

        private void Transfer(Category cat)
        {
            SQLiteConnection conn = new SQLiteConnection("Data source = base.db");
            SQLiteCommand com = new SQLiteCommand(conn);
            conn.Open();
            com.CommandText = string.Format(@"UPDATE turistos SET cat_id='{0}' WHERE id='{1}'",
                cat.Id.ToString(), toTransfer.Id.ToString());
            com.ExecuteNonQuery();
            conn.Close();
            toTransfer.Category = cat;
        }

        private void transferBtn_Click(object sender, EventArgs e)
        {
            Category selected = catsComboBox.SelectedItem as Category;
            if (selected == null) return;
            Transfer(selected);
            MessageBox.Show("Спортсмена переміщено в категорію '" + selected.Name + "'");
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
