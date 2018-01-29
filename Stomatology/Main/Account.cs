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
    public partial class Account : Form
    {
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

        private void Account_Load(object sender, EventArgs e)
        {
            btnAccountExit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnMainMenu.FlatAppearance.MouseOverBackColor = Color.Transparent;          
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
    }
}
