namespace Stomatology
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.EditAppoinment = new System.Windows.Forms.Button();
            this.AddNewAppoinment = new System.Windows.Forms.Button();
            this.EditPatient = new System.Windows.Forms.Button();
            this.AddNewPatient = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.StopTimerButton = new System.Windows.Forms.Button();
            this.StartTimerButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(519, 407);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(511, 381);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(511, 381);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button1.Location = new System.Drawing.Point(48, 942);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Додати нового паціента";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button2.Location = new System.Drawing.Point(195, 942);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Редагувати";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.EditPatient_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button3.Location = new System.Drawing.Point(460, 942);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Додати новий прийом";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.AddNewAppoinment_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button4.Location = new System.Drawing.Point(607, 942);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(141, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Редагувати прийом";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.EditAppoinment_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage3);
            this.TabControl.Controls.Add(this.tabPage4);
            this.TabControl.Location = new System.Drawing.Point(-4, -1);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1454, 697);
            this.TabControl.TabIndex = 9;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.EditAppoinment);
            this.tabPage3.Controls.Add(this.AddNewAppoinment);
            this.tabPage3.Controls.Add(this.EditPatient);
            this.tabPage3.Controls.Add(this.AddNewPatient);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1446, 671);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Головна";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Location = new System.Drawing.Point(12, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 600);
            this.panel2.TabIndex = 14;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.AutoArrange = false;
            this.listView1.Location = new System.Drawing.Point(-2, -2);
            this.listView1.MaximumSize = new System.Drawing.Size(700, 600);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(700, 600);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(718, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 600);
            this.panel1.TabIndex = 13;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(128, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // EditAppoinment
            // 
            this.EditAppoinment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditAppoinment.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.EditAppoinment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.EditAppoinment.ForeColor = System.Drawing.SystemColors.InfoText;
            this.EditAppoinment.Location = new System.Drawing.Point(571, 627);
            this.EditAppoinment.Name = "EditAppoinment";
            this.EditAppoinment.Size = new System.Drawing.Size(141, 23);
            this.EditAppoinment.TabIndex = 12;
            this.EditAppoinment.Text = "Редагувати прийом";
            this.EditAppoinment.UseVisualStyleBackColor = false;
            // 
            // AddNewAppoinment
            // 
            this.AddNewAppoinment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddNewAppoinment.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AddNewAppoinment.ForeColor = System.Drawing.SystemColors.InfoText;
            this.AddNewAppoinment.Location = new System.Drawing.Point(424, 627);
            this.AddNewAppoinment.Name = "AddNewAppoinment";
            this.AddNewAppoinment.Size = new System.Drawing.Size(141, 23);
            this.AddNewAppoinment.TabIndex = 11;
            this.AddNewAppoinment.Text = "Додати новий прийом";
            this.AddNewAppoinment.UseVisualStyleBackColor = false;
            // 
            // EditPatient
            // 
            this.EditPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditPatient.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.EditPatient.ForeColor = System.Drawing.SystemColors.InfoText;
            this.EditPatient.Location = new System.Drawing.Point(159, 627);
            this.EditPatient.Name = "EditPatient";
            this.EditPatient.Size = new System.Drawing.Size(141, 23);
            this.EditPatient.TabIndex = 10;
            this.EditPatient.Text = "Редагувати";
            this.EditPatient.UseVisualStyleBackColor = false;
            // 
            // AddNewPatient
            // 
            this.AddNewPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddNewPatient.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AddNewPatient.ForeColor = System.Drawing.SystemColors.InfoText;
            this.AddNewPatient.Location = new System.Drawing.Point(12, 627);
            this.AddNewPatient.Name = "AddNewPatient";
            this.AddNewPatient.Size = new System.Drawing.Size(141, 23);
            this.AddNewPatient.TabIndex = 9;
            this.AddNewPatient.Text = "Додати нового паціента";
            this.AddNewPatient.UseVisualStyleBackColor = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.TimerLabel);
            this.tabPage4.Controls.Add(this.textBox2);
            this.tabPage4.Controls.Add(this.StopTimerButton);
            this.tabPage4.Controls.Add(this.StartTimerButton);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1446, 671);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Таймер";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Arial", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimerLabel.Location = new System.Drawing.Point(447, 190);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(284, 107);
            this.TimerLabel.TabIndex = 4;
            this.TimerLabel.Text = "00:00";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(465, 105);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(254, 20);
            this.textBox2.TabIndex = 3;
            // 
            // StopTimerButton
            // 
            this.StopTimerButton.Location = new System.Drawing.Point(797, 374);
            this.StopTimerButton.Name = "StopTimerButton";
            this.StopTimerButton.Size = new System.Drawing.Size(75, 23);
            this.StopTimerButton.TabIndex = 2;
            this.StopTimerButton.Text = "Стоп";
            this.StopTimerButton.UseVisualStyleBackColor = true;
            this.StopTimerButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // StartTimerButton
            // 
            this.StartTimerButton.Location = new System.Drawing.Point(355, 371);
            this.StartTimerButton.Name = "StartTimerButton";
            this.StartTimerButton.Size = new System.Drawing.Size(100, 91);
            this.StartTimerButton.TabIndex = 1;
            this.StartTimerButton.Text = "Старт";
            this.StartTimerButton.UseVisualStyleBackColor = true;
            this.StartTimerButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1446, 692);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(1462, 1200);
            this.MinimumSize = new System.Drawing.Size(1462, 700);
            this.Name = "Main";
            this.Text = "Стоматологія";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button EditAppoinment;
        private System.Windows.Forms.Button AddNewAppoinment;
        private System.Windows.Forms.Button EditPatient;
        private System.Windows.Forms.Button AddNewPatient;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button StopTimerButton;
        private System.Windows.Forms.Button StartTimerButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label TimerLabel;
    }
}

