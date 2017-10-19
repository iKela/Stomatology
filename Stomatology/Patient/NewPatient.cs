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
        (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Program development\Stomatology\StomatologyData.mdf;Integrated Security=True");

        public NewPatient()
        {
            InitializeComponent();
        }

        private void NewPatient_Load(object sender, EventArgs e)
        {
           // testCon.Open();
           // SqlCommand cmd = testCon.CreateCommand();
           // cmd.CommandType = CommandType.Text;
           // cmd.CommandText = $"INSERT INTO Client (Адрес) values('1')";
           // cmd.ExecuteNonQuery();
           // testCon.Close();
           // //updateTable();
           // testCon.Open();
           // //string uId = clientDataGridView.Rows[clientDataGridView.Rows.Count - 1].Cells[0].Value.ToString();
           //// string query = $"delete from Client where id = {uId}";
           //// SqlCommand cmd1 = new SqlCommand(query, testCon);
           // cmd1.ExecuteNonQuery();
           // testCon.Close();
           // //updateTable();
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

                    //string query = $"select * from [Posada] where Посада = N'{posadaComboBox.Text}'";
                    //SqlCommand cmd1 = new SqlCommand(query, testCon);
                   // SqlDataReader reader = cmd1.ExecuteReader();
                    //string posadaId = "";
                    //if (reader.Read())
                    //{
                    //    posadaId = reader["Id"].ToString();
                    //}
                    //else
                    //{
                    //    throw new Exception("Не вдалось знайти таку посаду, перевірте ще раз!");
                    //}

                    //testCon.Close();

                    testCon.Open();
                    SqlCommand cmd = testCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"INSERT INTO People (Name, Прізвище, Побатькові, Дата_народження, Паспорт_серія, Контакт, id_Posada) " +
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
