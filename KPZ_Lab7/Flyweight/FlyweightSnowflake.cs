using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_Lab7.Flyweight
{
    class FlyweightSnowflake : Snowflake
    {
        private static Dictionary<string, FlyweightSnowflake> pool = new Dictionary<string, FlyweightSnowflake>();

        public static FlyweightSnowflake GetSnowflake(int size, string shape, Color color)
        {
            string key = size + shape + color.Name;
            if (!pool.ContainsKey(key))
            {
                pool[key] = new FlyweightSnowflake(size, shape, color);
            }
            return pool[key];
        }

        private FlyweightSnowflake(int size, string shape, Color color)
        {
            this.size = size;
            this.shape = shape;
            this.color = color;
        }

        public override void Draw(Graphics g, int x, int y)
        {
            switch (shape)
            {
                case "ellipse": DrawEllipse(g,x,y);  break;
                case "star": DrawStar(g,x,y); break;
                case "Square": break;
            }
        }

        private void DrawEllipse(Graphics g, int x, int y)
        {
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush, x, y, size, size);

            Pen pen = new Pen(Color.White, 2.0f);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            int k = size / 5;
            g.DrawLine(pen, x + k, y + k, x + size - k, y + size - k);
            g.DrawLine(pen, x + k, y + size - k, x + size - k, y + k);
        }

        private void DrawStar(Graphics g, int x, int y)
        {
            Brush brush = new SolidBrush(color);
            PointF[] points = new PointF[10];
            double angle = Math.PI / 5;
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);
            double innerRadius = (size / 2) * sin / cos;
            double outerRadius = (size / 2);
            PointF center = new PointF(x + size / 2, y + size / 2);
            double rot = -Math.PI / 2;
            for (int i = 0; i < 10; i++)
            {
                double x1 = center.X + innerRadius * Math.Cos(rot);
                double y1 = center.Y + innerRadius * Math.Sin(rot);
                double x2 = center.X + outerRadius * Math.Cos(rot + angle / 2);
                double y2 = center.Y + outerRadius * Math.Sin(rot + angle / 2);
                points[i] = new PointF((float)x1, (float)y1);
                points[++i] = new PointF((float)x2, (float)y2);
                rot += angle;
            }
            g.FillPolygon(brush, points);
        }

        private void DrawSquare(Graphics g, int x, int y)
        {
            Brush brush = new SolidBrush(color);
            g.FillRectangle(brush, x, y, size, size);
        }
    }

}
