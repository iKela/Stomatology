using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace Stomatology
{
    public partial class Main : Form
    {
        SqlConnection testCon = new SqlConnection(@"Data Source=insopdentistry.cywgv3xkqj2b.eu-west-3.rds.amazonaws.com;Initial Catalog=Dentistry;Persist Security Info=True;User ID=iKela;Password=6621Nazar");

        int MHIndex;
        int MLIndex;
        string MedCardId;
        int arrears;
        string text;
        bool numberisthere = false;

        public void PassValue(string strValue)
            //Calculator
        {
            txtMoney.Text = strValue;
        }

        public Main()
        {
            InitializeComponent();
            setTheme();
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
                            pnlRegistry.EndColor = Color.Black;
                            pnlButtons.EndColor = Color.Black;
                            pnlButtons.StartColor = Color.Black;
                            pnlDataGrid.EndColor = Color.Black;
                            pnlDataGrid.StartColor = Color.Black;
                            btn1.EndColor = Color.Black;
                            btn2.EndColor = Color.Black;
                            btn3.EndColor = Color.Black;
                            btn4.EndColor = Color.Black;
                            btn5.EndColor = Color.Black;
                            btn6.EndColor = Color.Black;
                            btn1.StartColor = Color.White;
                            btn2.StartColor = Color.White;
                            btn3.StartColor = Color.White;
                            btn4.StartColor = Color.White;
                            btn5.StartColor = Color.White;
                            btn6.StartColor = Color.White;
                            lblName.ForeColor = Color.White;
                            lblDoc.ForeColor = Color.White;
                            lblDateFrom.ForeColor = Color.White;
                            lblDateTo.ForeColor = Color.White;
                        }

                        break;
                    }
                case 1:
                    {
                        if (this.BackColor != Color.CornflowerBlue)
                        {
                            this.BackColor = Color.CornflowerBlue;
                            pnlRegistry.EndColor = Color.CornflowerBlue;
                            pnlButtons.EndColor = Color.CornflowerBlue;
                            pnlButtons.StartColor = Color.CornflowerBlue;
                            pnlDataGrid.EndColor = Color.CornflowerBlue;
                            pnlDataGrid.StartColor = Color.CornflowerBlue;
                            btn1.EndColor = Color.CornflowerBlue;
                            btn2.EndColor = Color.CornflowerBlue;
                            btn3.EndColor = Color.CornflowerBlue;
                            btn4.EndColor = Color.CornflowerBlue;
                            btn5.EndColor = Color.CornflowerBlue;
                            btn6.EndColor = Color.CornflowerBlue;
                            btn1.StartColor = Color.White;
                            btn2.StartColor = Color.White;
                            btn3.StartColor = Color.White;
                            btn4.StartColor = Color.White;
                            btn5.StartColor = Color.White;
                            btn6.StartColor = Color.White;
                            lblName.ForeColor = Color.Black;
                            lblDoc.ForeColor = Color.Black;
                            lblDateFrom.ForeColor = Color.Black;
                            lblDateTo.ForeColor = Color.Black;
                        }
                        break;
                    }
                case 2:
                    {
                        if (this.BackColor != Color.LightGray)
                        {
                            this.BackColor = Color.LightGray;
                            pnlRegistry.EndColor = Color.DarkGray;
                            pnlButtons.EndColor = Color.LightGray;
                            pnlButtons.StartColor = Color.LightGray;
                            pnlDataGrid.EndColor = Color.LightGray;
                            pnlDataGrid.StartColor = Color.LightGray;
                            btn1.EndColor = Color.DarkGray;
                            btn2.EndColor = Color.DarkGray;
                            btn3.EndColor = Color.DarkGray;
                            btn4.EndColor = Color.DarkGray;
                            btn5.EndColor = Color.DarkGray;
                            btn6.EndColor = Color.DarkGray;
                            btn1.StartColor = Color.White;
                            btn2.StartColor = Color.White;
                            btn3.StartColor = Color.White;
                            btn4.StartColor = Color.White;
                            btn5.StartColor = Color.White;
                            btn6.StartColor = Color.White;
                            lblName.ForeColor = Color.Black;
                            lblDoc.ForeColor = Color.Black;
                            lblDateFrom.ForeColor = Color.Black;
                            lblDateTo.ForeColor = Color.Black;
                        }

                        break;
                    }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip(); 
            //updateTable();
            btnAccount.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnAccountPhoto.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnExit.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void AddNewAppoinment_Click(object sender, EventArgs e)
        {
            NewAppoinment newForm = new NewAppoinment();
            newForm.Show();
        }

        private void EditPatient_Click(object sender, EventArgs e)
        {
            EditMedCard newForm = new EditMedCard();
            newForm.Show();
        }

        private void AddNewPatient_Click(object sender, EventArgs e)
        {
            NewMedCard newForm = new NewMedCard();
            newForm.Show();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Ви впевнені?", "Вихід з програми!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            { Close(); }
            else
            { return; }
        }

        private void проПрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutSoft newForm = new AboutSoft();
            newForm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            functionForbtnUpdate();
        }    

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Data_function();
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            Calculator newForm = new Calculator(this);
            newForm.Show();
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            Settings newForm = new Settings();
            newForm.Show();
        }

        private void tsmiContacts_Click(object sender, EventArgs e)
        {
            HelpContacts newForm = new HelpContacts();
            newForm.Show();
        }

        private void tsmiUserInfo_Click(object sender, EventArgs e)
        {
            UserInfo newForm = new UserInfo();
            newForm.Show();
        }

        private void tsmiRemoteControl_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Settings.Default.TeamViewerDirection);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.DoEvents();
            testCon.Close();
           
        }

        private void toolTip() // Підказки до кнопок та полів
        {
            toolTip1.IsBalloon = false;
            toolTip1.SetToolTip(AddNewPatient, "Додати нового паціента.");
            toolTip1.SetToolTip(EditPatient, "Редагувати дані паціента.");
            toolTip1.SetToolTip(AddNewAppoinment, "Додати новий прийом.");
            toolTip1.SetToolTip(txtBDate, "Відредагуйте, якщо бажаэте змінити дату прийому.");
            if (lblDoctor.Text == string.Empty)
            {
                toolTip1.SetToolTip(lblDoctor, "Поле, де вказуэться лікар, який приймав паціента.");
            }
            else
            {
                toolTip1.SetToolTip(lblDoctor, "На полі вказано лікаря, який приймав паціента.");
            }
            //if (textBox2.Text == string.Empty)
            //{
            //    toolTip1.SetToolTip(textBox2, "Поле, де вказуэться паціент при перегляді або редагуванні прийому.");
            //}
            //else
            //{
               // toolTip1.SetToolTip(textBox2, "На полі вказано паціента який був на прийомі.\nВи маэте можливість редагувати це поле.");
           // }
            toolTip1.SetToolTip(btnCalculator, "Калькулятор.\nСкористайтесь калькулятором, для точного підрахунку ціни наданих послуг.");
            toolTip1.SetToolTip(txtDescription, "Поле для додаткової інформації.");
            toolTip1.SetToolTip(btnUpdate, "Оновити інформацію про паціента.");
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Datetextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 44 || e.KeyChar == 47 || e.KeyChar == 45 || e.KeyChar == 42)
                e.KeyChar = (char)46;
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            report_function();
        } 

        private void button9_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        
        private void сbArrears_CheckedChanged(object sender, EventArgs e)
        {
            Arrears();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbChanels_SelectedIndexChanged(object sender, EventArgs e)
        {
            text = lbChanels.GetItemText(lbChanels.SelectedItem);
        }

        private void lbChanels_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescription.Text += " " + text + " ";
                lbChanels.Visible = false;
                lbChanels.ClearSelected();
                txtDescription.Focus();
                txtDescription.SelectedText += " ";
            }
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == (Keys.P))
            {
                lbChanels.Visible = true;
            }
            else if (e.KeyCode == Keys.T)
            {
                lbChanels.Visible = true;
            }
            else if (e.KeyCode == Keys.Space && lbChanels.Visible == true)
            {
                lbChanels.Focus();
            }
            else
            {
                string[] partNumbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                Regex number = new Regex(@"^[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$");
                foreach (string partNumber in partNumbers)
                {
                    numberisthere = true;
                }
                if (numberisthere == false)
                {
                    lbChanels.Visible = false;
                }
            }
          
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        #region Main----function
        private void Data_function()
        {
            string query1 = $"SELECT * From Reception where  Date = '{comboBox1.Text}'  and IdMedCard = '{MedCardId}'";

            testCon.Open();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand(query1, testCon);
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                lblDoctor.Text =    sqlReader["Doctor"].ToString();
                txtBDate.Text =     sqlReader["Date"].ToString();
                txtDescription.Text = sqlReader["info"].ToString();
                txtMoney.Text = sqlReader["Money"].ToString();
                arrears =       sqlReader["Arrears"].GetHashCode();

                TopLeftTextBox_1.Text = sqlReader["tlt1"].ToString();
                TopLeftTextBox_2.Text = sqlReader["tlt2"].ToString();
                TopLeftTextBox_3.Text = sqlReader["tlt3"].ToString();
                TopLeftTextBox_4.Text = sqlReader["tlt4"].ToString();
                TopLeftTextBox_5.Text = sqlReader["tlt5"].ToString();
                TopLeftTextBox_6.Text = sqlReader["tlt6"].ToString();
                TopLeftTextBox_7.Text = sqlReader["tlt7"].ToString();
                TopLeftTextBox_8.Text = sqlReader["tlt8"].ToString();

                TopRightTextBox_1.Text = sqlReader["trt1"].ToString();
                TopRightTextBox_2.Text = sqlReader["trt2"].ToString();
                TopRightTextBox_3.Text = sqlReader["trt3"].ToString();
                TopRightTextBox_4.Text = sqlReader["trt4"].ToString();
                TopRightTextBox_5.Text = sqlReader["trt5"].ToString();
                TopRightTextBox_6.Text = sqlReader["trt6"].ToString();
                TopRightTextBox_7.Text = sqlReader["trt7"].ToString();
                TopRightTextBox_8.Text = sqlReader["trt8"].ToString();

                BotRightTextBox_8.Text = sqlReader["brt1"].ToString();
                BotRightTextBox_7.Text = sqlReader["brt2"].ToString();
                BotRightTextBox_6.Text = sqlReader["brt3"].ToString();
                BotRightTextBox_5.Text = sqlReader["brt4"].ToString();
                BotRightTextBox_4.Text = sqlReader["brt5"].ToString();
                BotRightTextBox_3.Text = sqlReader["brt6"].ToString();
                BotRightTextBox_2.Text = sqlReader["brt7"].ToString();
                BotRightTextBox_1.Text = sqlReader["brt8"].ToString();

                BotLeftTextBox_8.Text = sqlReader["blt1"].ToString();
                BotLeftTextBox_7.Text = sqlReader["blt2"].ToString();
                BotLeftTextBox_6.Text = sqlReader["blt3"].ToString();
                BotLeftTextBox_5.Text = sqlReader["blt4"].ToString();
                BotLeftTextBox_4.Text = sqlReader["blt5"].ToString();
                BotLeftTextBox_3.Text = sqlReader["blt6"].ToString();
                BotLeftTextBox_2.Text = sqlReader["blt7"].ToString();
                BotLeftTextBox_1.Text = sqlReader["blt8"].ToString();
            }
            sqlReader.Close();
            testCon.Close();
            if (arrears == 1)
            { cbArrears.Checked = true; }
            else { cbArrears.Checked = false; }
        }

        private void Arrears()
        {
            if (cbArrears.Checked == true)
            {
                arrears = 1;
            }
            else
            {
                arrears = 0;
            }
        }

        private void functionForbtnUpdate()
        {
            try
            {
                if (comboBox1.Text.Length == 0 || dataGridView1.SelectedRows.Count == 0)
                    throw new Exception("Не вибрана дата прийому, перевірте ще раз!");
                else
                {
                    testCon.Open();
                    string ReceptionId = "";
                    string query = $"select Id from Reception where [Date] = N'{comboBox1.Text}'";
                    SqlCommand cmd1 = new SqlCommand(query, testCon);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        ReceptionId = reader["Id"].ToString();
                    }
                    else
                    {
                        throw new Exception("Не вибрана дата прийому, перевірте ще раз!");
                    }
                    testCon.Close();


                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        string uId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        string qweryn = "update Reception " + $"set Date = N'{txtBDate.Text}', " + $"Info = N'{txtDescription.Text}', " + $"Money = N'{txtMoney.Text}', " + $"Arrears = N'{arrears}', " +
                             $"tlt1 = N'{TopLeftTextBox_1.Text}', " + $"tlt2 = N'{TopLeftTextBox_2.Text}', " + $"tlt3 = N'{TopLeftTextBox_3.Text}',  " + $"tlt4 = N'{TopLeftTextBox_4.Text}',  " +
                             $"tlt5 = N'{TopLeftTextBox_5.Text}', " + $"tlt6 = N'{TopLeftTextBox_6.Text}',  " + $"tlt7 = N'{TopLeftTextBox_7.Text}',  " + $"tlt8 = N'{TopLeftTextBox_8.Text}', " +
                             $"trt1 = N'{TopRightTextBox_1.Text}', " + $"trt2 = N'{TopRightTextBox_2.Text}', " + $"trt3 = N'{TopRightTextBox_3.Text}', " + $"trt4 = N'{TopRightTextBox_4.Text}', " +
                             $"trt5 = N'{TopRightTextBox_5.Text}', " + $"trt6 = N'{TopRightTextBox_6.Text}', " + $"trt7 = N'{TopRightTextBox_7.Text}', " + $"trt8 = N'{TopRightTextBox_8.Text}'," +
                             $"brt1 = N'{BotRightTextBox_8.Text}', " + $"brt2 = N'{BotRightTextBox_7.Text}', " + $"brt3 = N'{BotRightTextBox_6.Text}', " + $"brt4 = N'{BotRightTextBox_5.Text}', " +
                             $"brt5 = N'{BotRightTextBox_4.Text}', " + $"brt6 = N'{BotRightTextBox_3.Text}', " + $"brt7 = N'{BotRightTextBox_2.Text}', " + $"brt8 = N'{BotRightTextBox_1.Text}', " +
                             $"blt1 = N'{BotLeftTextBox_8.Text}',  " + $"blt2 = N'{BotLeftTextBox_7.Text}',  " + $"blt3 = N'{BotLeftTextBox_6.Text}', " + $"blt4 = N'{BotLeftTextBox_5.Text}', " +
                             $"blt5 = N'{BotLeftTextBox_4.Text}',  " + $"blt6 = N'{BotLeftTextBox_3.Text}', " + $"blt7 = N'{BotLeftTextBox_2.Text}',  " + $"blt8 = N'{BotLeftTextBox_1.Text}' " +
                             $"where Reception_Id = {ReceptionId}";

                        testCon.Open();
                        SqlCommand upbtn = new SqlCommand(qweryn, testCon);
                        upbtn.ExecuteNonQuery();
                        testCon.Close();
                        updateTable();
                        Buttonclear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                testCon.Close();
            }
            finally
            {
                comboBox1.Text = "";
                comboBox1.Items.Clear();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                MedCardId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                comboBox1.Items.Clear();
                Buttonclear();
                testCon.Open();
                SqlDataReader sqlReader = null;
                string qwery = $"SELECT Date FROM [Reception] where IdMedCard = N'{MedCardId}'";
                SqlCommand command = new SqlCommand(qwery, testCon);

                sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    comboBox1.Items.Add(sqlReader["Date"]);
                }

                sqlReader.Close();
                testCon.Close();
            }
        }

        public void updateTable()
        {
            dataGridView1.Rows.Clear();
            testCon.Open();
            string upqwery = "select Id, Name, Birthday, Number from MedCard";
            SqlCommand sqlComm = new SqlCommand(upqwery, testCon);
            SqlDataReader sqlDR;
            sqlDR = sqlComm.ExecuteReader();

            while (sqlDR.Read())
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = sqlDR[0];
                dataGridView1.Rows[index].Cells[1].Value = sqlDR[1];
                dataGridView1.Rows[index].Cells[2].Value = sqlDR[2];
                dataGridView1.Rows[index].Cells[3].Value = sqlDR[3];
            }
            testCon.Close();
            dataGridView1.ClearSelection();
        }

        public void Buttonclear()
        {
            lblDoctor.Text = "";
            txtBDate.Text = "";
            // textBox2.Text = "";
            txtDescription.Text = "";
            txtMoney.Text = "";
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
        }

        #endregion


        #region Reporting---------Reporting
        private void report_function()
        {
            DataGridView2.Rows.Clear();
            testCon.Open();
            string qwery = "select r.Reception_Id,  m.Name, m.Birthday, m.Number, r.Doctor, r.Date, r.Money  from Reception r " +
                "right join MedCard m on m.MedCard_Id = r.MedCard_Id\n";

            bool isAdd = false;

            if (!string.IsNullOrEmpty(PIBTextBox.Text))
            {
                isAdd = true;
                qwery += $"where m.Name like N'%{PIBTextBox.Text}%'";
            }


            else if (!string.IsNullOrEmpty(DoctortextBox.Text))
            {
                if (isAdd)
                    qwery += $" and r.Doctor like N'%{DoctortextBox.Text}%'";
                else
                {
                    isAdd = true;
                    qwery += $"where r.Doctor like N'%{DoctortextBox.Text}%'";
                }
            }

            else  if (!string.IsNullOrEmpty(DatetextBoxFrom.Text))
            {
                if (isAdd)
                    qwery += $" and r.Date Between like N'%{DatetextBoxFrom.Text}' And like N'%{DatetextboxTo.Text}'";
                else
                {
                    isAdd = true;
                    qwery += $"where r.Date Between '{DatetextBoxFrom.Text}' And  '{ DatetextboxTo.Text}'";
                }
            }

            SqlCommand sqlComm = new SqlCommand(qwery, testCon);
            SqlDataReader sqlDR;
            sqlDR = sqlComm.ExecuteReader();
            while (sqlDR.Read())
            {
                int index = DataGridView2.Rows.Add();
                DataGridView2.Rows[index].Cells[0].Value = sqlDR[0];
                DataGridView2.Rows[index].Cells[1].Value = sqlDR[1];
                DataGridView2.Rows[index].Cells[2].Value = sqlDR[2];
                DataGridView2.Rows[index].Cells[3].Value = sqlDR[3];
                DataGridView2.Rows[index].Cells[4].Value = sqlDR[4];
                DataGridView2.Rows[index].Cells[5].Value = sqlDR[5];
                DataGridView2.Rows[index].Cells[6].Value = sqlDR[6];
            }
            testCon.Close();
            DataGridView2.ClearSelection();
        }
        private void ExportToExcel()
        {
            // Creating a Excel object. // Створення Excel об`єкта
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. // Цикл - пробіг через всі та читання всіх колонок
                for (int i = 0; i < DataGridView2.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < DataGridView2.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check.  
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = DataGridView2.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = DataGridView2.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. // Вказати локацію та ім'я Excel файла  для зберігання.
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Успішно експортовано!!!");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }
        #endregion

        #region Mouse Hover & Leave на TextBox'и зубів
        //-----------TextBoxMouseHover------------------------------------------------------------------------------------------------------------------------------
        private void txtBoxMouseHover()
        {
            switch (MHIndex)
            {
                case 1:
                    {
                        this.TopLeftTextBox_8.Size = new System.Drawing.Size(150, 150);
                        this.TopLeftTextBox_8.BringToFront();
                        break;
                    }
                case 2:
                    {
                        this.TopLeftTextBox_7.Size = new System.Drawing.Size(150, 150);
                        this.TopLeftTextBox_7.BringToFront();
                        break;
                    }
                case 3:
                    {
                        this.TopLeftTextBox_6.Size = new System.Drawing.Size(150, 150);
                        this.TopLeftTextBox_6.BringToFront();
                        break;
                    }
                case 4:
                    {
                        this.TopLeftTextBox_5.Size = new System.Drawing.Size(150, 150);
                        this.TopLeftTextBox_5.BringToFront();
                        break;
                    }
                case 5:
                    {
                        this.TopLeftTextBox_4.Size = new System.Drawing.Size(150, 150);
                        this.TopLeftTextBox_4.BringToFront();
                        break;
                    }
                case 6:
                    {
                        this.TopLeftTextBox_3.Size = new System.Drawing.Size(150, 150);
                        this.TopLeftTextBox_3.BringToFront();
                        break;
                    }
                case 7:
                    {
                        this.TopLeftTextBox_2.Size = new System.Drawing.Size(150, 150);
                        this.TopLeftTextBox_2.BringToFront();
                        break;
                    }
                case 8:
                    {
                        this.TopLeftTextBox_1.Size = new System.Drawing.Size(150, 150);
                        this.TopLeftTextBox_1.BringToFront();
                        break;
                    }
                case 9:
                    {
                        this.TopRightTextBox_1.Size = new System.Drawing.Size(150, 150);
                        this.TopRightTextBox_1.BringToFront();
                        break;
                    }
                case 10:
                    {
                        this.TopRightTextBox_2.Size = new System.Drawing.Size(150, 150);
                        this.TopRightTextBox_2.BringToFront();
                        break;
                    }
                case 11:
                    {
                        this.TopRightTextBox_3.Size = new System.Drawing.Size(150, 150);
                        this.TopRightTextBox_3.BringToFront();
                        break;
                    }
                case 12:
                    {
                        this.TopRightTextBox_4.Size = new System.Drawing.Size(150, 150);
                        this.TopRightTextBox_4.BringToFront();
                        break;
                    }
                case 13:
                    {
                        this.TopRightTextBox_5.Size = new System.Drawing.Size(150, 150);
                        this.TopRightTextBox_5.BringToFront();
                        break;
                    }
                case 14:
                    {
                        this.TopRightTextBox_6.Location = TopRightTextBox_5.Location;
                        this.TopRightTextBox_6.Size = new System.Drawing.Size(150, 150);
                        this.TopRightTextBox_6.BringToFront();
                        break;
                    }
                case 15:
                    {
                        this.TopRightTextBox_7.Location = TopRightTextBox_5.Location;
                        this.TopRightTextBox_7.Size = new System.Drawing.Size(150, 150);
                        this.TopRightTextBox_7.BringToFront();
                        break;
                    }
                case 16:
                    {
                        this.TopRightTextBox_8.Location = TopRightTextBox_5.Location;
                        this.TopRightTextBox_8.Size = new System.Drawing.Size(150, 150);
                        this.TopRightTextBox_8.BringToFront();
                        break;
                    }
                case 17:
                    {
                        this.BotLeftTextBox_8.Size = new System.Drawing.Size(150, 115);
                        this.BotLeftTextBox_8.BringToFront();
                        break;
                    }
                case 18:
                    {
                        this.BotLeftTextBox_7.Size = new System.Drawing.Size(150, 115);
                        this.BotLeftTextBox_7.BringToFront();
                        break;
                    }
                case 19:
                    {
                        this.BotLeftTextBox_6.Size = new System.Drawing.Size(150, 115);
                        this.BotLeftTextBox_6.BringToFront();
                        break;
                    }
                case 20:
                    {
                        this.BotLeftTextBox_5.Size = new System.Drawing.Size(150, 115);
                        this.BotLeftTextBox_5.BringToFront();
                        break;
                    }
                case 21:
                    {
                        this.BotLeftTextBox_4.Size = new System.Drawing.Size(150, 115);
                        this.BotLeftTextBox_4.BringToFront();
                        break;
                    }
                case 22:
                    {
                        this.BotLeftTextBox_3.Size = new System.Drawing.Size(150, 115);
                        this.BotLeftTextBox_3.BringToFront();
                        break;
                    }
                case 23:
                    {
                        this.BotLeftTextBox_2.Size = new System.Drawing.Size(150, 115);
                        this.BotLeftTextBox_2.BringToFront();
                        break;
                    }
                case 24:
                    {
                        this.BotLeftTextBox_1.Size = new System.Drawing.Size(150, 115);
                        this.BotLeftTextBox_1.BringToFront();
                        break;
                    }
                case 25:
                    {
                        this.BotRightTextBox_1.Size = new System.Drawing.Size(150, 115);
                        this.BotRightTextBox_1.BringToFront();
                        break;
                    }
                case 26:
                    {
                        this.BotRightTextBox_2.Size = new System.Drawing.Size(150, 115);
                        this.BotRightTextBox_2.BringToFront();
                        break;
                    }
                case 27:
                    {
                        this.BotRightTextBox_3.Size = new System.Drawing.Size(150, 115);
                        this.BotRightTextBox_3.BringToFront();
                        break;
                    }
                case 28:
                    {
                        this.BotRightTextBox_4.Size = new System.Drawing.Size(150, 115);
                        this.BotRightTextBox_4.BringToFront();
                        break;
                    }
                case 29:
                    {
                        this.BotRightTextBox_5.Size = new System.Drawing.Size(150, 115);
                        this.BotRightTextBox_5.BringToFront();
                        break;
                    }
                case 30:
                    {
                        this.BotRightTextBox_6.Location = BotRightTextBox_5.Location;
                        this.BotRightTextBox_6.Size = new System.Drawing.Size(150, 115);
                        this.BotRightTextBox_6.BringToFront();
                        break;
                    }
                case 31:
                    {
                        this.BotRightTextBox_7.Location = BotRightTextBox_5.Location;
                        this.BotRightTextBox_7.Size = new System.Drawing.Size(150, 115);
                        this.BotRightTextBox_7.BringToFront();
                        break;
                    }
                case 32:
                    {
                        this.BotRightTextBox_8.Location = BotRightTextBox_5.Location;
                        this.BotRightTextBox_8.Size = new System.Drawing.Size(150, 115);
                        this.BotRightTextBox_8.BringToFront();
                        break;
                    }
            }
        }
        //-----------TextBoxMouseLeave------------------------------------------------------------------------------------------------------------------------------
        private void txtBoxMouseLeave()
        {
            switch (MLIndex)
            {
                case 1:
                    {
                        this.TopLeftTextBox_8.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 2:
                    {
                        this.TopLeftTextBox_7.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 3:
                    {
                        this.TopLeftTextBox_6.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 4:
                    {
                        this.TopLeftTextBox_5.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 5:
                    {
                        this.TopLeftTextBox_4.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 6:
                    {
                        this.TopLeftTextBox_3.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 7:
                    {
                        this.TopLeftTextBox_2.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 8:
                    {
                        this.TopLeftTextBox_1.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 9:
                    {
                        this.TopRightTextBox_1.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 10:
                    {
                        this.TopRightTextBox_2.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 11:
                    {
                        this.TopRightTextBox_3.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 12:
                    {
                        this.TopRightTextBox_4.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 13:
                    {
                        this.TopRightTextBox_5.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 14:
                    {
                        this.TopRightTextBox_6.Location = new Point(437, 440);
                        this.TopRightTextBox_6.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 15:
                    {
                        this.TopRightTextBox_7.Location = new Point(480, 440);
                        this.TopRightTextBox_7.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 16:
                    {
                        this.TopRightTextBox_8.Location = new Point(518, 440);
                        this.TopRightTextBox_8.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 17:
                    {
                        this.BotLeftTextBox_8.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 18:
                    {
                        this.BotLeftTextBox_7.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 19:
                    {
                        this.BotLeftTextBox_6.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 20:
                    {
                        this.BotLeftTextBox_5.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 21:
                    {
                        this.BotLeftTextBox_4.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 22:
                    {
                        this.BotLeftTextBox_3.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 23:
                    {
                        this.BotLeftTextBox_2.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 24:
                    {
                        this.BotLeftTextBox_1.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 25:
                    {
                        this.BotRightTextBox_1.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 26:
                    {
                        this.BotRightTextBox_2.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 27:
                    {
                        this.BotRightTextBox_3.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 28:
                    {
                        this.BotRightTextBox_4.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 29:
                    {
                        this.BotRightTextBox_5.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 30:
                    {
                        this.BotRightTextBox_6.Location = new Point(437, 501);
                        this.BotRightTextBox_6.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 31:
                    {
                        this.BotRightTextBox_7.Location = new Point(480, 501);
                        this.BotRightTextBox_7.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 32:
                    {
                        this.BotRightTextBox_8.Location = new Point(518, 501);
                        this.BotRightTextBox_8.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
            }

        }
        #endregion

        #region TextBox'и зубів
        public void TopLeftTextBox_8_MouseHover(object sender, EventArgs e)
        {

            MHIndex = 1;
            txtBoxMouseHover();

        }

        public void TopLeftTextBox_8_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 1;
            txtBoxMouseLeave();
        }
        public void TopLeftTextBox_7_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            MHIndex = 2;
            txtBoxMouseHover();
        }

        private void TopLeftTextBox_7_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 2;
            txtBoxMouseLeave();
        }
        private void TopLeftTextBox_6_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            MHIndex = 3;
            txtBoxMouseHover();
        }

        private void TopLeftTextBox_6_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 3;
            txtBoxMouseLeave();
        }
        private void TopLeftTextBox_5_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            MHIndex = 4;
            txtBoxMouseHover();
        }

        private void TopLeftTextBox_5_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 4;
            txtBoxMouseLeave();
        }
        private void TopLeftTextBox_4_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            MHIndex = 5;
            txtBoxMouseHover();
        }

        private void TopLeftTextBox_4_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 5;
            txtBoxMouseLeave();
        }
        private void TopLeftTextBox_3_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            MHIndex = 6;
            txtBoxMouseHover();
        }

        private void TopLeftTextBox_3_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 6;
            txtBoxMouseLeave();
        }
        private void TopLeftTextBox_2_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            MHIndex = 7;
            txtBoxMouseHover();
        }

        private void TopLeftTextBox_2_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 7;
            txtBoxMouseLeave();
        }
        private void TopLeftTextBox_1_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            MHIndex = 8;
            txtBoxMouseHover();
        }

        private void TopLeftTextBox_1_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 8;
            txtBoxMouseLeave();
        }

        private void TopRightTextBox_1_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 9;
            txtBoxMouseHover();
        }

        private void TopRightTextBox_1_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 9;
            txtBoxMouseLeave();
        }
        private void TopRightTextBox_2_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 10;
            txtBoxMouseHover();
        }

        private void TopRightTextBox_2_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 10;
            txtBoxMouseLeave();
        }
        private void TopRightTextBox_3_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 11;
            txtBoxMouseHover();
        }

        private void TopRightTextBox_3_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 11;
            txtBoxMouseLeave();
        }
        private void TopRightTextBox_4_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 12;
            txtBoxMouseHover();
        }

        private void TopRightTextBox_4_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 12;
            txtBoxMouseLeave();
        }
        private void TopRightTextBox_5_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 13;
            txtBoxMouseHover();
        }

        private void TopRightTextBox_5_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 13;
            txtBoxMouseLeave();
        }
        private void TopRightTextBox_6_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 14;
            txtBoxMouseHover();
        }

        private void TopRightTextBox_6_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 14;
            txtBoxMouseLeave();
        }
        private void TopRightTextBox_7_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 15;
            txtBoxMouseHover();
        }

        private void TopRightTextBox_7_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 15;
            txtBoxMouseLeave();
        }
        private void TopRightTextBox_8_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 16;
            txtBoxMouseHover();
        }

        private void TopRightTextBox_8_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 16;
            txtBoxMouseLeave();
        }

        private void BotLeftTextBox_8_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 17;
            txtBoxMouseHover();
        }

        private void BotLeftTextBox_8_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 17;
            txtBoxMouseLeave();
        }
        private void BotLeftTextBox_7_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 18;
            txtBoxMouseHover();
        }

        private void BotLeftTextBox_7_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 18;
            txtBoxMouseLeave();
        }
        private void BotLeftTextBox_6_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 19;
            txtBoxMouseHover();
        }

        private void BotLeftTextBox_6_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 19;
            txtBoxMouseLeave();
        }
        private void BotLeftTextBox_5_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 20;
            txtBoxMouseHover();
        }

        private void BotLeftTextBox_5_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 20;
            txtBoxMouseLeave();
        }
        private void BotLeftTextBox_4_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 21;
            txtBoxMouseHover();
        }

        private void BotLeftTextBox_4_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 21;
            txtBoxMouseLeave();
        }
        private void BotLeftTextBox_3_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 22;
            txtBoxMouseHover();
        }

        private void BotLeftTextBox_3_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 22;
            txtBoxMouseLeave();
        }
        private void BotLeftTextBox_2_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 23;
            txtBoxMouseHover();
        }

        private void BotLeftTextBox_2_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 23;
            txtBoxMouseLeave();
        }
        private void BotLeftTextBox_1_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 24;
            txtBoxMouseHover();
        }

        private void BotLeftTextBox_1_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 24;
            txtBoxMouseLeave();
        }
        private void BotRightTextBox_1_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 25;
            txtBoxMouseHover();
        }

        private void BotRightTextBox_1_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 25;
            txtBoxMouseLeave();
        }
        private void BotRightTextBox_2_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 26;
            txtBoxMouseHover();
        }

        private void BotRightTextBox_2_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 26;
            txtBoxMouseLeave();
        }
        private void BotRightTextBox_3_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 27;
            txtBoxMouseHover();
        }

        private void BotRightTextBox_3_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 27;
            txtBoxMouseLeave();
        }
        private void BotRightTextBox_4_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 28;
            txtBoxMouseHover();
        }

        private void BotRightTextBox_4_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 28;
            txtBoxMouseLeave();
        }
        private void BotRightTextBox_5_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 29;
            txtBoxMouseHover();
        }

        private void BotRightTextBox_5_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 29;
            txtBoxMouseLeave();
        }
        private void BotRightTextBox_6_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 30;
            txtBoxMouseHover();
        }

        private void BotRightTextBox_6_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 30;
            txtBoxMouseLeave();
        }
        private void BotRightTextBox_7_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 31;
            txtBoxMouseHover();
        }

        private void BotRightTextBox_7_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 31;
            txtBoxMouseLeave();
        }
        private void BotRightTextBox_8_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MHIndex = 32;
            txtBoxMouseHover();
        }
        private void BotRightTextBox_8_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            MLIndex = 32;
            txtBoxMouseLeave();
        }

        #endregion

        private void buttonZ1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainMenu newForm = new MainMenu();
            newForm.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            showAccount();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            showAccount();
        }
        private void showAccount()
        {
            Account newForm = new Account();
            newForm.Show();
        }
    }
}

        

     

