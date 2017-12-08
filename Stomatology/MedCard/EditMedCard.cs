﻿using System;
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
            cmbPacient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPacient.AutoCompleteSource = AutoCompleteSource.ListItems;

            testCon.Open();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT Name FROM [MedCard]", testCon);
            try
            {
                sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    cmbPacient.Items.Add(Convert.ToString(sqlReader["Name"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null) sqlReader.Close();
            }
            testCon.Close();
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
        }
        private void rewriteInfo(string way)
        {
            var name = cmbPacient.Text;
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
            DateUpdate();
            saveToWordFile();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
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
        private void cmbPacient_SelectedValueChanged(object sender, EventArgs e)
        {
            string query1 = $"SELECT * From MedCard where Name = N'{cmbPacient.Text}'";

            testCon.Open();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand(query1, testCon);
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                lblNumberCard.Text =     sqlReader["MedCard_Id"].ToString();
                txtDateOfBirthday.Text = sqlReader["Birthday"].ToString();
                txtNumber.Text =         sqlReader["Number"].ToString();
                txtAddress.Text =        sqlReader["Adress"].ToString();
                dtpDateOfCreating.Text = sqlReader["DateMC"].ToString();
                txtGender.Text =         sqlReader["State"].ToString();
                txtDiagnosis.Text =      sqlReader["Diagnos"].ToString();
                txtComplaints.Text =     sqlReader["Scarg"].ToString();
                txtDoneDiseases.Text =   sqlReader["PereneseniTaSuputniZahvor"].ToString();
                txtCurrentDisease.Text = sqlReader["RozvutokTeperishnogoZahvor"].ToString();
                txtSurvayData.Text =     sqlReader["DaniObjektDoslidjennya"].ToString();
                txtBite.Text =           sqlReader["Prikus"].ToString();
                txtMouthState.Text =     sqlReader["StanGigiyenuRota"].ToString();
                txtXReyData.Text =       sqlReader["xRayData"].ToString();
                txtDateOfLessons.Text =  sqlReader["DateOfLessons"].ToString();
                txtControlDate.Text =    sqlReader["ControlDate"].ToString();
                txtSurvayPlan.Text =     sqlReader["SurvayPlan"].ToString();
                txtTreatmentPlan.Text =  sqlReader["TreatmentPlan"].ToString();
                txtColorVita.Text      = sqlReader["ColorVita"].ToString();
               
            }
            sqlReader.Close();
            testCon.Close();
        }
        private void DateUpdate()
        {
            try
            {
                if (cmbPacient.Text.Length == 0)
                    throw new Exception("Не вибрана Мед карта, перевірте ще раз!");
                else
                {
                    testCon.Open();
                    string MedCardId = "";
                    string query = $"select * from MedCard where [Name] = N'{cmbPacient.Text}'";
                    SqlCommand cmd1 = new SqlCommand(query, testCon);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        MedCardId = reader["MedCard_Id"].ToString();
                    }
                    else
                    {
                        throw new Exception("Не вибрана дата прийому, перевірте ще раз!");
                    }
                    testCon.Close();

                    string qweryn = 
                        " UPDATE MedCard " + 
                        $" set DateMC = N'{dtpDateOfCreating.Value.Date.ToString("dd/MM/yyyy")}', " +
                    $" Name = N'{cmbPacient.Text}', " + $"State = N'{txtGender.Text}', " + $"Birthday = N'{txtDateOfBirthday.Text}', " +
                    $"Number = N'{txtNumber.Text}', " + $"Adress = N'{txtAddress.Text}', " + $"Diagnos = N'{txtDiagnosis.Text}', " +
                    $"Scarg = N'{txtComplaints.Text}', " + $"PereneseniTaSuputniZahvor =  N'{txtDoneDiseases.Text}', " +
                    $"RozvutokTeperishnogoZahvor = N'{txtCurrentDisease.Text}', " + $"DaniObjektDoslidjennya = N'{txtSurvayData.Text}', " +
                    $"Prikus =  N'{txtBite.Text}', " + $"StanGigiyenuRota = N'{txtMouthState.Text}', " + $"xRayData = N'{txtXReyData.Text}', " +
                    $"ColorVita = N'{txtColorVita.Text}', " + $"DateOfLessons =  N'{txtDateOfLessons.Text}', " + $"ControlDate = N'{txtControlDate.Text}',  " +
                    $"SurvayData = N'{txtSurvayData.Text}', " + $"SurvayPlan = N'{txtSurvayPlan.Text}', " + $"TreatmentPlan =  N'{txtTreatmentPlan.Text}' " +
                    $" where MedCard_Id = '{MedCardId}' ";

                    testCon.Open();
                    SqlCommand upbtn = new SqlCommand(qweryn, testCon);
                    upbtn.ExecuteNonQuery();
                    testCon.Close();
                    MessageBox.Show("Мед карту Редаговано!");
                    Buttonclear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                testCon.Close();
            }
            finally
            {
                //cmbPacient.Text = "";
               // cmbPacient.Items.Clear();
            }
        }
    }
}

