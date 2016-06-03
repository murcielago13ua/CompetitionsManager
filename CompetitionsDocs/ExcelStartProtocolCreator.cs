using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Windows.Forms;

namespace CompetitionsManager
{
    class ExcelStartProtocolCreator : BaseExcelDocCreator
    {
        private string file_name;
        private List<Participation> particips;
        public ExcelStartProtocolCreator(string file_name, List<Participation> particips) : base()
        {
            this.file_name = file_name;
            this.particips = particips;
        }
        public void CreateLotExcelDoc()
        {
            Excel.Application app = new Excel.Application();
            app.SheetsInNewWorkbook = 1;
            app.Workbooks.Add(Type.Missing);
            Excel.Workbook wbook = app.Workbooks[1];
            try
            {
                Excel.Worksheet eworksheet = wbook.Worksheets[1];
                Excel.Range workcell = (Excel.Range)eworksheet.Cells[1, 1];
                eworksheet.Activate();
                PrintLotTitles(eworksheet, workcell);
                PrintTeamData(eworksheet, workcell);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                try
                {
                    app.DisplayAlerts = false;
                    wbook.Saved = true;
                    wbook.SaveAs(file_name,  //object Filename
      Type.Missing,          //object FileFormat
      Type.Missing,                       //object Password 
      Type.Missing,                       //object WriteResPassword  
      Type.Missing,                       //object ReadOnlyRecommended
      Type.Missing,                       //object CreateBackup
      Excel.XlSaveAsAccessMode.xlNoChange,//XlSaveAsAccessMode AccessMode
      Type.Missing,                       //object ConflictResolution
      Type.Missing,                       //object AddToMru 
      Type.Missing,                       //object TextCodepage
      Type.Missing,                       //object TextVisualLayout
      Type.Missing);                      //object Local
                    wbook.Close(false, Type.Missing, Type.Missing);
                }
                catch (Exception) { }
                app.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                MessageBox.Show("Файл збережено");
                System.GC.Collect();
            }
        }
        private void PrintLotTitles(Excel.Worksheet eworksheet, Excel.Range workcell)
        {
            int j = 1;
            string[] titles = { "Команда", "Тренер", "Прізвише, ім'я\nпо-батькові, д.н.", "Розряд", "Ранг команди", "Стартовий номер" };
            foreach (string title in titles)
            {
                workcell = eworksheet.Cells[1, j++];
                SetCellStyle(workcell, title, "Arial", 14, 0, true);
            }
        }
        private void PrintTeamData(Excel.Worksheet eworksheet, Excel.Range workcell)
        {
            int i = 2;
            Dictionary<int, Participation> lot_res = doLot();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach (int num in lot_res.Keys)
            {
                int j = 1;
                Participation part = lot_res[num];
                workcell = eworksheet.Range["A" + i.ToString(), "A" + (i + part.Participants.Count - 1).ToString()];
                workcell.Merge(Type.Missing);
                SetCellStyle(workcell, part.Team.Name, "Arial", 14, 0);
                workcell = eworksheet.Range["B" + i.ToString(), "B" + (i + part.Participants.Count - 1).ToString()];
                workcell.Merge(Type.Missing);
                SetCellStyle(workcell, part.Team.CoachName, "Arial", 14, 0);
                j += 2;
                foreach (Sportsman turisto in part.Participants)
                {
                    workcell = eworksheet.Cells[i, j];
                    SetCellStyle(workcell, string.Format("{0} ({1})", turisto.Name, turisto.BirthDay.ToShortDateString()),
                        "Arial", 14, 0);
                    workcell = eworksheet.Cells[i, j + 1];
                    SetCellStyle(workcell, Sportsman.QualToString(turisto.Qualification), "Arial", 14, 0);
                    i++;
                }
                j++;
                i -= part.Participants.Count;
                workcell = eworksheet.Range[alphabet[j].ToString() + i.ToString(),
                    alphabet[j].ToString() + (i + part.Participants.Count - 1).ToString()];
                workcell.Merge();
                SetCellStyle(workcell, part.TuristosTotalRank.ToString(), "Arial", 14, 0);
                j++;
                workcell = eworksheet.Range[alphabet[j].ToString() + i.ToString(),
                    alphabet[j].ToString() + (i + part.Participants.Count - 1).ToString()];
                workcell.Merge();
                SetCellStyle(workcell, num.ToString(), "Arial", 16, 0);
                i += part.Participants.Count - 1;
                i += part.Participants.Count > 1 ? part.Participants.Count - 1 : part.Participants.Count;
            }
        }
        private Dictionary<int, Participation> doLot()
        {
            if (this.particips == null) return null;
            Dictionary<int, Participation> starts = new Dictionary<int, Participation>();
            Random rd = new Random();
            foreach (Participation particip in this.particips)
            {
                int rand = 1;
                do { rand = rd.Next(1, this.particips.Count + 1); }
                while (starts.ContainsKey(rand));
                starts.Add(rand, particip);
            }
            return starts;
        }
    }
}
