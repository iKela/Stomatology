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
            // MessageBox.Show("IP: " + GetUserIpByIp("")+ "\nHostname: " + GetUserHostnameByIp("") + "\nCity: " + GetUserCityByIp("") + "\nRegion: " + GetUserRegionByIp("") + "\nCountry: " + GetUserCountryByIp("") + "\nLocation: " + GetUserLocByIp("") + "\nOrganization: " + GetUserOrgByIp("") + "\nPostal: " + GetUserPostalByIp("") + "\nTime: " + DateTime.Now);
        }

        public static string GetUserIpByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                StringInfo msdsd = new StringInfo(ipInfo.Ip);
                ipInfo.Ip = msdsd.String;
            }
            catch (Exception)
            {
                ipInfo.Ip = null;
            }

            return ipInfo.Ip;
        }
        
        public static string GetUserHostnameByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                StringInfo msdsd = new StringInfo(ipInfo.Hostname);
                ipInfo.Hostname = msdsd.String;
            }
            catch (Exception)
            {
                ipInfo.Hostname = null;
            }
        
            return ipInfo.Hostname;
        }
        public static string GetUserCityByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                StringInfo msdsd = new StringInfo(ipInfo.City);
                ipInfo.City = msdsd.String;
            }
            catch (Exception)
            {
                ipInfo.City = null;
            }

            return ipInfo.City;
        }
        public static string GetUserRegionByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                StringInfo msdsd = new StringInfo(ipInfo.Region);
                ipInfo.Region = msdsd.String;
            }
            catch (Exception)
            {
                ipInfo.Region = null;
            }

            return ipInfo.Region;
        }
        public static string GetUserCountryByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRI1.EnglishName;
            }
            catch (Exception)
            {
                ipInfo.Country = null;
            }

            return ipInfo.Country;
        }
        public static string GetUserLocByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                StringInfo msdsd = new StringInfo(ipInfo.Loc);
                ipInfo.Loc = msdsd.String;
            }
            catch (Exception)
            {
                ipInfo.Loc = null;
            }
            return ipInfo.Loc;
        }

        public static string GetUserOrgByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                StringInfo msdsd = new StringInfo(ipInfo.Org);
                ipInfo.Org = msdsd.String;
            }
            catch (Exception)
            {
                ipInfo.Org = null;
            }

            return ipInfo.Org;
        }
        public static string GetUserPostalByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                StringInfo msdsd = new StringInfo(ipInfo.Postal);
                ipInfo.Postal = msdsd.String;
            }
            catch (Exception)
            {
                ipInfo.Postal = null;
            }

            return ipInfo.Postal;
        }

        private void btnEntrance_MouseHover(object sender, EventArgs e)
        {
            btnEntrance.Size = new Size(81, 31); 
            btnEntrance.Location = new Point(301, 309);
        }

        private void btnEntrance_MouseLeave(object sender, EventArgs e)
        {
            btnEntrance.Size = new Size(79, 29);
            btnEntrance.Location = new Point(297, 313);
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.Size = new Size(81, 31);
            btnExit.Location = new Point(455, 309);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.Size = new Size(79, 29);
            btnExit.Location = new Point(460, 313);
        }
    }
}
