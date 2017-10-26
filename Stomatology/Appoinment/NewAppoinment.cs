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
    public partial class NewAppoinment : Form
    {
        SqlConnection testCon = new SqlConnection
        (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GoogleDrive InSoP\Stomatology\Stomatology\DataStomatology.mdf;Integrated Security=True");

        public void PassValue(string strValue)
        {
            txtMoney.Text = strValue;
        }

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
            testCon.Open();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT Name FROM [Pacient]", testCon);
            try
            {
                sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    cmbPatient.Items.Add(Convert.ToString(sqlReader["Name"]));
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
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPatient.Text.Length == 0 || txtDescription.Text.Length == 0)
                    throw new Exception("Не всі поля заповнені!");
                else
                {
                    if (string.IsNullOrEmpty(cmbPatient.Text)) throw new Exception("Виберіть  Паціента!");

                    testCon.Open();

                    string query = $"select * from [Pacient] where [Name] = N'{cmbPatient.Text}'";
                    SqlCommand cmd1 = new SqlCommand(query, testCon);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    string PacientId = "";

                    if (reader.Read())
                    {
                        PacientId = reader["Id"].ToString();
                    }
                    else
                    {
                        throw new Exception("Не вибраний працівник, перевірте ще раз!");
                    }
                    testCon.Close();

                    testCon.Open();
                    SqlCommand cmd = testCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"INSERT INTO Reception (Date, Pacient_Id, Info, Teeth_Id) values (N'{dateTimePicker1.Text}', N'{PacientId}', N'{txtDescription.Text}')";
                    cmd.ExecuteNonQuery();
                    //numberBox.Text = "";
                    //markBox.Text = "";
                    //modelBox.Text = "";
                    //yearBox.Text = "";
                    //peopleComboBox.Text = "";
                    //testCon.Close();
                    //updateTable();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                testCon.Close();
            }
        }

        //cmd.CommandText = $"INSERT INTO Reception (Date, Pacient_Id, Info) " +
        //    $"values (N'{dateTimePicker1.Value.ToString("yyyy-MM-dd")}', N'{cmbPatient.Text}', N'{txtDescription.Text}')";
        //cmd.ExecuteNonQuery();

        //dateTimePicker1.Text = ""; cmbPatient.Text = ""; txtDescription.Text = "";
        //MessageBox.Show("Додано нового паціента.");
        //testCon.Close();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        testCon.Close();
        //    }
        //}

        private void button7_Click(object sender, EventArgs e)
        {
            Calculator newForm = new Calculator(this);
            newForm.Show();
        }
    }
}
