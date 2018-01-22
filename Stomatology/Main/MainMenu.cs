using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stomatology
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistry_Click(object sender, EventArgs e)
        {
            Main newForm = new Main();
            newForm.Show();
            this.Close();
        }

        private void btnNewAppoinment_Click(object sender, EventArgs e)
        {
            NewAppoinment newForm = new NewAppoinment();
            newForm.Show();
        }

        private void btnReporting_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            HelpContacts newForm = new HelpContacts();
            newForm.Show();
        }

        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            NewMedCard newForm = new NewMedCard();
            newForm.Show();
        }

        private void btnEditPatient_Click(object sender, EventArgs e)
        {
            EditMedCard newForm = new EditMedCard();
            newForm.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings newForm = new Settings();
            newForm.Show();
        }

        private void showAccount()
        {
            Account newForm = new Account();
            newForm.Show();
        }

        private void btnUsername_Click(object sender, EventArgs e)
        {
            showAccount();
        }

        private void btnUsernameLogo_Click(object sender, EventArgs e)
        {
            showAccount();
        }
    }
}
