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
        }

        private void btnSecurity_Click(object sender, EventArgs e)
        {
            number = 2;
        }

        private void btnPolicy_Click(object sender, EventArgs e)
        {
            number = 3;
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
            //GetUserCountryByIp("");
           // listBoxLoginLocation.Items.Add(GetUserCountryByIp(""));
        }

        #region GetLocation
        public static string GetUserCountryByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRI1.NativeName;
            }
            catch (Exception)
            {
                ipInfo.Country = null;
            }

            return ipInfo.Country;
        }

        #endregion


    }
}
