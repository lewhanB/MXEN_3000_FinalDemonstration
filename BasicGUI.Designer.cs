using System;

namespace SerialGUISample
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.serial = new System.IO.Ports.SerialPort(this.components);
            this.getIOtimer = new System.Windows.Forms.Timer(this.components);
            this.InputBox1 = new System.Windows.Forms.TextBox();
            this.Send1 = new System.Windows.Forms.Button();
            this.Send2 = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.InputBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.InputBox3 = new System.Windows.Forms.TextBox();
            this.InputBox4 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.stopWatchTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // serial
            // 
            this.serial.PortName = "COM4";
            // 
            // getIOtimer
            // 
            this.getIOtimer.Enabled = true;
            this.getIOtimer.Interval = 10;
            this.getIOtimer.Tick += new System.EventHandler(this.getIOtimer_Tick);
            // 
            // InputBox1
            // 
            this.InputBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBox1.Location = new System.Drawing.Point(227, 172);
            this.InputBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InputBox1.Name = "InputBox1";
            this.InputBox1.Size = new System.Drawing.Size(187, 39);
            this.InputBox1.TabIndex = 0;
            this.InputBox1.Text = "0";
            this.InputBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Send1
            // 
            this.Send1.BackColor = System.Drawing.Color.LimeGreen;
            this.Send1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send1.Location = new System.Drawing.Point(29, 47);
            this.Send1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Send1.Name = "Send1";
            this.Send1.Size = new System.Drawing.Size(170, 46);
            this.Send1.TabIndex = 4;
            this.Send1.Text = "START";
            this.Send1.UseVisualStyleBackColor = false;
            this.Send1.Click += new System.EventHandler(this.Send1_Click);
            // 
            // Send2
            // 
            this.Send2.BackColor = System.Drawing.Color.Red;
            this.Send2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send2.Location = new System.Drawing.Point(29, 134);
            this.Send2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Send2.Name = "Send2";
            this.Send2.Size = new System.Drawing.Size(170, 46);
            this.Send2.TabIndex = 4;
            this.Send2.Text = "STOP";
            this.Send2.UseVisualStyleBackColor = false;
            this.Send2.Click += new System.EventHandler(this.Send2_Click);
            // 
            // statusBox
            // 
            this.statusBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBox.Location = new System.Drawing.Point(143, 423);
            this.statusBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(187, 29);
            this.statusBox.TabIndex = 5;
            // 
            // InputBox2
            // 
            this.InputBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBox2.Location = new System.Drawing.Point(466, 172);
            this.InputBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InputBox2.Name = "InputBox2";
            this.InputBox2.Size = new System.Drawing.Size(187, 39);
            this.InputBox2.TabIndex = 0;
            this.InputBox2.Text = "0";
            this.InputBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(395, 423);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 29);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Teal;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(225, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Left Sensor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(392, 388);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Select COM Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(501, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "Right Sensor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(225, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 32);
            this.label4.TabIndex = 11;
            this.label4.Text = "Left Motor Duty %";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(462, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(228, 32);
            this.label5.TabIndex = 12;
            this.label5.Text = "Right Motor Duty %";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.SteelBlue;
            this.progressBar1.Location = new System.Drawing.Point(227, 266);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(187, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // progressBar2
            // 
            this.progressBar2.ForeColor = System.Drawing.Color.SteelBlue;
            this.progressBar2.Location = new System.Drawing.Point(467, 266);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(187, 23);
            this.progressBar2.TabIndex = 16;
            // 
            // InputBox3
            // 
            this.InputBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBox3.Location = new System.Drawing.Point(227, 316);
            this.InputBox3.Name = "InputBox3";
            this.InputBox3.Size = new System.Drawing.Size(187, 39);
            this.InputBox3.TabIndex = 17;
            this.InputBox3.Text = "0";
            this.InputBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // InputBox4
            // 
            this.InputBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBox4.Location = new System.Drawing.Point(467, 316);
            this.InputBox4.Name = "InputBox4";
            this.InputBox4.Size = new System.Drawing.Size(187, 39);
            this.InputBox4.TabIndex = 18;
            this.InputBox4.Text = "0";
            this.InputBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(29, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 48);
            this.button1.TabIndex = 19;
            this.button1.Text = "Calibrate Sensors";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(300, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(298, 35);
            this.textBox1.TabIndex = 20;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stopWatchTimer
            // 
            this.stopWatchTimer.Tick += new System.EventHandler(this.stopWatchTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(690, 524);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InputBox4);
            this.Controls.Add(this.InputBox3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.Send2);
            this.Controls.Add(this.Send1);
            this.Controls.Add(this.InputBox2);
            this.Controls.Add(this.InputBox1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Desgin Project GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Timer getIOtimer;
        private System.Windows.Forms.TextBox InputBox1;
        private System.IO.Ports.SerialPort serial;
        private System.Windows.Forms.Button Send1;
        private System.Windows.Forms.Button Send2;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.TextBox InputBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.TextBox InputBox3;
        private System.Windows.Forms.TextBox InputBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer stopWatchTimer;
    }
}

