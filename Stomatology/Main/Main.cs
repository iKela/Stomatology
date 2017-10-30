using System;
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
        SqlConnection testCon = new SqlConnection
     (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GoogleDrive InSoP\Stomatology\Stomatology\DataStomatology.mdf;Integrated Security=True");
        

        public void PassValue(string strValue)
        {
            txtMoney.Text = strValue;
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateTable();
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

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.DoEvents();
        }
    }
}
