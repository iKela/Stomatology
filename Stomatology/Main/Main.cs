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

        int count;

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
        string PacientId;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Items.Clear();
            if (dataGridView1.SelectedRows.Count > 0)
            {
               PacientId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
               textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
               string birthday = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
               string number = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
               string adress = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                testCon.Open();
                SqlDataReader sqlReader = null;
                string qwery = $"SELECT Date FROM [Reception] where Pacient_Id = N'{PacientId}'";
                SqlCommand command = new SqlCommand(qwery, testCon);
               
                    sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        comboBox1.Items.Add(Convert.ToString(sqlReader["Date"]));
                    }
                
                sqlReader.Close();
                testCon.Close();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }
        string ReceptionId = "";  //-----------------------------------------------------------------------------------------------------------------------------------------------------
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
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

        private void TopLeftTextBox_8_Click(object sender, EventArgs e)
        {

        }


        private void TopLeftTextBox_8_MouseHover(object sender, EventArgs e)
        {
            this.TopLeftTextBox_8.Size = new System.Drawing.Size(150, 150);
            this.TopLeftTextBox_8.BringToFront();
        }

        private void TopLeftTextBox_8_MouseLeave(object sender, EventArgs e)
        {
            this.TopLeftTextBox_8.Size = new System.Drawing.Size(21, 21);

        }
        public void Buttonclear()
        {
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

    }
}
