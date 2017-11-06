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
    public partial class NewPatient : Form
    {
        SqlConnection testCon = new SqlConnection
        (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Properties.Settings.Default.DateBaseDirection);

        Main ownerform = null;

        public NewPatient(Main ownerform)
        {
            InitializeComponent();
            this.ownerform = ownerform;
        }

        private void NewPatient_Load(object sender, EventArgs e)
        {
         String.Format("{0:(###) ###-####}", 8005551212);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) //button to create new patient
        { 
            try
            {
                if (TextboxLastName.Text.Length == 0|| dtpPatient.Text.Length == 0 || txtNumber.Text.Length == 0 || textBoxAdress.Text.Length == 0)
                    throw new Exception("Не всі поля заповнені!");
                else
                {
                    
                    testCon.Open();
                    SqlCommand cmd = testCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"INSERT INTO Pacient (Name, Birthday, Number, Adress) " +
                        $"values (N'{TextboxLastName.Text}', N'{dtpPatient.Value.Date.ToString("dd/MM/yyyy")}', N'{txtNumber.Text}', " +
                        $"N'{textBoxAdress.Text}')";
                    cmd.ExecuteNonQuery();

                    TextboxLastName.Text = ""; dtpPatient.Text = ""; txtNumber.Text = ""; textBoxAdress.Text = "";
                    MessageBox.Show("Додано нового паціента.");

                    ownerform.updateTable();
                    testCon.Close();
                    
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                testCon.Close();
                
            }
            
        }
        private void button1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
