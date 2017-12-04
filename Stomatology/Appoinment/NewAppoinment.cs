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
    public partial class NewAppoinment : Form
    {
        SqlConnection testCon = new SqlConnection
        (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Properties.Settings.Default.DateBaseDirection);

        int MHIndex;
        int MLIndex;
        int Arrears; 

        string[] Doctor = { "Кричильський Леонід Ростиславович", " Кричильський Тетяна Георгієвна", "Яскал Зоряна Миколаївна" };
        string TemplateFileName = @"D:\GoogleDrive InSoP\" + Properties.Settings.Default.WordFileDirection + ".docx";
        public void PassValue(string strValue)
        {
            txtMoney.Text = strValue;
        }

        public NewAppoinment()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewAppoinment_Load(object sender, EventArgs e)
        {
            cmbPatient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPatient.AutoCompleteSource = AutoCompleteSource.ListItems;

            testCon.Open();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT Name FROM [MedCard]", testCon);
            try
            {
                sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    cmbPatient.Items.Add(Convert.ToString(sqlReader["Name"]));
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
            cmbDoctor.Items.AddRange(Doctor);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPatient.Text.Length == 0 || txtDescription.Text.Length == 0)
                    throw new Exception("Не всі поля заповнені!");
                else
                {
                    if (string.IsNullOrEmpty(cmbPatient.Text)) throw new Exception("Виберіть  Паціента!");
                    testCon.Open();
                    string MedCardId = "";
                    string query = $"select MedCard_Id from MedCard where [Name] = N'{cmbPatient.Text}'";
                    SqlCommand cmd1 = new SqlCommand(query, testCon);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        MedCardId = reader["MedCard_Id"].ToString();
                    }
                    else
                    {
                        throw new Exception("Не вибраний паціент, перевірте ще раз!");
                    }
                    testCon.Close();
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
                    testCon.Open();
                    SqlCommand cmd = testCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"INSERT INTO Reception (Date, Doctor, MedCard_Id, Info, Money, Arrears, tlt1, tlt2, tlt3, tlt4, tlt5, tlt6, tlt7, tlt8, " +
                        $"trt1, trt2, trt3, trt4, trt5, trt6, trt7, trt8, " +
                        $"brt1, brt2, brt3, brt4, brt5, brt6, brt7, brt8, " +
                        $"blt1, blt2, blt3, blt4, blt5, blt6, blt7, blt8)" +
                        $"values (N'{dtpDate.Value.Date.ToString("dd/MM/yyyy")}', N'{cmbDoctor.SelectedItem}', '{MedCardId}', N'{txtDescription.Text}', N'{txtMoney.Text}', '{Arrears}', " +

                        $" N'{TopLeftTextBox_1.Text}', N'{TopLeftTextBox_2.Text}',   N'{TopLeftTextBox_3.Text}', N'{TopLeftTextBox_4.Text}', N'{TopLeftTextBox_5.Text}', N'{TopLeftTextBox_6.Text}', N'{TopLeftTextBox_7.Text}', N'{TopLeftTextBox_8.Text}'," +
                        $" N'{TopRightTextBox_1.Text}', N'{TopRightTextBox_2.Text}', N'{TopRightTextBox_3.Text}', N'{TopRightTextBox_4.Text}', N'{TopRightTextBox_5.Text}', N'{TopRightTextBox_6.Text}', N'{TopRightTextBox_7.Text}', N'{TopRightTextBox_8.Text}'," +
                        $" N'{BotRightTextBox_8.Text}', N'{BotRightTextBox_7.Text}', N'{BotRightTextBox_6.Text}', N'{BotRightTextBox_5.Text}', N'{BotRightTextBox_4.Text}', N'{BotRightTextBox_3.Text}', N'{BotRightTextBox_2.Text}', N'{BotRightTextBox_1.Text}'," +
                        $" N'{BotLeftTextBox_8.Text}',  N'{BotLeftTextBox_7.Text}',  N'{BotLeftTextBox_6.Text}', N'{BotLeftTextBox_5.Text}', N'{BotLeftTextBox_4.Text}', N'{BotLeftTextBox_3.Text}', N'{BotLeftTextBox_2.Text}', N'{BotLeftTextBox_1.Text}')";

                    cmd.ExecuteNonQuery();

                    Buttonclear();
                    MessageBox.Show("Додано новий прийом.");
                    testCon.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                testCon.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Calculator newForm = new Calculator(this);
            newForm.Show();
        }

        public void Buttonclear()
        {
            txtMoney.Text = "";
            txtDescription.Text = "";
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
                        this.BotLeftTextBox_8.Size = new System.Drawing.Size(150, 150);
                        this.BotLeftTextBox_8.BringToFront();
                        break;
                    }
                case 18:
                    {
                        this.BotLeftTextBox_7.Size = new System.Drawing.Size(150, 150);
                        this.BotLeftTextBox_7.BringToFront();
                        break;
                    }
                case 19:
                    {
                        this.BotLeftTextBox_6.Size = new System.Drawing.Size(150, 150);
                        this.BotLeftTextBox_6.BringToFront();
                        break;
                    }
                case 20:
                    {
                        this.BotLeftTextBox_5.Size = new System.Drawing.Size(150, 150);
                        this.BotLeftTextBox_5.BringToFront();
                        break;
                    }
                case 21:
                    {
                        this.BotLeftTextBox_4.Size = new System.Drawing.Size(150, 150);
                        this.BotLeftTextBox_4.BringToFront();
                        break;
                    }
                case 22:
                    {
                        this.BotLeftTextBox_3.Size = new System.Drawing.Size(150, 150);
                        this.BotLeftTextBox_3.BringToFront();
                        break;
                    }
                case 23:
                    {
                        this.BotLeftTextBox_2.Size = new System.Drawing.Size(150, 150);
                        this.BotLeftTextBox_2.BringToFront();
                        break;
                    }
                case 24:
                    {
                        this.BotLeftTextBox_1.Size = new System.Drawing.Size(150, 150);
                        this.BotLeftTextBox_1.BringToFront();
                        break;
                    }
                case 25:
                    {
                        this.BotRightTextBox_1.Size = new System.Drawing.Size(150, 150);
                        this.BotRightTextBox_1.BringToFront();
                        break;
                    }
                case 26:
                    {
                        this.BotRightTextBox_2.Size = new System.Drawing.Size(150, 150);
                        this.BotRightTextBox_2.BringToFront();
                        break;
                    }
                case 27:
                    {
                        this.BotRightTextBox_3.Size = new System.Drawing.Size(150, 150);
                        this.BotRightTextBox_3.BringToFront();
                        break;
                    }
                case 28:
                    {
                        this.BotRightTextBox_4.Size = new System.Drawing.Size(150, 150);
                        this.BotRightTextBox_4.BringToFront();
                        break;
                    }
                case 29:
                    {
                        this.BotRightTextBox_5.Size = new System.Drawing.Size(150, 150);
                        this.BotRightTextBox_5.BringToFront();
                        break;
                    }
                case 30:
                    {
                        this.BotRightTextBox_6.Location = BotRightTextBox_5.Location;
                        this.BotRightTextBox_6.Size = new System.Drawing.Size(150, 150);
                        this.BotRightTextBox_6.BringToFront();
                        break;
                    }
                case 31:
                    {
                        this.BotRightTextBox_7.Location = BotRightTextBox_5.Location;
                        this.BotRightTextBox_7.Size = new System.Drawing.Size(150, 150);
                        this.BotRightTextBox_7.BringToFront();
                        break;
                    }
                case 32:
                    {
                        this.BotRightTextBox_8.Location = BotRightTextBox_5.Location;
                        this.BotRightTextBox_8.Size = new System.Drawing.Size(150, 150);
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
                        this.TopRightTextBox_6.Location = new Point(448, 382);
                        this.TopRightTextBox_6.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 15:
                    {
                        this.TopRightTextBox_7.Location = new Point(491, 382);
                        this.TopRightTextBox_7.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 16:
                    {
                        this.TopRightTextBox_8.Location = new Point(529, 382);
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
                        this.BotRightTextBox_6.Location = new Point(448, 443);
                        this.BotRightTextBox_6.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 31:
                    {
                        this.BotRightTextBox_7.Location = new Point(491, 443);
                        this.BotRightTextBox_7.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 32:
                    {
                        this.BotRightTextBox_8.Location = new Point(529, 443);
                        this.BotRightTextBox_8.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
            }

        }
        #endregion
        #region TextBox'и зубів
        public void TopLeftTextBox_8_MouseHover(object sender, EventArgs e)
        {

            // Текстбокси рахуються з лівої сторони
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Заповнення Word файла  
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var date = dtpDate.Text;
            var doctor = cmbDoctor.Text;
            var desctription = txtDescription.Text;

            var wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                var wordDocument = wordApp.Documents.Open(@Properties.Settings.Default.WordFileDirection);

                ReplaceWordStub("date1", date, wordDocument);
                ReplaceWordStub("description1", desctription, wordDocument);
                int i = 1;
                int j = 2;
                do
                {
                    replaceDateWord("{date" + i + "}", "{date" + j + "}", wordDocument);
                    replaceDateWord("{description" + i + "}", "{description" + j + "}", wordDocument);
                    i++;
                    j++;
                
                } while (i <= 22 && j <= 23);

                wordDocument.SaveAs(@Properties.Settings.Default.WordFileDirection);

                wordApp.ActiveDocument.Close();
                wordApp.Quit();
            }
            catch
            {
                wordApp.ActiveDocument.Close();
                wordApp.Quit();
                MessageBox.Show("Error");
            }
        }

        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
            //range.Font.ColorIndex = Word.WdColorIndex.wdBlack; Color
        }
        private void replaceDateWord(string stubToReplace, string replaceDate,Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: replaceDate, ReplaceWith: stubToReplace);
        }
        #endregion
        private void новийToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void existPatient_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ".docx file (*.docx)|*.docx";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sFileName = openFileDialog1.FileName;
                //string[] arrAllFiles = openFileDialog1.FileNames;
                Properties.Settings.Default.WordFileDirection = sFileName;
                Properties.Settings.Default.Save();
            }
        }

        private void chbArrears_CheckedChanged(object sender, EventArgs e)
        {
            if (chbArrears.Checked == true)
            {
                Arrears = 1;
            }
            else
            {
                Arrears = 0;
            }
        }
    }      
}                                                                                            
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             