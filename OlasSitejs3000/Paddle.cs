using System;
using System.Drawing;

namespace OlasSitejs3000
{
    public class Paddle : GameObject
    {
        public Paddle(int x, int y)
        {
            Position = new Point(x, y);
            Size = new Size(20, 100);
        }

        public void MoveUp()
        {
            Position = new Point(Position.X, Math.Max(0, Position.Y - 10));
        }

        public void MoveDown(int clientHeight)
        {
            Position = new Point(Position.X, Math.Min(clientHeight - Size.Height, Position.Y + 10));
        }

        public override void Draw(Graphics g, Brush brush)
        {
            if (brush == null) brush = Brushes.White;
            g.FillRectangle(brush, new Rectangle(Position, Size));
        }
    }
}
