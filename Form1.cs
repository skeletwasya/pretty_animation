namespace pretty_animation
{
    public partial class Form1 : Form
    {
        Bitmap? bmp;
        Graphics? g;
        Func<double, double, PointD>? GetSpiralCoord;
        int j = 0;
        int offSetX;
        int offSetY;
        Color spiralColor;
        Color backColor;
        static readonly double goldenRatio = (Math.Sqrt(5) + 1) / 2;
        List<Func<double, double, PointD>?> spirals = new();
        SolidBrush spiralBrush;
        public Form1()
        {
            InitializeComponent();
            InitGraphics();
            InitParams();
            AddAllSpirals();
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
            //Кнопка остановки анимации не видна при открытии окна
            button2.Visible = false;
            //Установка смещения по x и y
            offSetX = pictureBox1.Width / 2;
            offSetY = pictureBox1.Height / 2;
            //Цвета по умолчанию
            spiralColor = Color.Green;
            backColor = Color.Black;
            spiralBrush = new SolidBrush(spiralColor);
        }
        private void AddAllSpirals()
        {
            spirals.Add(GetLogSpiral);
            spirals.Add(GetArchimedSpiral);
            spirals.Add(GetGoldenSpiral);
        }
        //Получить координаты логарифмической спирали
        private PointD GetLogSpiral(double i, double j)
        {
            
            double x = Math.Exp(i * 0.2) * Math.Cos(i * j * 0.001) + offSetX;
            double y = Math.Exp(i * 0.2) * Math.Sin(i * j * 0.001) + offSetY;
            return new PointD(x, y);
        }
        //Получить координаты архимедовой спирали
        private PointD GetArchimedSpiral(double i, double j)
        {
            double x = i * 50 * Math.Cos(i * j * 0.003) + offSetX;
            double y = i * 50 * Math.Sin(i * j * 0.003) + offSetY;
            return new PointD(x, y);
        }
        //Получить координаты золотой спирали
        private PointD GetGoldenSpiral(double i, double j)
        {
            double x = Math.Pow(goldenRatio, i * j * 0.001 * 2 / Math.PI) * Math.Cos(i * j * 0.001) + offSetX;
            double y = Math.Pow(goldenRatio, i * j * 0.001 * 2 / Math.PI) * Math.Sin(i * j * 0.001) + offSetY;
            return new PointD(x, y);
        }
        
        //Проигрывание анимации
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            int max = 30;
            
            //if (comboBox1.SelectedIndex == 2) max = 6;
            double speed = trackBar1.Value;
            int circleSize = trackBar2.Value;
            if (g == null || GetSpiralCoord == null) throw new Exception("'g' or 'GetSpiralCoord' equal null");
            g.Clear(backColor);
            j++;
            for (double i = 0; i < max; i += 0.01)
            {               
                g.FillEllipse(spiralBrush,
                            (float)GetSpiralCoord(i, j * speed).X, (float)GetSpiralCoord(i, j * speed).Y, circleSize, circleSize);
                
            }
            
            pictureBox1.Image = bmp;
            GC.Collect();
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
        //Кнопка изменения цвета спирали
        private void ChangeSpiralColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button3.BackColor = colorDialog1.Color;
            spiralColor = colorDialog1.Color;
        }
        //Кнопка изменения цвета фона
        private void ChangeBackColorButton_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            button4.BackColor = colorDialog2.Color;
            backColor = colorDialog2.Color;
        }
        //При изменении выбранного элемента comboBox1
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex <= spirals.Count - 1)
            {
                GetSpiralCoord = spirals[comboBox1.SelectedIndex];
            }            
        }
    }
    public class PointD
    {
        public double X {  get; set; }
        public double Y { get; set; }
        public PointD(double x, double y) {  X = x; Y = y; }
    }
}
