using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CompetitionsManager
{
    [Serializable]
    public class ControlPattern
    {
        internal Color BackColor { get; set; }
        internal Color ForeColor { get; set; }        
        public string BColArgb
        {
            get { return BackColor.ToArgb().ToString(); }
            set { BackColor = Color.FromArgb(int.Parse(value))   ; }
        }
        public string FColArgb
        {
            get { return ForeColor.ToArgb().ToString(); }
            set { ForeColor = Color.FromArgb(int.Parse(value)); }
        }
        public ControlPattern()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
        }
        public ControlPattern(Color bcolor, Color fcolor)
        {
            this.BackColor = bcolor;
            this.ForeColor = fcolor;
        }
        public ControlPattern(Control control)
        {
            this.BackColor = control.BackColor;
            this.ForeColor = control.ForeColor;
        }
    }
}
