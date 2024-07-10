namespace pretty_animation
{
    public partial class Form1 : Form
    {
        Bitmap? bmp;
        Graphics? g;
        Func<double, int, PointD>? GetSpiralCoord;
        int j = 0;
        int offSetX;
        int offSetY;
        //bool justOpened = true;
        public Form1()
        {
            InitializeComponent();
            InitGraphics();
            InitParams();
        }
        public void InitGraphics()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
        }
        private void InitParams()
        {
            //Рисование логарифмической спирали - значение по умолчанию
            GetSpiralCoord = GetLogSpiral;
            //GetSpiralCoord = GetArchimedSpiral;
            //Кнопка остановки анимации не видна при открытии окна
            button2.Visible = false;
            //Установка смещения по x и y
            offSetX = pictureBox1.Width / 2;
            offSetY = pictureBox1.Height / 2;
        }
        //Получить координаты логарифмической спирали
        private PointD GetLogSpiral(double i, int j)
        {
            double x = Math.Exp(i * 0.2) * Math.Cos(i * 0.01 * j) + offSetX;
            double y = Math.Exp(i * 0.2) * Math.Sin(i * 0.01 * j) + offSetY;
            return new PointD(x, y);
        }
        //Получить координаты архимедовой спирали
        private PointD GetArchimedSpiral(double i, int j)
        {
            double x = i * 50 * Math.Cos(i * 0.03 * j) + offSetX;
            double y = i * 50 * Math.Sin(i * 0.03 * j) + offSetY;
            return new PointD(x, y);
        }
        //Проигрывание анимации
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (g == null || GetSpiralCoord == null) throw new Exception("'g' or 'GetSpiralCoord' equal null");
            g.Clear(pictureBox1.BackColor);
            j++;
            for (double i = 0; i < 30; i += 0.01)
            {
                g.DrawEllipse(Pens.Green, new RectangleF((float)GetSpiralCoord(i, j).X, (float)GetSpiralCoord(i, j).Y, 2, 2));
            }           
            pictureBox1.Image = bmp;
        }

        //Старт анимации
        private void StartButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled) button1.Text = "Pause";
            else button1.Text = "Continue";
            button2.Visible = true;
        }
        //Остановка анимации и очистка всей графики
        private void StopButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            pictureBox1.Image = null;
            j = 0;
            button1.Text = "Start";
            button2.Visible = false;
        }
    }
    public class PointD
    {
        public double X {  get; set; }
        public double Y { get; set; }
        public PointD(double x, double y) {  X = x; Y = y; }
    }
}
