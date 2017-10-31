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
    public partial class Settings : Form
    {
        Main ownerForm = null;

        public Settings(Main ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ownerForm.PassDirValue(textBox2.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sFileName = openFileDialog1.FileName;
                string[] arrAllFiles = openFileDialog1.FileNames;           
                textBox1.Text = sFileName;
            }
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false; // Multiselect

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sFileName = openFileDialog1.FileName;
                //string[] arrAllFiles = openFileDialog1.FileNames; // Multiselect          
                textBox2.Text = sFileName;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TeamViewerDirection = textBox2.Text;
            Properties.Settings.Default.Save();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.textBox2.Text = Properties.Settings.Default.TeamViewerDirection;
        }
    }
}
