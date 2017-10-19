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
        (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\StomatologyData.mdf;Integrated Security=True");

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextboxLastName.Text.Length == 0 || TextboxName.Text.Length == 0 || TextboxFatherName.Text.Length == 0 ||
                    textBoxDate.Text.Length == 0 || textBoxNumber.Text.Length == 0 || textBoxAdress.Text.Length == 0)
                    throw new Exception("Незаповненні дані про працівника!");
                else
                {
                    
                    testCon.Open();
                    SqlCommand cmd = testCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"INSERT INTO Pacient (Surname, Name, FatherName, Birthday, Number, Adress) " +
                        $"values (N'{namebox.Text}', N'{surnamebox.Text}', N'{lastNamebox.Text}', N'{dataBirthbox.Text}', N'{passportbox.Text}', " +
                        $"N'{contactbox.Text}', N'{posadaId}')";
                    cmd.ExecuteNonQuery();
                    namebox.Text = ""; surnamebox.Text = ""; lastNamebox.Text = "";
                    passportbox.Text = ""; contactbox.Text = ""; dataBirthbox.Text = "";
                    testCon.Close();
                    updateTable();
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
