namespace pretty_animation
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        int j = 0;
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
        }    
        //Старт анимации
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if(timer1.Enabled) button1.Text = "Pause";
            else button1.Text = "Continue";
        }
        //Проигрывание анимации
        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);
            j++;
            int offSetX = pictureBox1.Width / 2;
            int offSetY = pictureBox1.Height / 2;

            for (float i = 0; i < 30; i += 0.01f)
            {
                double x =  Math.Exp(i * 0.2) * Math.Cos(i * 0.01 * j) + offSetX;
                double y =  Math.Exp(i * 0.2) * Math.Sin(i * 0.01 * j) + offSetY;
                g.DrawEllipse(Pens.Green, new RectangleF((float)x, (float)y, 2, 2));
            }
            pictureBox1.Image = bmp;
        }
    }
}
