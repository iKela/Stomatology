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


namespace Stomatology
{
    public partial class EditPatient : Form
    {
        SqlConnection testCon = new SqlConnection
       (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Properties.Settings.Default.DateBaseDirection);

        bool allow = true;
        Main ownerForm = null;
        public EditPatient(Main ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }

        private void EditPatient_Load(object sender, EventArgs e)
        {
            updateTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                allow = false;
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtBirthday.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtPhoneNumber.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
               
            }
            else
            {
                txtBirthday.Clear();
                textBox5.Clear();
                txtPhoneNumber.Clear();
                textBox2.Clear();
            }
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                {
                string uId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();   
                string query = "update Pacient " + $"set Name = N'{textBox5.Text}', " + $"Birthday = N'{txtBirthday.Text}', "
                    + $"Number = N'{txtPhoneNumber.Text}', " + $"Adress = N'{textBox2.Text}' "
                    + $"where Pacient_Id = {uId}";


                testCon.Open();
                SqlCommand upbtn = new SqlCommand(query, testCon);
                upbtn.ExecuteNonQuery();
                testCon.Close();
                updateTable();
                ownerForm.updateTable();

                txtBirthday.Clear();
                textBox5.Clear();
                txtPhoneNumber.Clear();
                textBox2.Clear();   
                dataGridView1.ClearSelection();
            }  
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <1)
            {
                dataGridView1.Rows.Clear();
                testCon.Open();

                string qweryn = $"select * from Pacient where Name  like N'%{textBox5.Text}%'";

                SqlCommand sqlComm = new SqlCommand(qweryn, testCon);
                SqlDataReader sqlDRv;
                sqlDRv = sqlComm.ExecuteReader();
                while (sqlDRv.Read())
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = sqlDRv[0];
                    dataGridView1.Rows[index].Cells[1].Value = sqlDRv[1];
                    dataGridView1.Rows[index].Cells[2].Value = sqlDRv[2];
                    dataGridView1.Rows[index].Cells[3].Value = sqlDRv[3];
                    dataGridView1.Rows[index].Cells[4].Value = sqlDRv[4];

                }
                testCon.Close();
                dataGridView1.ClearSelection();
            }
        }

    }
}

