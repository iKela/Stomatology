using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Globalization;
using System.Data.SqlClient;

namespace Stomatology
{
    public partial class Login : Form
    {
        SqlConnection testCon = new SqlConnection(@"Data Source=insopdentistry.cywgv3xkqj2b.eu-west-3.rds.amazonaws.com;Initial Catalog=Dentistry;Persist Security Info=True;User ID=iKela;Password=6621Nazar");
        string login;
        string password;
        private void Autauthorization()
        {
            if (txtUsername.TextLength < 8 || txtPassword.TextLength < 8)
            {
                txtError.Text = "Помилка: мінімальна кількість символів повинна дорівнювати або перевишати 8.";
            }


            //if (txtUsername.Text == login && txtPassword.Text == password)
            //{
                MainMenu newForm = new MainMenu();
                newForm.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Перевірьте правильність введення Логіну!");
            //}
        }

        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrance_Click(object sender, EventArgs e)
        {
            Autauthorization();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string query1 = $"SELECT Login, Password From Users";
            testCon.Open();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand(query1, testCon);
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                login = sqlReader["Login"].ToString();
                password = sqlReader["Password"].ToString();
            }
        }

    
    }
}
