using System;
using System.Reflection;
using System.Windows.Forms;

namespace Stomatology
{
    public partial class StartingForm : Form
    {
        public StartingForm()
        {
            InitializeComponent();
            this.lblVersion.Text = String.Format("v. {0}", AssemblyVersion);
            timer1.Start();
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value += 2;
                if(progressBar1.Value >= 100)
                {
                    timer1.Stop();
                    this.Hide();
                    if (Properties.Settings.Default.TeamViewerDirection == string.Empty && Properties.Settings.Default.TeamViewerDirection == string.Empty)
                    {
                        Settings newForsm = new Settings();
                        newForsm.Show();
                    }
                    else 
                    {
                        Main newForma = new Main();
                        newForma.Show();
                    }
                }
            }
            catch(Exception)
            {
                return;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
