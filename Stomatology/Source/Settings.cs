using System;
using System.Drawing;
using System.Windows.Forms;

namespace Stomatology
{
    public partial class Settings : Form
    {
        string[] colorsNames = { "Чорно-біла", "Синя", "Біла" };

        int selectedTheme;

        public Settings()
        {
                InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            setTheme();
            cmbThemes.Items.AddRange(colorsNames);

            cmbThemes.SelectedIndex = Properties.Settings.Default.Theme;
            
            //Шляхи до БД та TeamViewer
            //this.txtTVWay.Text = Properties.Settings.Default.TeamViewerDirection;
            //this.txtBDWay.Text = Properties.Settings.Default.DateBaseDirection;
            toolTip();
        }

        private void setTheme()
        {
            switch (Properties.Settings.Default.Theme)
            {
                case 0:
                    {
                        if (Properties.Settings.Default.Theme != 0)
                        {
                            this.BackColor = Color.Black;
                        }
                        break;
                    }
                case 1:
                    {
                        if (Properties.Settings.Default.Theme != 1)
                        {
                            this.BackColor = Color.RoyalBlue;
                        }
                        break;
                    }
                case 2:
                    {
                        if (Properties.Settings.Default.Theme != 2)
                        {
                            this.BackColor = Color.LightGray;
                        }
                        break;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            //Шлях до БД та TeamViewer-------------------------------------------------------------------
            //__________________________________________________________________________________________
           // if (txtBDWay.Text == string.Empty)
           // {
           //     MessageBox.Show("Задайте шлях до бази даних!");
           // }
           // else if (txtTVWay.Text == string.Empty)
           // {
           //     MessageBox.Show("Задайте шлях до TeamViewer!");
           // }
           // else
           // {
           //     foreach (Form Main in Application.OpenForms)
           //     {
           //         if (Main.Name == "Main")
           //         {
           //             this.Close();
           //             return;
           //         }
           //     }
           //     Main newForm = new Main();
           //     newForm.Show();
           //     this.Hide();
           // }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ".mdf file (*.mdf)|*.mdf";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sFileName = openFileDialog1.FileName;
                //string[] arrAllFiles = openFileDialog1.FileNames;           
                txtBDWay.Text = sFileName;
            }
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Team Viewer (*.exe)|*.exe";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false; // Multiselect

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sFileName = openFileDialog1.FileName;
                //string[] arrAllFiles = openFileDialog1.FileNames; // Multiselect          
                txtTVWay.Text = sFileName;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DateBaseDirection = txtBDWay.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TeamViewerDirection = txtTVWay.Text;
            Properties.Settings.Default.Save();
        }

        private void toolTip()
        {
            toolTip1.IsBalloon = false;
            if (txtBDWay.Text == string.Empty)
            {
                toolTip1.SetToolTip(txtBDWay, "Вкажіть шлях до бази даних.");
            }
            else
            {
                toolTip1.SetToolTip(txtBDWay, "Шлях до бази даних.");
            }
            if (txtTVWay.Text == string.Empty)
            {
                toolTip1.SetToolTip(txtTVWay, "Вкажіть шлях до TeamViewer.");
            }
            else
            {
                toolTip1.SetToolTip(txtTVWay, "Шлях до TeamViewer.");
            }
        }

        private void cmbTheme_DrawItem(object sender, DrawItemEventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (selectedTheme != Properties.Settings.Default.Theme)
            {

                Properties.Settings.Default.Theme = selectedTheme;
                Properties.Settings.Default.Save();

                string message = "Для того щоб зберегти зміни, потрібен перезапуск додатку. Ви згідні?";
                string caption = "Увага!.";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        private void cmbThemes_SelectedIndexChanged(object sender, EventArgs e)
        {     
            selectedTheme = cmbThemes.SelectedIndex;
        }

        private void setVisibility(int number)
        {
            switch(number)
            {
                case 1:
                    {
                        pnlGeneral.Visible = true;
                        pnlPaths.Visible = false;
                        break;
                    }
                case 2:
                    {
                        pnlGeneral.Visible = false;
                        pnlPaths.Visible = true;
                        break;
                    }
                default:
                    {
                        pnlGeneral.Visible = true;
                        pnlPaths.Visible = false;
                        break;
                    }
            }
        }
        private void btnPaths_Click(object sender, EventArgs e)
        {
            setVisibility(2);
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            setVisibility(1);
        }
    }
}
