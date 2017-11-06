﻿using System;
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
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            toolTip();
            this.txtTVWay.Text = Properties.Settings.Default.TeamViewerDirection;
            this.txtBDWay.Text = Properties.Settings.Default.DateBaseDirection;

            //if (txtBDWay.Text == string.Empty == false || txtTVWay.Text == string.Empty == false)
            //{
            //    Main newForm = new Main();
            //    newForm.Show();
            //    Hide();
            //}
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBDWay.Text == string.Empty)
            {
                MessageBox.Show("Задайте шлях до бази даних!");
            }
            else if (txtTVWay.Text == string.Empty)
            {
                MessageBox.Show("Задайте шлях до TeamViewer!");
            }
            else
            {
                Main newForm = new Main();
                newForm.Show();
                this.Hide();
            }
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
                string[] arrAllFiles = openFileDialog1.FileNames;           
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
    }
}
