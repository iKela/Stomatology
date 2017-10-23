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
        (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GoogleDrive InSoP\Stomatology\Stomatology\DataStomatology.mdf;Integrated Security=True");

        public NewPatient()
        {
            InitializeComponent();
        }

        private void NewPatient_Load(object sender, EventArgs e)
        {
           
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) //button to create new patient
        {
            try
            {
                if (TextboxLastName.Text.Length == 0 || TextboxName.Text.Length == 0 || TextboxFatherName.Text.Length == 0 ||
                    textBoxDate.Text.Length == 0 || textBoxNumber.Text.Length == 0 || textBoxAdress.Text.Length == 0)
                    throw new Exception("Не всі поля заповнені!");
                else
                {
                    
                    testCon.Open();
                    SqlCommand cmd = testCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"INSERT INTO Pacient (Surname, Name, FatherName, Birthday, Namber, Adress) " +
                        $"values (N'{TextboxLastName.Text}', N'{TextboxName.Text}', N'{TextboxFatherName.Text}', N'{textBoxDate.Text}', N'{textBoxNumber.Text}', " +
                        $"N'{textBoxAdress.Text}')";
                    cmd.ExecuteNonQuery();

                    TextboxLastName.Text = ""; TextboxName.Text = ""; TextboxFatherName.Text = "";
                    textBoxDate.Text = ""; textBoxNumber.Text = ""; textBoxAdress.Text = "";
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
    }
}
