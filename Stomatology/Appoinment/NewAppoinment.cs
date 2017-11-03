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

        string[] Doctor = { "Кричильський Леонід Ростиславович", " Кричильська Тетяна Георгіївна", "Яскал Зоряна Миколаївна" }; 
      
        
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
            cmbPatient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPatient.AutoCompleteSource = AutoCompleteSource.ListItems;

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
            comboBoxDoctor.Items.AddRange(Doctor);
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
                    string PacientId = "";
                    string query = $"select * from Pacient where [Name] = N'{cmbPatient.Text}'";
                    SqlCommand cmd1 = new SqlCommand(query, testCon);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        PacientId = reader["Pacient_Id"].ToString();
                    }
                    else
                    {
                        throw new Exception("Не вибраний паціент, перевірте ще раз!");
                    }
                    testCon.Close();
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
                    testCon.Open();
                    SqlCommand cmd = testCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"INSERT INTO Reception (Date, Pacient_Id, Info, Money, tlt1, tlt2, tlt3, tlt4, tlt5, tlt6, tlt7, tlt8, " +
                        $"trt1, trt2, trt3, trt4, trt5, trt6, trt7, trt8, " +
                        $"brt1, brt2, brt3, brt4, brt5, brt6, brt7, brt8, " +
                        $"blt1, blt2, blt3, blt4, blt5, blt6, blt7, blt8, Doctor)" +
                        $"values (N'{dateTimePicker1.Value.Date.ToString("dd/MM/yyyy")}', '{PacientId}', N'{txtDescription.Text}', N'{txtMoney.Text}', "+

                        $" N'{TopLeftTextBox_1.Text}', N'{TopLeftTextBox_2.Text}',   N'{TopLeftTextBox_3.Text}', N'{TopLeftTextBox_4.Text}', N'{TopLeftTextBox_5.Text}', N'{TopLeftTextBox_6.Text}', N'{TopLeftTextBox_7.Text}', N'{TopLeftTextBox_8.Text}'," +
                        $" N'{TopRightTextBox_1.Text}', N'{TopRightTextBox_2.Text}', N'{TopRightTextBox_3.Text}', N'{TopRightTextBox_4.Text}', N'{TopRightTextBox_5.Text}', N'{TopRightTextBox_6.Text}', N'{TopRightTextBox_7.Text}', N'{TopRightTextBox_8.Text}'," +  
                        $" N'{BotRightTextBox_8.Text}', N'{BotRightTextBox_7.Text}', N'{BotRightTextBox_6.Text}', N'{BotRightTextBox_5.Text}', N'{BotRightTextBox_4.Text}', N'{BotRightTextBox_3.Text}', N'{BotRightTextBox_2.Text}', N'{BotRightTextBox_1.Text}'," +                          
                        $" N'{BotLeftTextBox_8.Text}',  N'{BotLeftTextBox_7.Text}',  N'{BotLeftTextBox_6.Text}', N'{BotLeftTextBox_5.Text}', N'{BotLeftTextBox_4.Text}', N'{BotLeftTextBox_3.Text}', N'{BotLeftTextBox_2.Text}', N'{BotLeftTextBox_1.Text}', N'{comboBoxDoctor.SelectedItem}')";
                 
                    cmd.ExecuteNonQuery();                                                                                                                                                                  
                                                                                                                                                                               
                    Buttonclear();
                    MessageBox.Show("Додано новий прийом.");
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
            Calculator newForm = new Calculator(this);                                                              
            newForm.Show();                                                                                     
        }                                                                                                       
                                                                                                                
        public void Buttonclear()                                                                               
        {
            txtMoney.Text = "";
            txtDescription.Text = "";
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
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             
                                                                                             