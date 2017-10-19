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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;

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
            ListViewItem itm;
        }
        private void EditAppoinment_Click(object sender, EventArgs e)
        {
            EditAppoinment newForm = new EditAppoinment();
            newForm.Show();
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
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }
    }
}
