using System.Drawing;

namespace OlasSitejs3000
{
    public abstract class GameObject
    {
        public Point Position { get; set; }
        public Size Size { get; set; }


        public Rectangle Bounds
        {
            get
            {
                int w = Size.Width > 0 ? Size.Width : 1;
                int h = Size.Height > 0 ? Size.Height : 1;
                return new Rectangle(Position.X, Position.Y, w, h);
            }
        }

        public virtual void Draw(Graphics g, Brush brush)
        {
            if (brush == null) return;
            g.FillRectangle(brush, Bounds);
        }
    }
}
