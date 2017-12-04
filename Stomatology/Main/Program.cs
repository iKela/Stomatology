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
            Application.Run(new StartingForm());
            
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Properties.Settings.Default.DateBaseDirection);
                conn.Open();
                conn.Close();
            }
            catch
            {
                return;
            }
        }
    }
}
