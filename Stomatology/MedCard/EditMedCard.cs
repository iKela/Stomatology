﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Word = Microsoft.Office.Interop.Word;
using System.Collections;

namespace Stomatology
{
    public partial class EditMedCard : Form
    {
        SqlConnection testCon = new SqlConnection(@"Data Source=insopdentistry.cywgv3xkqj2b.eu-west-3.rds.amazonaws.com;Initial Catalog=Dentistry;Persist Security Info=True;User ID=iKela;Password=6621Nazar");

        ArrayList DateList = new ArrayList();
        ArrayList InfoList = new ArrayList();
        string MedCardId = "";

        public EditMedCard()
        {
            InitializeComponent();
        }

        private void EditPatient_Load(object sender, EventArgs e)
        {
            setTheme();
            //cmbPacient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbPacient.AutoCompleteSource = AutoCompleteSource.ListItems;
            //
            //testCon.Open();
            //SqlDataReader sqlReader = null;
            //SqlCommand command = new SqlCommand("SELECT Name FROM [MedCard]", testCon);
            //try
            //{
            //    sqlReader = command.ExecuteReader();
            //    while (sqlReader.Read())
            //    {
            //        cmbPacient.Items.Add(Convert.ToString(sqlReader["Name"]));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    if (sqlReader != null) sqlReader.Close();
            //}
            //testCon.Close();
        }

