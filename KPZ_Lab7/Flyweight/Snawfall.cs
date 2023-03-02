using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_Lab7.Flyweight
{
    class Snowfall
    {
        private List<Snowflake> snowflakes = new List<Snowflake>();

        public void AddSnowflake(int size, string shape, Color color, int x, int y)
        {
            Snowflake snowflake = FlyweightSnowflake.GetSnowflake(size, shape, color);
            snowflakes.Add(snowflake);
            snowflake.Draw(Graphics.FromHwnd(IntPtr.Zero), x, y);
        }
    }

}
