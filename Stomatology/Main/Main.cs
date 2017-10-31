﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Stomatology
{
    public partial class Main : Form
    {
        private Settings settingsForm;
        SqlConnection testCon = new SqlConnection
     (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GoogleDrive InSoP\Stomatology\Stomatology\DataStomatology.mdf;Integrated Security=True");

        string direction;
        int MHIndex;
        int MLIndex;

        public void PassValue(string strValue)
        {
            txtMoney.Text = strValue;
        }
        public void PassDirValue(string dirValue)
        {
            direction = @dirValue;
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateTable();
            this.direction = Properties.Settings.Default.TeamViewerDirection;
        }


        private void updateTable()
        {
            dataGridView1.Rows.Clear();
            testCon.Open();
            string upqwery = "select * from Pacient";
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
                dataGridView1.Rows[index].Cells[4].Value = sqlDR[4];
            }
            testCon.Close();
            dataGridView1.ClearSelection();
        }

        private void AddNewAppoinment_Click(object sender, EventArgs e)
        {
            NewAppoinment newForm = new NewAppoinment();
            newForm.Show();
        }
        private void EditPatient_Click(object sender, EventArgs e)
        {
            EditPatient newForm = new EditPatient();
            newForm.Show();
        }
        private void AddNewPatient_Click(object sender, EventArgs e)
        {
            NewPatient newForm = new NewPatient();
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string birthday = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string number = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string adress = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(comboBox1.Text)) throw new Exception("Виберіть  Дату!");
            //testCon.Open();
            //string ReceptionDate = "";
            //string query = $"select * from [Reception] where [Date] = N'{comboBox1.Text}'";
            //SqlCommand cmd1 = new SqlCommand(query, testCon); 
            //SqlDataReader reader = cmd1.ExecuteReader();

            //if (reader.Read())
            //{
            //    ReceptionDate = reader["Date"].ToString();
            //    testCon.Open();
            //    SqlCommand cmd = testCon.CreateCommand();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = $" select ( Info, Money, tlt1, tlt2, tlt3, tlt4, tlt5, tlt6, tlt7, tlt8, " +
            //           $"trt1, trt2, trt3, trt4, trt5, trt6, trt7, trt8, " +
            //           $"brt1, brt2, brt3, brt4, brt5, brt6, brt7, brt8, " +
            //           $"blt1, blt2, blt3, blt4, blt5, blt6, blt7, blt8 ) " +
            //           $"values From Reception(N'{textBox1.Text}', N'{txtMoney.Text}', " +

            //           $" '{TopLeftTextBox_1.Text}', '{TopLeftTextBox_2.Text}', '{TopLeftTextBox_3.Text}', '{TopLeftTextBox_4.Text}', '{TopLeftTextBox_5.Text}', '{TopLeftTextBox_6.Text}', '{TopLeftTextBox_7.Text}', '{TopLeftTextBox_8.Text}'," +

            //           $" '{TopRightTextBox_1.Text}', '{TopRightTextBox_2.Text}', '{TopRightTextBox_3.Text}', '{TopRightTextBox_4.Text}', '{TopRightTextBox_5.Text}', '{TopRightTextBox_6.Text}', '{TopRightTextBox_7.Text}', '{TopRightTextBox_8.Text}'," +

            //           $" '{BotRightTextBox_8.Text}', '{BotRightTextBox_7.Text}', '{BotRightTextBox_6.Text}', '{BotRightTextBox_5.Text}', '{BotRightTextBox_4.Text}', '{BotRightTextBox_3.Text}', '{BotRightTextBox_2.Text}', '{BotRightTextBox_1.Text}'," +

            //           $" '{BotLeftTextBox_8.Text}', '{BotLeftTextBox_7.Text}', '{BotLeftTextBox_6.Text}', '{BotLeftTextBox_5.Text}', '{BotLeftTextBox_4.Text}', '{BotLeftTextBox_3.Text}', '{BotLeftTextBox_2.Text}', '{BotLeftTextBox_1.Text}')";
            //    cmd.ExecuteNonQuery();
            //}
            //else
            //{
            //    throw new Exception("Не вибраний паціент, перевірте ще раз!");
            //}
            //testCon.Close();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            Calculator newForm = new Calculator(this);
            newForm.Show();
        }


        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            Settings newForm = new Settings(this);
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

        public Main(Settings otherForm)
        {
            settingsForm = otherForm;
        }

        private void tsmiRemoteControl_Click(object sender, EventArgs e)
        {
            Process.Start(direction);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.DoEvents();
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
                        this.TopRightTextBox_6.Location = new Point(404, 321);
                        this.TopRightTextBox_6.Size = new System.Drawing.Size(150, 150);
                        this.TopRightTextBox_6.BringToFront();
                        break;
                    }
                case 15:
                    {
                        this.TopRightTextBox_7.Location = new Point(404, 321);
                        this.TopRightTextBox_7.Size = new System.Drawing.Size(150, 150);
                        this.TopRightTextBox_7.BringToFront();
                        break;
                    }
                case 16:
                    {
                        this.TopRightTextBox_8.Location = new Point(404, 321);
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
                        this.BotRightTextBox_6.Location = new Point(404, 382);
                        this.BotRightTextBox_6.Size = new System.Drawing.Size(150, 150);
                        this.BotRightTextBox_6.BringToFront();
                        break;
                    }
                case 31:
                    {
                        this.BotRightTextBox_7.Location = new Point(404, 382);
                        this.BotRightTextBox_7.Size = new System.Drawing.Size(150, 150);
                        this.BotRightTextBox_7.BringToFront();
                        break;
                    }
                case 32:
                    {
                        this.BotRightTextBox_8.Location = new Point(404, 382);
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
                        this.TopRightTextBox_6.Location = new Point(440, 321);
                        this.TopRightTextBox_6.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 15:
                    {
                        this.TopRightTextBox_7.Location = new Point(483, 321);
                        this.TopRightTextBox_7.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 16:
                    {
                        this.TopRightTextBox_8.Size = new System.Drawing.Size(21, 21);
                        this.TopRightTextBox_8.Location = new Point(521, 321);
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
                        this.BotRightTextBox_6.Location = new Point(440, 382);
                        this.BotRightTextBox_6.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 31:
                    {
                        this.BotRightTextBox_7.Location = new Point(483, 382);
                        this.BotRightTextBox_7.Size = new System.Drawing.Size(21, 21);
                        break;
                    }
                case 32:
                    {
                        this.BotRightTextBox_8.Location = new Point(521, 382);
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
    } 
} 