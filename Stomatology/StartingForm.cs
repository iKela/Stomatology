using System;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Stomatology
{
    public partial class StartingForm : Form
    {
        #region Trial Section :

        [DllImport("InSoPDentistry.dll", EntryPoint = "ReadSettingsStr", CharSet = CharSet.Ansi)]
        static extern uint InitTrial(String aKeyCode, IntPtr aHWnd);


        [DllImport("InSoPDentistry.dll", EntryPoint = "DisplayRegistrationStr", CharSet = CharSet.Ansi)]
        static extern uint DisplayRegistration(String aKeyCode, IntPtr aHWnd);

        private const string kLibraryKey = "5D15358D11B719CDF20636D26047383D49F0AF61677D36DB0C933A7E7CDB7B424C521971C68A";

        private static void OnInit()
        {
            try
            {
                Process process = Process.GetCurrentProcess();
                InitTrial(kLibraryKey, process.MainWindowHandle);
            }
            catch (DllNotFoundException ex)
            {
                MessageBox.Show(ex.ToString());
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }
        #endregion
        public StartingForm()
        {
            OnInit();
            if (!BGW.IsBusy)
                BGW.RunWorkerAsync();
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
                    if (Properties.Settings.Default.TeamViewerDirection == string.Empty || Properties.Settings.Default.DateBaseDirection == string.Empty)
                    {
                        Settings newForsm = new Settings();
                        newForsm.Show();
                    }
                    else
                    {
                        Main newForma = new Main();
                        newForma.Show();
                    }
                    this.Hide();

                }
            }
            catch(Exception)
            {
                return;
            }
        }
        #region Background Tasks :
        private void BGW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Text = "Trial Application";
        }
        #endregion

    }
}
