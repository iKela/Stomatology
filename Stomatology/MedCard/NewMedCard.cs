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
    public partial class NewMedCard : Form
    {
        SqlConnection testCon = new SqlConnection
        (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Properties.Settings.Default.DateBaseDirection);



        public NewMedCard(Main ownerform)
        {
            InitializeComponent();

        }

        private void NewPatient_Load(object sender, EventArgs e)
        {

        }

        #region Buttonclear
        public void Buttonclear()
        {
            txtDiagnosis.Text = "";
            TopLeftTextBox_1.Text = "";
            TopLeftTextBox_2.Text = "";
            TopLeftTextBox_3.Text = "";
            TopLeftTextBox_4.Text = "";
            TopLeftTextBox_5.Text = "";
            TopLeftTextBox_6.Text = "";
            TopLeftTextBox_7.Text = "";
            TopLeftTextBox_8.Text = "";
            BotLeftTextBox_8.Text = "";
            BotLeftTextBox_7.Text = "";
            BotLeftTextBox_6.Text = "";
            BotLeftTextBox_5.Text = "";
            BotLeftTextBox_4.Text = "";
            BotLeftTextBox_3.Text = "";
            BotLeftTextBox_2.Text = "";
            BotLeftTextBox_1.Text = "";
            TopRightTextBox_1.Text = "";
            TopRightTextBox_2.Text = "";
            TopRightTextBox_3.Text = "";
            TopRightTextBox_4.Text = "";
            TopRightTextBox_5.Text = "";
            TopRightTextBox_6.Text = "";
            TopRightTextBox_7.Text = "";
            TopRightTextBox_8.Text = "";
            BotRightTextBox_8.Text = "";
            BotRightTextBox_7.Text = "";
            BotRightTextBox_6.Text = "";
            BotRightTextBox_5.Text = "";
            BotRightTextBox_4.Text = "";
            BotRightTextBox_3.Text = "";
            BotRightTextBox_2.Text = "";
            BotRightTextBox_1.Text = "";
   
            txtDateOfBirthday.Text = "";
            txtGender.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtNumber.Text = "";
            txtDiagnosis.Text = "";
            txtComplaints.Text = "";
            txtDoneDiseases.Text = "";
            txtCurrentDisease.Text = "";
            txtSurvayData.Text = "";
            txtBite.Text = "";
            txtMouthState.Text = "";
            txtXReyData.Text = "";
            txtDateOfLessons.Text = "";
            txtControlDate.Text = "";
            txtSurvayData.Text = "";
            txtSurvayPlan.Text = "";
            txtTreatmentPlan.Text = "";
        }
        #endregion

        private void btnSaveAsForOldPatient_Click(object sender, EventArgs e)
        {

        }

        private void saveToWordFile()
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

            try
            {
                var wordDocument = wordApp.Documents.Open(@Properties.Settings.Default.NewMedCardFile);

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
                ReplaceWordStub("{survayData", survayData, wordDocument);
                ReplaceWordStub("{bite}", bite, wordDocument);
                ReplaceWordStub("{mouthState}", mouthState, wordDocument);
                ReplaceWordStub("{xReyDate}", xRayData, wordDocument);
                ReplaceWordStub("{colorVita}", colorVite, wordDocument);
                ReplaceWordStub("{dateOfLessons}", dateOfLessons, wordDocument);
                ReplaceWordStub("{controlDate}", controlDate, wordDocument);
                ReplaceWordStub("{survayPlan}", survayPlan, wordDocument);
                ReplaceWordStub("{treatmentPlan}", treatmentPlan, wordDocument);

                string path = null;
                using (var dialog = new FolderBrowserDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        path = dialog.SelectedPath;
                        Properties.Settings.Default.Name = path;
                        Properties.Settings.Default.Save();
                        wordDocument.SaveAs(@path + "\\" + name + ".docx");
                        MessageBox.Show("Успішно експортовано!!!");
                    }
                }

                wordApp.ActiveDocument.Close();
                wordApp.Quit();
            }
            catch
            {
                string message = "Хибний шлях до екземпляру. Бажаєте задати новий шлях?";
                string caption = "Проблема встановлення зв'язку.";
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
                        Properties.Settings.Default.NewMedCardFile = sFileName;
                        Properties.Settings.Default.Save();
                        if (Properties.Settings.Default.NewMedCardFile != null)
                        {
                            MessageBox.Show("Шлях до екземпляру успішно збережений! Повторіть спробу зберегти вашу інформацію.");
                        }         
                    }
                }
            }
        }

        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveToDataBase();
        }

        private void saveToDataBase()
        {
            try
            {
                if (txtName.Text.Length == 0  || txtNumber.Text.Length == 0 || txtAddress.Text.Length == 0 || txtDateOfBirthday.Text.Length == 0)
                    throw new Exception("Не всі поля заповнені!");
                else
                {

                    testCon.Open();
                    SqlCommand cmd = testCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"INSERT INTO MedCard ( DateMC, Name, State, Birthday, Number, Adress, Diagnos, Scarg, PereneseniTaSuputniZahvor, " +
                        $"RozvutokTeperishnogoZahvor, DaniObjektDoslidjennya, Prikus, StanGigiyenuRota, xRayData, ColorVita, DateOfLessons, ControlDate, " +
                        $"SurvayPlan, TreatmentPlan) " +
                        $"values ( N'{dtpDateOfCreating.Value.Date.ToString("dd/MM/yyyy")}', N'{txtName.Text}',  N'{txtGender.Text}', N'{txtDateOfBirthday.Text}', " +
                        $" N'{txtNumber.Text}', N'{txtAddress.Text}', N'{txtDiagnosis.Text}', N'{txtComplaints.Text}', N'{txtDoneDiseases.Text}', N'{txtCurrentDisease.Text}', " +
                        $" N'{txtSurvayData.Text}', N'{txtBite.Text}', N'{txtMouthState.Text}', N'{txtXReyData.Text}', N'{txtDateOfLessons.Text}', N'{txtControlDate.Text}', " +
                        $" N'{txtSurvayData.Text}', N'{txtSurvayPlan.Text}', N'{txtTreatmentPlan.Text}')";
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Додано нового паціента.");


                    testCon.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                testCon.Close();

            }
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            saveToDataBase();
            saveToWordFile();
        }

        private void NewMedCard_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyCyrillic(sender, e);
        }
        private void onlyCyrillic(object sender, KeyPressEventArgs e)
        {
            char letter = e.KeyChar;
            if ((letter< 'А' || letter> 'я') && letter != '\b' && letter != '.')
            {
                e.Handled = true;
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyCyrillic(sender, e);
        }
    }
}
