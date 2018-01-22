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

namespace Stomatology
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrance_Click(object sender, EventArgs e)
        {
            if(txtUsername.TextLength < 8 || txtPassword.TextLength < 8)
            {
                txtError.Text = "Помилка: мінімальна кількість символів повинна дорівнювати або перевишати 8.";
            }
            MainMenu newForm = new MainMenu();
            newForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

    
    }
}
