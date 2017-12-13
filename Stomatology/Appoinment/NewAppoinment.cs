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

        int Arrears; 

        string[] Doctor = { "Кричильський Леонід Ростиславович", " Кричильський Тетяна Георгієвна", "Яскал Зоряна Миколаївна" };

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
            TopLeftTextBox1.Text = "";
            TopLeftTextBox2.Text = "";
            TopLeftTextBox3.Text = "";
            TopLeftTextBox4.Text = "";
            TopLeftTextBox5.Text = "";
            TopLeftTextBox6.Text = "";
            TopLeftTextBox7.Text = "";
            TopLeftTextBox8.Text = "";
            BotLeftTextBox8.Text = "";
            BotLeftTextBox7.Text = "";
            BotLeftTextBox6.Text = "";
            BotLeftTextBox5.Text = "";
            BotLeftTextBox4.Text = "";
            BotLeftTextBox3.Text = "";
            BotLeftTextBox2.Text = "";
            BotLeftTextBox1.Text = "";
            TopRightTextBox1.Text = "";
            TopRightTextBox2.Text = "";
            TopRightTextBox3.Text = "";
            TopRightTextBox4.Text = "";
            TopRightTextBox5.Text = "";
            TopRightTextBox6.Text = "";
            TopRightTextBox7.Text = "";
            TopRightTextBox8.Text = "";
            BotRightTextBox8.Text = "";
            BotRightTextBox7.Text = "";
            BotRightTextBox6.Text = "";
            BotRightTextBox5.Text = "";
            BotRightTextBox4.Text = "";
            BotRightTextBox3.Text = "";
            BotRightTextBox2.Text = "";
            BotRightTextBox1.Text = "";
        }
        #region TextBox'и зубів
        #region Mouse Hover & Leave на TextBox'и зубів
        //-----------TextBoxMouseHover------------------------------------------------------------------------------------------------------------------------------
        private void txtBoxMouseHover(int number)
        {
            switch (number)
            {
                case 1:
                    {
                        this.TopLeftTextBox8.Size = new Size(150, 150);
                        this.TopLeftTextBox8.BringToFront();
                        break;
                    }
                case 2:
                    {
                        this.TopLeftTextBox7.Size = new Size(150, 150);
                        this.TopLeftTextBox7.BringToFront();
                        break;
                    }
                case 3:
                    {
                        this.TopLeftTextBox6.Size = new Size(150, 150);
                        this.TopLeftTextBox6.BringToFront();
                        break;
                    }
                case 4:
                    {
                        this.TopLeftTextBox5.Size = new Size(150, 150);
                        this.TopLeftTextBox5.BringToFront();
                        break;
                    }
                case 5:
                    {
                        this.TopLeftTextBox4.Size = new Size(150, 150);
                        this.TopLeftTextBox4.BringToFront();
                        break;
                    }
                case 6:
                    {
                        this.TopLeftTextBox3.Size = new Size(150, 150);
                        this.TopLeftTextBox3.BringToFront();
                        break;
                    }
                case 7:
                    {
                        this.TopLeftTextBox2.Size = new Size(150, 150);
                        this.TopLeftTextBox2.BringToFront();
                        break;
                    }
                case 8:
                    {
                        this.TopLeftTextBox1.Size = new Size(150, 150);
                        this.TopLeftTextBox1.BringToFront();
                        break;
                    }
                case 9:
                    {
                        this.TopRightTextBox1.Size = new Size(150, 150);
                        this.TopRightTextBox1.BringToFront();
                        break;
                    }
                case 10:
                    {
                        this.TopRightTextBox2.Size = new Size(150, 150);
                        this.TopRightTextBox2.BringToFront();
                        break;
                    }
                case 11:
                    {
                        this.TopRightTextBox3.Size = new Size(150, 150);
                        this.TopRightTextBox3.BringToFront();
                        break;
                    }
                case 12:
                    {
                        this.TopRightTextBox4.Size = new Size(150, 150);
                        this.TopRightTextBox4.BringToFront();
                        break;
                    }
                case 13:
                    {
                        this.TopRightTextBox5.Size = new Size(150, 150);
                        this.TopRightTextBox5.BringToFront();
                        break;
                    }
                case 14:
                    {
                        this.TopRightTextBox6.Location = TopRightTextBox5.Location;
                        this.TopRightTextBox6.Size = new Size(150, 150);
                        this.TopRightTextBox6.BringToFront();
                        break;
                    }
                case 15:
                    {
                        this.TopRightTextBox7.Location = TopRightTextBox5.Location;
                        this.TopRightTextBox7.Size = new Size(150, 150);
                        this.TopRightTextBox7.BringToFront();
                        break;
                    }
                case 16:
                    {
                        this.TopRightTextBox8.Location = TopRightTextBox5.Location;
                        this.TopRightTextBox8.Size = new Size(150, 150);
                        this.TopRightTextBox8.BringToFront();
                        break;
                    }
                case 17:
                    {
                        this.BotLeftTextBox8.Size = new Size(150, 150);
                        this.BotLeftTextBox8.BringToFront();
                        break;
                    }
                case 18:
                    {
                        this.BotLeftTextBox7.Size = new Size(150, 150);
                        this.BotLeftTextBox7.BringToFront();
                        break;
                    }
                case 19:
                    {
                        this.BotLeftTextBox6.Size = new Size(150, 150);
                        this.BotLeftTextBox6.BringToFront();
                        break;
                    }
                case 20:
                    {
                        this.BotLeftTextBox5.Size = new Size(150, 150);
                        this.BotLeftTextBox5.BringToFront();
                        break;
                    }
                case 21:
                    {
                        this.BotLeftTextBox4.Size = new Size(150, 150);
                        this.BotLeftTextBox4.BringToFront();
                        break;
                    }
                case 22:
                    {
                        this.BotLeftTextBox3.Size = new Size(150, 150);
                        this.BotLeftTextBox3.BringToFront();
                        break;
                    }
                case 23:
                    {
                        this.BotLeftTextBox2.Size = new Size(150, 150);
                        this.BotLeftTextBox2.BringToFront();
                        break;
                    }
                case 24:
                    {
                        this.BotLeftTextBox1.Size = new Size(150, 150);
                        this.BotLeftTextBox1.BringToFront();
                        break;
                    }
                case 25:
                    {
                        this.BotRightTextBox1.Size = new Size(150, 150);
                        this.BotRightTextBox1.BringToFront();
                        break;
                    }
                case 26:
                    {
                        this.BotRightTextBox2.Size = new Size(150, 150);
                        this.BotRightTextBox2.BringToFront();
                        break;
                    }
                case 27:
                    {
                        this.BotRightTextBox3.Size = new Size(150, 150);
                        this.BotRightTextBox3.BringToFront();
                        break;
                    }
                case 28:
                    {
                        this.BotRightTextBox4.Size = new Size(150, 150);
                        this.BotRightTextBox4.BringToFront();
                        break;
                    }
                case 29:
                    {
                        this.BotRightTextBox5.Size = new Size(150, 150);
                        this.BotRightTextBox5.BringToFront();
                        break;
                    }
                case 30:
                    {
                        this.BotRightTextBox6.Location = BotRightTextBox5.Location;
                        this.BotRightTextBox6.Size = new Size(150, 150);
                        this.BotRightTextBox6.BringToFront();
                        break;
                    }
                case 31:
                    {
                        this.BotRightTextBox7.Location = BotRightTextBox5.Location;
                        this.BotRightTextBox7.Size = new Size(150, 150);
                        this.BotRightTextBox7.BringToFront();
                        break;
                    }
                case 32:
                    {
                        this.BotRightTextBox8.Location = BotRightTextBox5.Location;
                        this.BotRightTextBox8.Size = new Size(150, 150);
                        this.BotRightTextBox8.BringToFront();
                        break;
                    }
            }
        }
        //-----------TextBoxMouseLeave------------------------------------------------------------------------------------------------------------------------------
        private void txtBoxMouseLeave(int number)
        {
            switch (number)
            {
                case 1:
                    {
                        this.TopLeftTextBox8.Size = new Size(21, 21);
                        break;
                    }
                case 2:
                    {
                        this.TopLeftTextBox7.Size = new Size(21, 21);
                        break;
                    }
                case 3:
                    {
                        this.TopLeftTextBox6.Size = new Size(21, 21);
                        break;
                    }
                case 4:
                    {
                        this.TopLeftTextBox5.Size = new Size(21, 21);
                        break;
                    }
                case 5:
                    {
                        this.TopLeftTextBox4.Size = new Size(21, 21);
                        break;
                    }
                case 6:
                    {
                        this.TopLeftTextBox3.Size = new Size(21, 21);
                        break;
                    }
                case 7:
                    {
                        this.TopLeftTextBox2.Size = new Size(21, 21);
                        break;
                    }
                case 8:
                    {
                        this.TopLeftTextBox1.Size = new Size(21, 21);
                        break;
                    }
                case 9:
                    {
                        this.TopRightTextBox1.Size = new Size(21, 21);
                        break;
                    }
                case 10:
                    {
                        this.TopRightTextBox2.Size = new Size(21, 21);
                        break;
                    }
                case 11:
                    {
                        this.TopRightTextBox3.Size = new Size(21, 21);
                        break;
                    }
                case 12:
                    {
                        this.TopRightTextBox4.Size = new Size(21, 21);
                        break;
                    }
                case 13:
                    {
                        this.TopRightTextBox5.Size = new Size(21, 21);
                        break;
                    }
                case 14:
                    {
                        this.TopRightTextBox6.Location = new Point(446, 389);
                        this.TopRightTextBox6.Size = new Size(21, 21);
                        break;
                    }
                case 15:
                    {
                        this.TopRightTextBox7.Location = new Point(489, 389);
                        this.TopRightTextBox7.Size = new Size(21, 21);
                        break;
                    }
                case 16:
                    {
                        this.TopRightTextBox8.Location = new Point(527, 389);
                        this.TopRightTextBox8.Size = new Size(21, 21);
                        break;
                    }
                case 17:
                    {
                        this.BotLeftTextBox8.Size = new Size(21, 21);
                        break;
                    }
                case 18:
                    {
                        this.BotLeftTextBox7.Size = new Size(21, 21);
                        break;
                    }
                case 19:
                    {
                        this.BotLeftTextBox6.Size = new Size(21, 21);
                        break;
                    }
                case 20:
                    {
                        this.BotLeftTextBox5.Size = new Size(21, 21);
                        break;
                    }
                case 21:
                    {
                        this.BotLeftTextBox4.Size = new Size(21, 21);
                        break;
                    }
                case 22:
                    {
                        this.BotLeftTextBox3.Size = new Size(21, 21);
                        break;
                    }
                case 23:
                    {
                        this.BotLeftTextBox2.Size = new Size(21, 21);
                        break;
                    }
                case 24:
                    {
                        this.BotLeftTextBox1.Size = new Size(21, 21);
                        break;
                    }
                case 25:
                    {
                        this.BotRightTextBox1.Size = new Size(21, 21);
                        break;
                    }
                case 26:
                    {
                        this.BotRightTextBox2.Size = new Size(21, 21);
                        break;
                    }
                case 27:
                    {
                        this.BotRightTextBox3.Size = new Size(21, 21);
                        break;
                    }
                case 28:
                    {
                        this.BotRightTextBox4.Size = new Size(21, 21);
                        break;
                    }
                case 29:
                    {
                        this.BotRightTextBox5.Size = new Size(21, 21);
                        break;
                    }
                case 30:
                    {
                        this.BotRightTextBox6.Location = new Point(446, 450);
                        this.BotRightTextBox6.Size = new Size(21, 21);
                        break;
                    }
                case 31:
                    {
                        this.BotRightTextBox7.Location = new Point(489, 450);
                        this.BotRightTextBox7.Size = new Size(21, 21);
                        break;
                    }
                case 32:
                    {
                        this.BotRightTextBox8.Location = new Point(527, 450);
                        this.BotRightTextBox8.Size = new Size(21, 21);
                        break;
                    }
            }

        }
        #endregion
        public void TopLeftTextBox_8_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(1);
        }

        public void TopLeftTextBox_8_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(1);
        }
        public void TopLeftTextBox_7_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(2);
        }

        private void TopLeftTextBox_7_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(2);
        }
        private void TopLeftTextBox_6_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(3);
        }

        private void TopLeftTextBox_6_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(3);
        }
        private void TopLeftTextBox_5_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(4);
        }

        private void TopLeftTextBox_5_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(4);
        }
        private void TopLeftTextBox_4_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(5);
        }

        private void TopLeftTextBox_4_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(5);
        }
        private void TopLeftTextBox_3_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(6);
        }

        private void TopLeftTextBox_3_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(6);
        }
        private void TopLeftTextBox_2_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(7);
        }

        private void TopLeftTextBox_2_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(7);
        }
        private void TopLeftTextBox_1_MouseHover(object sender, EventArgs e)
        {
            // Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(8);
        }

        private void TopLeftTextBox_1_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(8);
        }

        private void TopRightTextBox_1_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(9);
        }

        private void TopRightTextBox_1_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(9);
        }
        private void TopRightTextBox_2_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(10);
        }

        private void TopRightTextBox_2_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(10);
        }
        private void TopRightTextBox_3_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(11);
        }

        private void TopRightTextBox_3_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(11);
        }
        private void TopRightTextBox_4_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(12);
        }

        private void TopRightTextBox_4_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(12);
        }
        private void TopRightTextBox_5_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(13);
        }

        private void TopRightTextBox_5_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(13);
        }
        private void TopRightTextBox_6_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(14);
        }

        private void TopRightTextBox_6_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(14);
        }
        private void TopRightTextBox_7_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(15);
        }

        private void TopRightTextBox_7_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(15);
        }
        private void TopRightTextBox_8_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(16);
        }

        private void TopRightTextBox_8_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(16);
        }

        private void BotLeftTextBox_8_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(17);
        }

        private void BotLeftTextBox_8_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(17);
        }
        private void BotLeftTextBox_7_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(18);
        }

        private void BotLeftTextBox_7_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(18);
        }
        private void BotLeftTextBox_6_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(19);
        }

        private void BotLeftTextBox_6_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(19);
        }
        private void BotLeftTextBox_5_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(20);
        }

        private void BotLeftTextBox_5_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(20);
        }
        private void BotLeftTextBox_4_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(21);
        }

        private void BotLeftTextBox_4_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(21);
        }
        private void BotLeftTextBox_3_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(22);
        }

        private void BotLeftTextBox_3_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(22);
        }
        private void BotLeftTextBox_2_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(23);
        }

        private void BotLeftTextBox_2_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(23);
        }
        private void BotLeftTextBox_1_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(24);
        }

        private void BotLeftTextBox_1_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(24);
        }
        private void BotRightTextBox_1_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(25);
        }

        private void BotRightTextBox_1_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(25);
        }
        private void BotRightTextBox_2_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(26);
        }

        private void BotRightTextBox_2_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(26);
        }
        private void BotRightTextBox_3_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(27);
        }

        private void BotRightTextBox_3_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(27);
        }
        private void BotRightTextBox_4_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(28);
        }

        private void BotRightTextBox_4_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(28);
        }
        private void BotRightTextBox_5_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(29);
        }

        private void BotRightTextBox_5_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(29);
        }
        private void BotRightTextBox_6_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(30);
        }

        private void BotRightTextBox_6_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(30);
        }
        private void BotRightTextBox_7_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(31);
        }

        private void BotRightTextBox_7_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(31);
        }
        private void BotRightTextBox_8_MouseHover(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseHover(32);
        }
        private void BotRightTextBox_8_MouseLeave(object sender, EventArgs e)
        {
            //Текстбокси рахуються з лівої сторони
            txtBoxMouseLeave(32);
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Заповнення Word файла  
        private void btnAdd_Click(object sender, EventArgs e)
        {
            saveToWordFile();
            saveToBD();
        }
        private void saveToBD()
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
                        $"values (N'{dtpDate.Value.Date.ToString("yyyy/MM/dd")}', N'{cmbDoctor.SelectedItem}', '{MedCardId}', N'{txtDescription.Text}', N'{txtMoney.Text}', '{Arrears}', " +

                        $" N'{TopLeftTextBox_1.Text}',  N'{TopLeftTextBox_2.Text}',  N'{TopLeftTextBox_3.Text}',  N'{TopLeftTextBox_4.Text}',  N'{TopLeftTextBox_5.Text}',  N'{TopLeftTextBox_6.Text}',  N'{TopLeftTextBox_7.Text}',  N'{TopLeftTextBox_8.Text}'," +
                        $" N'{TopRightTextBox_1.Text}', N'{TopRightTextBox_2.Text}', N'{TopRightTextBox_3.Text}', N'{TopRightTextBox_4.Text}', N'{TopRightTextBox_5.Text}', N'{TopRightTextBox_6.Text}', N'{TopRightTextBox_7.Text}', N'{TopRightTextBox_8.Text}'," +
                        $" N'{BotRightTextBox_8.Text}', N'{BotRightTextBox_7.Text}', N'{BotRightTextBox_6.Text}', N'{BotRightTextBox_5.Text}', N'{BotRightTextBox_4.Text}', N'{BotRightTextBox_3.Text}', N'{BotRightTextBox_2.Text}', N'{BotRightTextBox_1.Text}'," +
                        $" N'{BotLeftTextBox_8.Text}',  N'{BotLeftTextBox_7.Text}',  N'{BotLeftTextBox_6.Text}',  N'{BotLeftTextBox_5.Text}',  N'{BotLeftTextBox_4.Text}',  N'{BotLeftTextBox_3.Text}',  N'{BotLeftTextBox_2.Text}',  N'{BotLeftTextBox_1.Text}')";

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

        private void saveToWordFile()
        {
            var name = cmbPatient.Text;

            try
            {
                addAppoinment(@Properties.Settings.Default.Name + "\\" + name + ".docx", name);
            }
            catch
            {
                string message = "Виникли проблеми при спробі додати прийом, вкажіть шлях до екземпляру. Бажаєте вказати шлях?";
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

                            addAppoinment(@Properties.Settings.Default.ExistMedCardFile, name);
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
            //range.Font.ColorIndex = Word.WdColorIndex.wdBlack; Color
        }

        private void replaceDateWord(string stubToReplace, string replaceDate,Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: replaceDate, ReplaceWith: stubToReplace);
        }

        private void addAppoinment(string way, string name)
        {
            var date = dtpDate.Text;
            var doctor = cmbDoctor.Text;
            var desctription = txtDescription.Text;

            var wordApp = new Word.Application();
            wordApp.Visible = false;

            var wordDocument = wordApp.Documents.Open(way);

            ReplaceWordStub("{date1}", date, wordDocument);
            ReplaceWordStub("{description1}", desctription, wordDocument);
            int i = 1;
            int j = 2;
            do
            {
                replaceDateWord("{date" + i + "}", "{date" + j + "}", wordDocument);
                replaceDateWord("{description" + i + "}", "{description" + j + "}", wordDocument);
                i++;
                j++;

            } while (i <= 22 && j <= 23);

            wordDocument.SaveAs(@Properties.Settings.Default.Name + "\\" + name + ".docx");
            MessageBox.Show("Успішно збережно в: " + @Properties.Settings.Default.Name + " як " +name + ".docx");

            wordApp.ActiveDocument.Close();
            wordApp.Quit();
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
                string[] arrAllFiles = openFileDialog1.FileNames;
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
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             