using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Stomatology
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool allow;
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Properties.Settings.Default.DateBaseDirection);
                conn.Open();
                conn.Close();
                allow = true;
            }
            catch
            {
                allow = false;
            }
            if (Properties.Settings.Default.TeamViewerDirection == string.Empty && Properties.Settings.Default.TeamViewerDirection == string.Empty || allow == false)
            {
                Application.Run(new Settings());
            }
            else if (allow == true)
            {
                Application.Run(new Main());
            }
        }
    }
}
