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
    class ExcelResultCreator : BaseExcelDocCreator
    {
        private string file_name;
        private List<Participation> particips;
        private bool need_full_time = true;
        public ExcelResultCreator(string filename, List<Participation> particips, bool need_full_time = true) : base()
        {
            this.file_name = filename;
            this.particips = particips.ToList();
            this.need_full_time = need_full_time;
        }

        private void PrintTitles(Excel.Worksheet eworksheet, Excel.Range workcell, bool need_full_time)
        {
            string font = "Arial";
            string[] row_titles = { "Команда", "Тренер", "Прізвише, ім'я\nпо-батькові, д.н.", "Розряд", "Ранг команди" };
            int i = 1;
            foreach (string title in row_titles)
            {
                SetCellStyle(workcell, title, font, 12, 0, true);
                workcell = (Excel.Range)eworksheet.Cells[1, ++i];
            }
            foreach (Stage stage in this.particips[0].Distance.Stages)
            {
                SetCellStyle(workcell, stage.Name.Replace(' ', '\n'), font, 12, 90, true);
                workcell = (Excel.Range)eworksheet.Cells[1, ++i];
            }
            SetCellStyle(workcell, "Сума штрафів", font, 12, 90, true);
            if (need_full_time)
            {
                workcell = (Excel.Range)eworksheet.Cells[1, ++i];
                SetCellStyle(workcell, "Час проходження", font, 12, 90, true);
                workcell = (Excel.Range)eworksheet.Cells[1, ++i];
                SetCellStyle(workcell, "Загальний час", font, 12, 90, true);
            }
            workcell = (Excel.Range)eworksheet.Cells[1, ++i];
            SetCellStyle(workcell, "Місце", font, 12, 0, true);

        }
        private void PrintResults(Excel.Worksheet eworksheet, Excel.Range workcell, bool need_full_time, bool need_stage_time)
        {
            int i = 2;
            int place = 1;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach (Participation part in this.particips)
            {
                int j = 1;
                //Дані про команду
                workcell = eworksheet.Range["A" + i.ToString(), "A" + (i + part.Participants.Count - 1).ToString()];
                workcell.Merge(Type.Missing);
                SetCellStyle(workcell, part.Team.Name, "Arial", 14, 0);
                workcell = eworksheet.Range["B" + i.ToString(), "B" + (i + part.Participants.Count - 1).ToString()];
                workcell.Merge(Type.Missing);
                SetCellStyle(workcell, part.Team.CoachName, "Arial", 14, 0);
                j += 2;
                //Вносяться дані про учасників     
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
                //Закінчилися дані про команду
                foreach (StageResult sr in part.Results)//Вносяться результати на етапах
                {
                    workcell = eworksheet.Range[alphabet[j].ToString() + i.ToString(),
                        alphabet[j].ToString() + (i + part.Participants.Count - 1).ToString()];
                    workcell.Merge();
                    string value = need_stage_time ? "Час: " + sr.Time.ToString() + "\n" : "";
                    value += sr.Penalties.ToString();
                    SetCellStyle(workcell, value, "Arial", 14, 0);
                    j++;
                }
                workcell = eworksheet.Range[alphabet[j].ToString() + i.ToString(),
                        alphabet[j].ToString() + (i + part.Participants.Count - 1).ToString()];
                workcell.Merge();
                SetCellStyle(workcell, string.Format("На етапах: {0} \nзагалом: {1}",
                    (part.TotalPenalties - part.DistPenalties).ToString(), part.TotalPenalties.ToString()), "Arial", 14, 0);
                j++;
                if (need_full_time)//Час проходження та загальний час
                {
                    workcell = eworksheet.Range[alphabet[j].ToString() + i.ToString(),
                        alphabet[j].ToString() + (i + part.Participants.Count - 1).ToString()];
                    workcell.Merge();
                    SetCellStyle(workcell, part.Results.Last().GetClearTime(), "Arial", 14, 0);
                    j++;
                    workcell = eworksheet.Range[alphabet[j].ToString() + i.ToString(),
                        alphabet[j].ToString() + (i + part.Participants.Count - 1).ToString()];
                    workcell.Merge();
                    SetCellStyle(workcell, part.FullTime.ToString(), "Arial", 14, 0);
                    j++;
                }
                workcell = eworksheet.Range[alphabet[j].ToString() + i.ToString(),
                        alphabet[j].ToString() + (i + part.Participants.Count - 1).ToString()];
                workcell.Merge();
                SetCellStyle(workcell, place.ToString(), "Arial", 16, 0);
                place++;
                i += part.Participants.Count - 1;
                i += part.Participants.Count > 1? part.Participants.Count - 1 : part.Participants.Count;
            }
        }
        public void CreateResultExcelDoc()
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
                PrintTitles(eworksheet, workcell, need_full_time);
                PrintResults(eworksheet, workcell, need_full_time, !need_full_time);
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
                System.GC.Collect();
                MessageBox.Show("Файл збережено");
            }
        }
    }
}
