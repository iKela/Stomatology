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
            setTheme();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.txtTVWay.Text = Properties.Settings.Default.TeamViewerDirection;
          //  this.txtBDWay.Text = Properties.Settings.Default.DateBaseDirection;
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
                        if (this.BackColor != Color.Black)
                        {
                            this.BackColor = Color.Black;

                            pnlGeneral.EndColor = Color.Black;
                            pnlGeneral.StartColor = Color.Black;
                            pnlPaths.EndColor = Color.Black;
                            pnlPaths.StartColor = Color.Black;
                            pnlButtons.EndColor = Color.Black;
                            pnlButtons.StartColor = Color.Black;
                            lblTheme.ForeColor = Color.White;
                            gboxAppearance.ForeColor = Color.White;
                            gboxDBPath.ForeColor = Color.White;
                            gboxTVPath.ForeColor = Color.White;
                            lblDBPath.ForeColor = Color.White;
                            lblTVPath.ForeColor = Color.White;
                        }
                        break;
                    }
                case 1:
                    {
                        if (pnlGeneral.EndColor != Color.CornflowerBlue)
                        {
                            this.BackColor = Color.CornflowerBlue;

                            pnlGeneral.EndColor = Color.CornflowerBlue;
                            pnlGeneral.StartColor = Color.CornflowerBlue;
                            pnlPaths.EndColor = Color.CornflowerBlue;
                            pnlPaths.StartColor = Color.CornflowerBlue;
                            pnlButtons.EndColor = Color.CornflowerBlue;
                            pnlButtons.StartColor = Color.CornflowerBlue;
                            lblTheme.ForeColor = Color.Black;
                            gboxAppearance.ForeColor = Color.Black;
                            gboxDBPath.ForeColor = Color.Black;
                            gboxTVPath.ForeColor = Color.Black;
                            lblDBPath.ForeColor = Color.Black;
                            lblTVPath.ForeColor = Color.Black;
                        }
                        break;
                    }
                case 2:
                    {
                        if (pnlGeneral.EndColor != Color.LightGray)
                        {
                            this.BackColor = Color.LightGray;

                            pnlGeneral.EndColor = Color.LightGray;
                            pnlGeneral.StartColor = Color.LightGray;
                            pnlPaths.EndColor = Color.LightGray;
                            pnlPaths.StartColor = Color.LightGray;
                            pnlButtons.EndColor = Color.LightGray;
                            pnlButtons.StartColor = Color.LightGray;
                            lblTheme.ForeColor = Color.Black;
                            gboxAppearance.ForeColor = Color.Black;
                            gboxDBPath.ForeColor = Color.Black;
                            gboxTVPath.ForeColor = Color.Black;
                            lblDBPath.ForeColor = Color.Black;
                            lblTVPath.ForeColor = Color.Black;
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
            //Properties.Settings.Default.DateBaseDirection = txtBDWay.Text;
            //Properties.Settings.Default.Save();
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
