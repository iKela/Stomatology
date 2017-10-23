using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
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
       (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GoogleDrive InSoP\Stomatology\Stomatology\DataStomatology.mdf;Integrated Security=True");
        public EditPatient()
        {
            InitializeComponent();
        }

        private void EditPatient_Load(object sender, EventArgs e)
        {
            testCon.Open();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT Surname FROM [Pacient]", testCon); 
            try
            {
                sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    comboBox1.Items.Add(Convert.ToString(sqlReader["Surname"]));                  
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0 || textBox3.Text.Length == 0 || textBox2.Text.Length == 0 ||
                    textBox1.Text.Length == 0 || textBox6.Text.Length == 0)
                throw new Exception("Незаповненні дані про працівника!");
            else
            {
                if (string.IsNullOrEmpty(comboBox1.Text)) throw new Exception("Виберіть посаду працівника!");
                testCon.Open();

                string query = $"select * from [Posada] where Посада = N'{comboBox1.Text}'";
                SqlCommand cmd1 = new SqlCommand(query, testCon);
                SqlDataReader reader = cmd1.ExecuteReader();
                string posadaId = "";
                if (reader.Read())
                {
                    posadaId = reader["Id"].ToString();
                }
                else
                {
                    throw new Exception("Не вдалось знайти таку посаду, перевірте ще раз!");
                }

                testCon.Close();

                //testCon.Open();
                //SqlCommand cmd = testCon.CreateCommand();
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = $"INSERT INTO People (Name, Прізвище, Побатькові, Дата_народження, Паспорт_серія, Контакт, id_Posada) " +
                //    $"values (N'{namebox.Text}', N'{surnamebox.Text}', N'{lastNamebox.Text}', N'{dataBirthbox.Text}', N'{passportbox.Text}', " +
                //    $"N'{contactbox.Text}', N'{posadaId}')";
                //cmd.ExecuteNonQuery();
                //namebox.Text = ""; surnamebox.Text = ""; lastNamebox.Text = "";
                //passportbox.Text = ""; contactbox.Text = ""; dataBirthbox.Text = "";
                //testCon.Close();
                //updateTable();
            }
        }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    testCon.Close();
            //}
}
    }

