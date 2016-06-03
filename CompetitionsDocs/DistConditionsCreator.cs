using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace CompetitionsManager
{
    class DistConditionsCreator
    {
        private string filename;
        private Distance dist;
        public DistConditionsCreator(string filename, Distance dist)
        {
            this.filename = filename;
            this.dist = dist;
        }
        private void TypeStagesInfo(Word.Selection sel, Distance dist)
        {
            int i = 1;
            foreach (Stage stage in dist.Stages)
            {
                sel.Font.Bold = 1;
                sel.TypeText(string.Format("{0}. {1}, довжина {2} м ({3} б)", i, stage.Name, stage.Lenght, stage.Points));
                sel.TypeParagraph();
                sel.Font.Bold = 0;
                sel.TypeText("Опис етапу:");
                sel.TypeParagraph();
                sel.TypeParagraph();
                i++;
            }
        }
        private void TypeDistInfo(Word.Selection sel, Distance dist)
        {
            sel.Font.Name = "Times New Roman";
            sel.Font.Size = 16;
            sel.Font.Bold = 1;
            sel.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            sel.TypeText(string.Format("{0} '{1} {2}'", dist.IsShortDistance ? "Коротка дистанція" : "Довга дистанція",
                dist.Type.ToLower(), dist.Name));
            sel.TypeParagraph();
            sel.TypeText("Загальні положення");
            sel.TypeParagraph();
            sel.Font.Size = 14;
            sel.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            sel.Font.Bold = 0;
            sel.TypeText(string.Format("1. Клас дистанції - {0} ({1} б)", dist.Class, dist.Dificult));
            sel.TypeParagraph();
            sel.TypeText(string.Format("2. Довжина - {0} м", dist.Lenght));
            sel.TypeParagraph();
            sel.TypeText(string.Format("3. Набір висоти - {0} м", dist.Height));
            sel.TypeParagraph();
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("з самонаведенням");
            int j = 0;
            foreach (Stage st in dist.Stages)
                if (regex.IsMatch(st.Name)) j++;
            sel.TypeText(string.Format("4. Кількість етапів - {0}, з них із самонаведенням - {1}", dist.Stages.Count, j));
            sel.TypeParagraph();
            TypeStagesInfo(sel, dist);
        }

        public void CreateDoc()
        {
            Word.Application ap = new Word.Application();
            try
            {
                Word.Document doc = ap.Documents.Open(filename, ReadOnly: false, Visible: false);
                doc.Activate();

                Word.Selection sel = ap.Selection;

                if (sel != null)
                {
                    if (sel.Type.Equals(Word.WdSelectionType.wdSelectionIP))
                    {
                        TypeDistInfo(sel, dist);
                    }
                    else
                        Console.WriteLine("Selection type not handled; no writing done");

                    // Remove all meta data.
                    doc.RemoveDocumentInformation(Word.WdRemoveDocInfoType.wdRDIAll);

                    ap.Documents.Save(NoPrompt: true, OriginalFormat: true);
                }
                else
                {
                    Console.WriteLine("Unable to acquire Selection...no writing to document done..");
                }

                ap.Documents.Close(SaveChanges: false, OriginalFormat: false, RouteDocument: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Caught: " + ex.Message); // Could be that the document is already open (/) or Word is in Memory(?)
            }
            finally
            {
                ((Word._Application)ap).Quit(SaveChanges: false, OriginalFormat: false, RouteDocument: false);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ap);
                System.GC.Collect();
                MessageBox.Show("Файл збережено");
            }
        }
    }
}
