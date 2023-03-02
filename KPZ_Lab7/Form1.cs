using KPZ_Lab7.Flyweight;

namespace KPZ_Lab7
{
    public partial class Form1 : Form
    {

        private Snowfall snowfall;

        private Random rnd;
        public Form1()
        {
            InitializeComponent();

            snowfall = new Snowfall();

            rnd = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            snowfall.AddSnowflake(rnd.Next(3, 40), RandomShape(), RandomColor() , rnd.Next(0, 780), rnd.Next(1920));
        }

        private string RandomShape()
        {
            string[] shapes = { "ellipse", "star", "Square" };

            return shapes[rnd.Next(0, shapes.Length)];
        }

        private Color RandomColor()
        {
            Color[] colors = { Color.AliceBlue, Color.Blue, Color.White, Color.Aqua, Color.AntiqueWhite };
            return colors[rnd.Next(0, colors.Length)];
        }
    }
}