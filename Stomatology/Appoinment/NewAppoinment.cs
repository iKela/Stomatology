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
using MetroFramework.Components;
using MetroFramework.Forms;

namespace Stomatology
{
    public partial class NewAppoinment : MetroForm
    {
        SqlConnection testCon = new SqlConnection
        (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GoogleDrive InSoP\Stomatology\Stomatology\DataStomatology.mdf;Integrated Security=True");

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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPatient.Text.Length == 0 || txtDescription.Text.Length == 0)
                    throw new Exception("Не всі поля заповнені!");
                else
                {

                    testCon.Open();
                    SqlCommand cmd = testCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"INSERT INTO Reception (Date, Pacient_Id, Info) " +
                        $"values (N'{dateTimePicker1.Value.ToString("yyyy-MM-dd")}', N'{cmbPatient.Text}', N'{txtDescription.Text}')";
                    cmd.ExecuteNonQuery();

                    dateTimePicker1.Text = ""; cmbPatient.Text = ""; txtDescription.Text = "";
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

        private void button7_Click(object sender, EventArgs e)
        {
            Calculator newForm = new Calculator();
            newForm.Show();
        }
    }
}
