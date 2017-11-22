using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Stomatology
{
    public partial class Test : Form
    {
        private readonly string TemplateFileName = @"D:\GoogleDrive InSoP\MOSUkraine.doc";
        public Test()
        {
            InitializeComponent();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;

            //TODO: Word Export
            var wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                var wordDocument = wordApp.Documents.Open(TemplateFileName);

                ReplaceWordStub("{name}", name, wordDocument);

                wordDocument.SaveAs(@"D:\result.doc");
                wordApp.Visible = true;
            }
            catch
            {
                MessageBox.Show("Error");
            }

        }

        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }
    }
}
