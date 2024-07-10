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
        readonly List<Func<double, double, PointD>?> spirals = new();
        SolidBrush? spiralBrush;
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
            //��������� ��������������� ������� - �������� �� ���������
            GetSpiralCoord = GetLogSpiral;
            //������ ��������� �������� �� ����� ��� �������� ����
            button2.Visible = false;
            //��������� �������� �� x � y
            offSetX = pictureBox1.Width / 2;
            offSetY = pictureBox1.Height / 2;
            //����� �� ���������
            spiralColor = Color.Green;
            backColor = Color.Black;
            spiralBrush = new SolidBrush(spiralColor);
        }
        private void AddAllSpirals()
        {
            spirals.Add(GetLogSpiral);
            spirals.Add(GetArchimedSpiral);
            spirals.Add(GetHyperSpiral);
        }
        //�������� ���������� ��������������� �������
        private PointD GetLogSpiral(double i, double j)
        {
            
            double x = Math.Exp(i * 0.2) * Math.Cos(i * j * 0.001) + offSetX;
            double y = Math.Exp(i * 0.2) * Math.Sin(i * j * 0.001) + offSetY;
            return new PointD(x, y);
        }
        //�������� ���������� ����������� �������
        private PointD GetArchimedSpiral(double i, double j)
        {
            double x = i * 50 * Math.Cos(i * j * 0.003) + offSetX;
            double y = i * 50 * Math.Sin(i * j * 0.003) + offSetY;
            return new PointD(x, y);
        }
        //�������� ���������� ��������������� �������
        private PointD GetHyperSpiral(double i, double j)
        {
            double x = 1/i * 50 * Math.Cos(i * j * 0.02) + offSetX;
            double y = 1/i * 50 * Math.Sin(i * j * 0.02) + offSetY;
            return new PointD(x, y);
        }

        //������������ ��������
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (g == null || GetSpiralCoord == null || spiralBrush == null) throw new Exception("'g' or 'GetSpiralCoord' or 'spiralBrush' equal null");

            int max = 30;
            double speed = trackBar1.Value;
            int circleSize = trackBar2.Value;          
            g.Clear(backColor);
            j++;
            for (double i = 0; i < max; i += 0.01)
            {
                float x = (float)GetSpiralCoord(i, j * speed).X;
                float y = (float)GetSpiralCoord(i, j * speed).Y;
                if (x < pictureBox1.Width && x > 0 && y < pictureBox1.Height && y > 0)
                {
                    g.FillEllipse(spiralBrush, x, y, circleSize, circleSize);
                }                
            }
            pictureBox1.Image = bmp;
        }

        //����� ��������
        private void StartButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled) button1.Text = "Pause";
            else button1.Text = "Continue";
            button2.Visible = true;
        }
        //��������� �������� � ������� ���� �������
        private void StopButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            pictureBox1.Image = null;
            j = 0;
            button1.Text = "Start";
            button2.Visible = false;
        }
        //������ ��������� ����� �������
        private void ChangeSpiralColorButton_Click(object sender, EventArgs e)
        {
            if (spiralBrush == null) throw new Exception("'spiralBrush' equals null");
            colorDialog1.ShowDialog();
            button3.BackColor = colorDialog1.Color;
            spiralBrush.Color = colorDialog1.Color;
        }
        //������ ��������� ����� ����
        private void ChangeBackColorButton_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            button4.BackColor = colorDialog2.Color;
            backColor = colorDialog2.Color;
        }
        //��� ��������� ���������� �������� comboBox1
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