        private void setTheme()
        {
            switch (Properties.Settings.Default.Theme)
            {
                case 0:
                    {
                        if (this.BackColor != Color.Black)
                        {
                            this.BackColor = Color.Black;

                            button1.BackColor = Color.White;
                            button2.BackColor = Color.White;
                            button3.BackColor = Color.White;
                            button4.BackColor = Color.White;
                            button5.BackColor = Color.White;
                            button6.BackColor = Color.White;
                            lblNum.ForeColor = Color.White;
                            lblNumberCard.ForeColor = Color.White;
                            lblName.ForeColor = Color.White;
                            lblBirthday.ForeColor = Color.White;
                            lblPhoneNumber.ForeColor = Color.White;
                            lblAddress.ForeColor = Color.White;
                            lblDate.ForeColor = Color.White;
                            lblGender.ForeColor = Color.White;
                            lblGenderType.ForeColor = Color.White;
                        }
                        
                        break;
                    }
                case 1:
                    {
                        if (this.BackColor != Color.CornflowerBlue)
                        {
                            this.BackColor = Color.CornflowerBlue;

                            button1.BackColor = Color.Transparent;
                            button2.BackColor = Color.Transparent;
                            button3.BackColor = Color.Transparent;
                            button4.BackColor = Color.Transparent;
                            button5.BackColor = Color.Transparent;
                            button6.BackColor = Color.Transparent;
                            lblNum.ForeColor = Color.Black;
                            lblNumberCard.ForeColor = Color.Black;
                            lblName.ForeColor = Color.Black;
                            lblBirthday.ForeColor = Color.Black;
                            lblPhoneNumber.ForeColor = Color.Black;
                            lblAddress.ForeColor = Color.Black;
                            lblDate.ForeColor = Color.Black;
                            lblGender.ForeColor = Color.Black;
                            lblGenderType.ForeColor = Color.Black;
                        }
                        break;
                    }
                case 2:
                    {
                        if (this.BackColor != Color.LightGray)
                        {
                            this.BackColor = Color.LightGray;

                            button1.BackColor = Color.Transparent;
                            button2.BackColor = Color.Transparent;
                            button3.BackColor = Color.Transparent;
                            button4.BackColor = Color.Transparent;
                            button5.BackColor = Color.Transparent;
                            button6.BackColor = Color.Transparent;
                            lblNum.ForeColor = Color.Black;
                            lblNumberCard.ForeColor = Color.Black;
                            lblName.ForeColor = Color.Black;
                            lblBirthday.ForeColor = Color.Black;
                            lblPhoneNumber.ForeColor = Color.Black;
                            lblAddress.ForeColor = Color.Black;
                            lblDate.ForeColor = Color.Black;
                            lblGender.ForeColor = Color.Black;
                            lblGenderType.ForeColor = Color.Black;
                        }
                        
                        break;
                    }
                default:
                    {
                        if (this.BackColor != Color.CornflowerBlue)
                        {
                            this.BackColor = Color.CornflowerBlue;

                            button1.BackColor = Color.Transparent;
                            button2.BackColor = Color.Transparent;
                            button3.BackColor = Color.Transparent;
                            button4.BackColor = Color.Transparent;
                            button5.BackColor = Color.Transparent;
                            button6.BackColor = Color.Transparent;
                            lblNum.ForeColor = Color.Black;
                            lblNumberCard.ForeColor = Color.Black;
                            lblName.ForeColor = Color.Black;
                            lblBirthday.ForeColor = Color.Black;
                            lblPhoneNumber.ForeColor = Color.Black;
                            lblAddress.ForeColor = Color.Black;
                            lblDate.ForeColor = Color.Black;
                            lblGender.ForeColor = Color.Black;
                            lblGenderType.ForeColor = Color.Black;
                        }
                        break;
                    }
            }
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
       
        private void rewriteInfo(string way)
        {
            var wordApp = new Word.Application();
            wordApp.Visible = false;

            var wordDocument = wordApp.Documents.Open(way);

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

            int a = 1;
            int i = 0;
            int b = 2;
            while (i < DateList.Count)
            {
                var date = (string)DateList[i];
                var description = (string)InfoList[i];

                ReplaceWordStub("{date1}", date, wordDocument);
                ReplaceWordStub("{description1}", description, wordDocument);
                do
                {
                    replaceDateWord("{date" + a + "}", "{date" + b + "}", wordDocument);
                    replaceDateWord("{description" + a + "}", "{description" + b + "}", wordDocument);
                    a++;
                    b++;
                }while(a <=24 && b <=23);
                i++;
            }

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
            Buttonclear();

            wordApp.ActiveDocument.Close();
            wordApp.Quit();
        }
        private void replaceDateWord(string stubToReplace, string replaceDate, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: replaceDate, ReplaceWith: stubToReplace);
        }
        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            DateUpdate();
            saveToWordFile();
        }
        public void Buttonclear()
        {
            txtDiagnosis.Text = "";
            TopLeftTextBox_1.Text = "";  BotLeftTextBox_8.Text = ""; TopRightTextBox_1.Text = ""; BotRightTextBox_8.Text = "";
            TopLeftTextBox_2.Text = "";  BotLeftTextBox_7.Text = ""; TopRightTextBox_2.Text = ""; BotRightTextBox_7.Text = "";
            TopLeftTextBox_3.Text = "";  BotLeftTextBox_6.Text = ""; TopRightTextBox_3.Text = ""; BotRightTextBox_6.Text = "";
            TopLeftTextBox_4.Text = "";  BotLeftTextBox_5.Text = ""; TopRightTextBox_4.Text = ""; BotRightTextBox_5.Text = "";
            TopLeftTextBox_5.Text = "";  BotLeftTextBox_4.Text = ""; TopRightTextBox_5.Text = ""; BotRightTextBox_4.Text = "";
            TopLeftTextBox_6.Text = "";  BotLeftTextBox_3.Text = ""; TopRightTextBox_6.Text = ""; BotRightTextBox_3.Text = "";
            TopLeftTextBox_7.Text = "";  BotLeftTextBox_2.Text = ""; TopRightTextBox_7.Text = ""; BotRightTextBox_2.Text = "";
            TopLeftTextBox_8.Text = "";  BotLeftTextBox_1.Text = ""; TopRightTextBox_8.Text = ""; BotRightTextBox_1.Text = "";

            txtGender.Text = "";
            txtDateOfBirthday.Text = "";
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
            loadNewAppoiment();
        }
        private void loadNewAppoiment()
        {
            string query1 = $"SELECT * From Reception where MedCard_Id = N'{lblNumberCard.Text}'";
            var Date    = "";
            var Doctor  = "";
            var Info    = "";
            var Money   = "";
            var Arrears = "";
            var tlt1    = "";
            var tlt2    = "";
            var tlt3    = "";
            var tlt4    = "";
            var tlt5    = "";
            var tlt6    = "";
            var tlt7    = "";
            var tlt8    = "";
            var trt1    = "";
            var trt2    = "";
            var trt3    = "";
            var trt4    = "";
            var trt5    = "";
            var trt6    = "";
            var trt7    = "";
            var trt8    = "";
            var brt1    = "";
            var brt2    = "";
            var brt3    = "";
            var brt4    = "";
            var brt5    = "";
            var brt6    = "";
            var brt7    = "";
            var brt8    = "";
                               
            testCon.Open();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand(query1, testCon);
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
               Date =    sqlReader["Date"].ToString();
               Doctor  = sqlReader["Doctor"].ToString();
               Info    = sqlReader["Info"].ToString();
               Money   = sqlReader["Money"].ToString();
               Arrears = sqlReader["Arrears"].ToString();
               tlt1    = sqlReader["tlt1"].ToString();
               tlt2    = sqlReader["tlt2"].ToString();
               tlt3    = sqlReader["tlt3"].ToString();
               tlt4    = sqlReader["tlt4"].ToString();
               tlt5    = sqlReader["tlt5"].ToString();
               tlt6    = sqlReader["tlt6"].ToString();
               tlt7    = sqlReader["tlt7"].ToString();
               tlt8    = sqlReader["tlt8"].ToString();
               trt1    = sqlReader["trt1"].ToString();
               trt2    = sqlReader["trt2"].ToString();
               trt3    = sqlReader["trt3"].ToString();
               trt4    = sqlReader["trt4"].ToString();
               trt5    = sqlReader["trt5"].ToString();
               trt6    = sqlReader["trt6"].ToString();
               trt7    = sqlReader["trt7"].ToString();
               trt8    = sqlReader["trt8"].ToString();
               brt1    = sqlReader["brt1"].ToString();
               brt2    = sqlReader["brt2"].ToString();
               brt3    = sqlReader["brt3"].ToString();
               brt4    = sqlReader["brt4"].ToString();
               brt5    = sqlReader["brt5"].ToString();
               brt6    = sqlReader["brt6"].ToString();
               brt7    = sqlReader["brt7"].ToString();
               brt8    = sqlReader["brt8"].ToString();
                DateList.Add(Date);
                InfoList.Add(Info);


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
                    
                    string query = $"select I from MedCard where [Name] = N'{cmbPacient.Text}'";
                    SqlCommand cmd1 = new SqlCommand(query, testCon);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        MedCardId = reader["Id"].ToString();
                    }
                    else
                    {
                        throw new Exception("Помилка!");
                    }
                    testCon.Close();

                    string qweryn = 
                        " UPDATE MedCard " + 
                        $" set Adress = N'{txtAddress.Text}', " +
                    $" Name = N'{cmbPacient.Text}', " + $"State = N'{txtGender.Text}', " + $"Birthday = N'{txtDateOfBirthday.Text}', " +
                    $"Number = N'{txtNumber.Text}', " + $"DateMC = N'{dtpDateOfCreating.Value.Date.ToString("dd/MM/yyyy")}', " +  $"Diagnos = N'{txtDiagnosis.Text}', " +
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
                
            }
        }
        private void onlyCyrillic(object sender, KeyPressEventArgs e)
        {
            char letter = e.KeyChar;
            if ((letter < 'А' || letter > 'я') && letter != '.' && letter == '\b' && letter == (char)8)
            {
                e.Handled = true;
            }
            
        }

        private void cmbPacient_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyCyrillic(sender, e);
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyCyrillic(sender, e);
        }

        private void txtGender_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void cmbPacient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPacient_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Back && cmbPacient != null)
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

