using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CompetitionsManager
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try {
                Application.Run(MainForm.Instance); }
            catch(Exception ex) { MessageBox.Show(ex.Message + "\n" + ex.ToString()); }
        }
    }
}
