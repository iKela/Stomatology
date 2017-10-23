﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Timers;

namespace Stomatology
{
    public partial class Main : Form
    {
        System.Timers.Timer timer;
        int hours, minutes, seconds;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            //Defoult visible of second panel
            panel3.Visible = true;

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;


            //Add column header
            listView1.Columns.Add("Прізвище", 90);
            listView1.Columns.Add("Ім'я", 70);
            listView1.Columns.Add("По-батькові", 90);
            listView1.Columns.Add("Рік народження", 50);
            listView1.Columns.Add("Номер телефону", 150);
            listView1.Columns.Add("Адреса", 200);

            //Add items in the listview
            string[] arr = new string[6];

            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += OnTimeEvent;
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() => 
            {
                seconds += 1;
                if (seconds == 60)
                {
                    seconds = 0;
                    minutes += 1;
                }
                if (minutes == 60)
                {
                    minutes = 0;
                    hours += 1;
                }
                txtResult.Text = string.Format("{0}:{1}:{2}", hours.ToString().PadLeft(2, '0'), minutes.ToString().PadLeft(2, '0'), seconds.ToString().PadLeft(2, '0'));
            }));
           
        }

        private void EditAppoinment_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void AddNewAppoinment_Click(object sender, EventArgs e)
        {
            NewAppoinment newForm = new NewAppoinment();
            newForm.Show();
        }

        private void EditPatient_Click(object sender, EventArgs e)
        {
            EditPatient newForm = new EditPatient();
            newForm.Show();
        }
        private void AddNewPatient_Click(object sender, EventArgs e)
        {
            NewPatient newForm = new NewPatient();
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            timer.Stop();
            txtResult.Text = "00:00:00";
            txtTotal.Text = string.Format("{0}:{1}:{2}", hours.ToString().PadLeft(2, '0'), minutes.ToString().PadLeft(2, '0'), seconds.ToString().PadLeft(2, '0'));
            hours = 0;
            minutes = 0;
            seconds = 0;
            
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bitmap image; //Bitmap для открываемого изображения

            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                    picBox_1.SizeMode = PictureBoxSizeMode.StretchImage;
                    picBox_1.Image = image;
                    picBox_1.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TeethPanel_Click(object sender, EventArgs e)
        {

        }

        private void picBox_2_Click(object sender, EventArgs e)
        {
            Bitmap image; //Bitmap для открываемого изображения

            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                    picBox_2.SizeMode = PictureBoxSizeMode.StretchImage;
                    picBox_2.Image = image;
                    picBox_2.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picBox_3_Click(object sender, EventArgs e)
        {
            Bitmap image; //Bitmap для открываемого изображения

            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                    picBox_3.SizeMode = PictureBoxSizeMode.StretchImage;
                    picBox_3.Image = image;
                    picBox_3.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            Application.DoEvents();
        }
    }
}
