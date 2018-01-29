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
            SqlConnection conn = new SqlConnection(@"Data Source = insopdentistry.cywgv3xkqj2b.eu - west - 3.rds.amazonaws.com; Initial Catalog = Dentistry; Persist Security Info = True; User ID = iKela; Password = 6621Nazar");
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
