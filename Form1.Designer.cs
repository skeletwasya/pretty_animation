namespace pretty_animation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            button2 = new Button();
            colorDialog1 = new ColorDialog();
            button3 = new Button();
            button4 = new Button();
            colorDialog2 = new ColorDialog();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Location = new Point(135, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(629, 609);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(825, 278);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += StartButton_Click;
            // 
            // timer1
            // 
            timer1.Interval = 10;
            timer1.Tick += MainTimer_Tick;
            // 
            // button2
            // 
            button2.Location = new Point(825, 345);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = true;
            button2.Click += StopButton_Click;
            // 
            // colorDialog1
            // 
            colorDialog1.Color = Color.Lime;
            // 
            // button3
            // 
            button3.BackColor = Color.Lime;
            button3.Location = new Point(844, 536);
            button3.Name = "button3";
            button3.Size = new Size(35, 35);
            button3.TabIndex = 3;
            button3.UseVisualStyleBackColor = false;
            button3.Click += ChangeSpiralColorButton_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Black;
            button4.Location = new Point(844, 592);
            button4.Name = "button4";
            button4.Size = new Size(35, 35);
            button4.TabIndex = 4;
            button4.UseVisualStyleBackColor = false;
            button4.Click += ChangeBackColorButton_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(792, 425);
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(143, 45);
            trackBar1.TabIndex = 5;
            trackBar1.Value = 1;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(792, 476);
            trackBar2.Minimum = 1;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(143, 45);
            trackBar2.TabIndex = 6;
            trackBar2.Value = 1;
            // 
            // comboBox1
            // 
            comboBox1.Items.AddRange(new object[] { "Логарифмическая", "Архимедова", "Гиперболическая"});
            comboBox1.Location = new Point(792, 127);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(143, 23);
            comboBox1.TabIndex = 7;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(947, 694);
            Controls.Add(comboBox1);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private System.Windows.Forms.Timer timer1;
        private Button button2;
        private ColorDialog colorDialog1;
        private Button button3;
        private Button button4;
        private ColorDialog colorDialog2;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private ComboBox comboBox1;
    }
}
