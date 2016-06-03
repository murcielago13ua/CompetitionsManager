using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace CompetitionsManager
{
    class BaseExcelDocCreator
    {
        protected BaseExcelDocCreator() { }
        protected void SetCellStyle(Excel.Range workcell, string value, string font_name, int size, int orientation, bool bold = false)
        {
            workcell.Font.Name = font_name;
            workcell.Font.Size = size;
            workcell.Font.Bold = bold ? 1 : 0;
            if (bold) workcell.Interior.ColorIndex = 4;
            workcell.Orientation = orientation;
            workcell.Value2 = value;
            workcell.Borders.ColorIndex = 1;
            workcell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            workcell.Borders.Weight = Excel.XlBorderWeight.xlThin;
        }
    }
}
