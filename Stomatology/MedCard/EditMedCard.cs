using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Word = Microsoft.Office.Interop.Word;


namespace Stomatology
{
    public partial class EditMedCard : Form
    {
        SqlConnection testCon = new SqlConnection
       (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Properties.Settings.Default.DateBaseDirection);

        Main ownerForm = null;
        public EditMedCard(Main ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }

        private void EditPatient_Load(object sender, EventArgs e)
        {

        }

        private void saveToWordFile()
        {
            try
            {
                rewriteInfo(@Properties.Settings.Default.NewMedCardFile);    
            }
            catch
            {
                string message = "Виникли проблеми при спробі зберегти інформацію у вже існуючий файл. Бажаєте вказати шлях?";
                string caption = "Проблема при редагуванні.";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {

                    openFileDialog1.Filter = ".docx file (*.docx)|*.docx";
                    openFileDialog1.FilterIndex = 1;
                    openFileDialog1.Multiselect = false;

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string sFileName = openFileDialog1.FileName;
                        Properties.Settings.Default.ExistMedCardFile = sFileName;
                        if (Properties.Settings.Default.ExistMedCardFile != null)
                        {
                            MessageBox.Show("Успішно збережено!");
                            rewriteInfo(@Properties.Settings.Default.ExistMedCardFile);
                        }
                    }
                }
                if(result == DialogResult.No)
                {
                    this.Close();
                }
            }
        }

        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
            //range.Font.ColorIndex = Word.WdColorIndex.wdBlack; Color
        }
        private void rewriteInfo(string way)
        {
            var name = txtName.Text;
            var dateOfBirthday = txtDateOfBirthday.Text;
            var phoneNumber = txtNumber.Text;
            var address = txtAddress.Text;
            var dateOfCreating = dtpDateOfCreating.Text;
            var gender = txtGender.Text;
            var diagnosis = txtDiagnosis.Text;
            var complaints = txtComplaints.Text;
            var doneDiseas = txtDoneDiseases.Text;
            var currentDiseas = txtCurrentDisease.Text;
            var survayData = txtSurvayData.Text;
            var bite = txtBite.Text;
            var mouthState = txtMouthState.Text;
            var xRayData = txtXReyData.Text;
            var colorVite = txtColorVita.Text;
            var dateOfLessons = txtDateOfLessons.Text;
            var controlDate = txtControlDate.Text;
            var survayPlan = txtSurvayPlan.Text;
            var treatmentPlan = txtTreatmentPlan.Text;


            var wordApp = new Word.Application();
            wordApp.Visible = false;

            var wordDocument = wordApp.Documents.Open((string)way);

            ReplaceWordStub("{name}", name, wordDocument);
            ReplaceWordStub("{dateOfBirthday}", dateOfBirthday, wordDocument);
            ReplaceWordStub("{phoneNumber}", phoneNumber, wordDocument);
            ReplaceWordStub("{address}", address, wordDocument);
            ReplaceWordStub("{dateOfCreating}", dateOfCreating, wordDocument);
            ReplaceWordStub("{s}", gender, wordDocument);
            ReplaceWordStub("{diagnosis}", diagnosis, wordDocument);
            ReplaceWordStub("{complaint}", complaints, wordDocument);
            ReplaceWordStub("{doneDiseases}", doneDiseas, wordDocument);
            ReplaceWordStub("{currentDiseas}", currentDiseas, wordDocument);
            ReplaceWordStub("{survayData}", survayData, wordDocument);
            ReplaceWordStub("{bite}", bite, wordDocument);
            ReplaceWordStub("{mouthState}", mouthState, wordDocument);
            ReplaceWordStub("{xReyDate}", xRayData, wordDocument);
            ReplaceWordStub("{colorVita}", colorVite, wordDocument);
            ReplaceWordStub("{dateOfLessons}", dateOfLessons, wordDocument);
            ReplaceWordStub("{controlDate}", controlDate, wordDocument);
            ReplaceWordStub("{survayPlan}", survayPlan, wordDocument);
            ReplaceWordStub("{treatmentPlan}", treatmentPlan, wordDocument);

            wordDocument.SaveAs(@Properties.Settings.Default.Name + "\\" + name + ".docx");
            MessageBox.Show("Успішно експортовано!!!");

            wordApp.ActiveDocument.Close();
            wordApp.Quit();
        }
        private void SaveAs_Click(object sender, EventArgs e)
        {
            saveToWordFile();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

