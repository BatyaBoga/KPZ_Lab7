

namespace KPZ_Lab7.Flyweight
{
    abstract class Snowflake
    {
        protected int size;
        protected string shape;
        protected Color color;

        public abstract void Draw(Graphics g, int x, int y);
    }

}
