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
    public partial class Calculator : Form
    {
        float a, b;
        int count;
        bool open = true;
        bool allow = true;

        Main ownerForm = null;
        NewAppoinment ownerForm2 = null;
        
        public Calculator(Main ownerForm)
        {
            if (open == true)
            {
                InitializeComponent();
                this.ownerForm = ownerForm;
                open = false;
                allow = true;
            }

        }
        public Calculator(NewAppoinment ownerForm2)
        {
            if (open == true)
            {
                InitializeComponent();
                this.ownerForm2 = ownerForm2;
                open = false;
                allow = false;
            }
        }

        public static bool flag = true;
        bool signallow = true;

        private void btn0_Click(object sender, EventArgs e)
        {
            if(signallow == true)
               txtTotal.Text = txtTotal.Text + 0;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (signallow == true)
                txtTotal.Text = txtTotal.Text + 1;

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (signallow == true)
                txtTotal.Text = txtTotal.Text + 2;

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (signallow == true)
                txtTotal.Text = txtTotal.Text + 3;

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (signallow == true)
                txtTotal.Text = txtTotal.Text + 4;

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (signallow == true)
                txtTotal.Text = txtTotal.Text + 5;

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (signallow == true)
                txtTotal.Text = txtTotal.Text + 6;

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (signallow == true)
                txtTotal.Text = txtTotal.Text + 7;

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (signallow == true)
                txtTotal.Text = txtTotal.Text + 8;

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (signallow == true)
                txtTotal.Text = txtTotal.Text + 9;

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Count();
            if (txtTotal.Text == String.Empty)
            {
                MessageBox.Show("Невірний синтаксис!");
            }
            else if(lblCurResult.Text == string.Empty)
            {
                signallow = true;
                a = float.Parse(txtTotal.Text);
                txtTotal.Clear();
                count = 1;
                lblCurResult.Text = a.ToString() + " +";

            }
            else
            {
                signallow = true;
                b = a + float.Parse(txtTotal.Text);
                a = b;
                txtTotal.Clear();
                count = 1;
                lblCurResult.Text = b.ToString() + " +";

            }

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            Count();

            if (txtTotal.Text == String.Empty)
            {
                MessageBox.Show("Невірний синтаксис!");
            }
            else if (lblCurResult.Text == string.Empty)
            {
                signallow = true;

                a = float.Parse(txtTotal.Text);
                txtTotal.Clear();
                count = 2;
                lblCurResult.Text = a.ToString() + " -";


            }
            else
            {
                signallow = true;

                b = a - float.Parse(txtTotal.Text);
                a = b;
                txtTotal.Clear();
                count = 2;
                lblCurResult.Text = b.ToString() + " -";


            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            Count();

            if (txtTotal.Text == String.Empty)
            {
                MessageBox.Show("Невірний синтаксис!");
            }
            else if (lblCurResult.Text == string.Empty)
            {
                signallow = true;

                a = float.Parse(txtTotal.Text);
                txtTotal.Clear();
                count = 3;
                lblCurResult.Text = a.ToString() + " *";
            }
            else
            {
                signallow = true;


                b = a * float.Parse(txtTotal.Text);
                a = b;
                txtTotal.Clear();
                count = 3;
                lblCurResult.Text = b.ToString() + " *";
            }
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            Count();

            if (txtTotal.Text == String.Empty)
            {
                MessageBox.Show("Невірний синтаксис!");
            }
            else if (lblCurResult.Text == string.Empty)
            {
                signallow = true;

                a = float.Parse(txtTotal.Text);
                txtTotal.Clear();
                count = 4;
                lblCurResult.Text = a.ToString() + " /";
            }
            else
            {
                signallow = true;


                b = a / float.Parse(txtTotal.Text);
                a = b;
                txtTotal.Clear();
                count = 4;
                lblCurResult.Text = b.ToString() + " /";
            }

        }

        private void calculate()
        {
            switch (count)
            {
                case 1:
                    b = a + float.Parse(txtTotal.Text);
                    txtTotal.Text = b.ToString();
                    break;
                case 2:
                    b = a - float.Parse(txtTotal.Text);
                    txtTotal.Text = b.ToString();
                    break;
                case 3:
                    b = a * float.Parse(txtTotal.Text);
                    txtTotal.Text = b.ToString();
                    break;
                case 4:
                    b = a / float.Parse(txtTotal.Text);
                    txtTotal.Text = b.ToString();
                    break;

                default:
                    break;
            }

        }

        private void Count()
        {
            if (txtTotal.Text == String.Empty)
            {
                MessageBox.Show("Невірний синтаксис!");
            }
            else
            {
                calculate();
                signallow = false;
                lblCurResult.Text = "";

            }
        }
        private void btnEquel_Click(object sender, EventArgs e)
        {
            Count();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            signallow = true;

            txtTotal.Text = "";
            lblCurResult.Text = "";
            a = 0;
            b = 0;
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            int lenght = txtTotal.Text.Length - 1;
            string text = txtTotal.Text;
            txtTotal.Clear();
            for (int i = 0; i < lenght; i++)
            {
                txtTotal.Text = txtTotal.Text + text[i];
            }
        }
        
        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.R))
            {
                //Assuming button5 will set the value 5
                btnPlus.PerformClick();
            }
            if (e.KeyCode.Equals(Keys.Oemplus))
            {
                //Assuming button5 will set the value 5
                btnPlus.PerformClick();
            }

        }


        private void Calculator_Load(object sender, EventArgs e)
        {        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (allow == true)
            {
                this.ownerForm.PassValue(txtTotal.Text);
                this.Close();
            }
            else if (allow == false)
            {
                this.ownerForm2.PassValue(txtTotal.Text);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            signallow = true;

            txtTotal.Text = txtTotal.Text + ",";
        }
    }
}
