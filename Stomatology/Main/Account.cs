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
    public partial class Account : Form
    {

        SqlConnection testCon = new SqlConnection(@"Data Source=insopdentistry.cywgv3xkqj2b.eu-west-3.rds.amazonaws.com;Initial Catalog=Dentistry;Persist Security Info=True;User ID=iKela;Password=6621Nazar");

        int number;
        public Account()
        {
            InitializeComponent();
            setTheme();
        }

        private void setTheme()
        {
            switch (Properties.Settings.Default.Theme)
            {
                case 0:
                    {
                        if (this.BackColor != Color.Black)
                        {
                            this.BackColor = Color.Black;
                        }

                        break;
                    }
                case 1:
                    {
                        if (this.BackColor != Color.CornflowerBlue)
                        {
                            this.BackColor = Color.CornflowerBlue;
                        }
                        break;
                    }
                case 2:
                    {
                        if (this.BackColor != Color.LightGray)
                        {
                            this.BackColor = Color.LightGray;
                        }

                        break;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login newForm = new Login();
            this.Close();
        }

        private void setVisible()
        {
            switch(number)
            {
                case 1:
                    {
                        pnlGeneralSettings.Visible = true;
                        pnlSecuritySettings.Visible = false;
                        pnlPolicySettings.Visible = false;
                        break;
                    }
                case 2:
                    {
                        pnlGeneralSettings.Visible = false;
                        pnlSecuritySettings.Visible = true;
                        pnlPolicySettings.Visible = false;
                        break;
                    }
                case 3:
                    {
                        pnlGeneralSettings.Visible = false;
                        pnlSecuritySettings.Visible = false;
                        pnlPolicySettings.Visible = true;
                        break;
                    }
            }
        }
        private void btnGeneral_Click(object sender, EventArgs e)
        {
            number = 1;
            setVisible();
        }

        private void btnSecurity_Click(object sender, EventArgs e)
        {
            number = 2;
            setVisible();
        }

        private void btnPolicy_Click(object sender, EventArgs e)
        {
            number = 3;
            setVisible();
        }

        private void picPhoto_Click(object sender, EventArgs e)
        {
            Bitmap image;

            OpenFileDialog open_dialog = new OpenFileDialog(); 
            open_dialog.Filter = "Image Files(*.BMP;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*"; 
            if (open_dialog.ShowDialog() == DialogResult.OK) 
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    picPhoto.Image = image;
                    picPhoto.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //============
        string user;
        int[] arrears = { 0, 0, 0};
        
        //============
        private void Account_Load(object sender, EventArgs e)
        {
            btnAccountExit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnMainMenu.FlatAppearance.MouseOverBackColor = Color.Transparent;

            string query1 = $"SELECT * From Policy  where  IdUser = '{5}'";
            int i = 0;
            testCon.Open();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand(query1, testCon);
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
               
                arrears[i] = sqlReader["Allow"].GetHashCode();
                
                i++;
            }
            if (arrears[0] == 1)
            { checkBox1.Checked = true; }
            else { checkBox1.Checked = false; }

            if (arrears[1] == 1)
            { checkBox2.Checked = true; }
            else { checkBox2.Checked = false; }

            if (arrears[2] == 1)
            { checkBox3.Checked = true; }
            else { checkBox3.Checked = false; }

            testCon.Close();
            sqlReader.Close();
        }
            private void btnAccountExit_MouseHover(object sender, EventArgs e)
        {
            btnAccountExit.Font = new Font("Times New Roman", 12, FontStyle.Underline);
        }
        private void btnAccountExit_MouseLeave(object sender, EventArgs e)
        {
            btnAccountExit.Font = new Font("Times New Roman", 10, FontStyle.Underline);
        }

        private void btnMainMenu_MouseHover(object sender, EventArgs e)
        {
            btnMainMenu.Size = new Size(37, 37);
        }

        private void btnMainMenu_MouseLeave(object sender, EventArgs e)
        {
            btnMainMenu.Size = new Size(35, 35);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
