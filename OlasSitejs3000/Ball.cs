using System;
using System.Drawing;
using OlasSitejs3000.Properties;

namespace OlasSitejs3000
{
    public class Ball : GameObject
    {
        private int speedX;
        private int speedY;
        private readonly Image ballImage;

        public Ball(int x, int y)
        {
            Position = new Point(x, y);
            Size = new Size(50, 50);
            ballImage = Resources.Martins;
        }

        public void Move()
        {
            Position = new Point(Position.X + speedX, Position.Y + speedY);
        }

        public void BounceX()
        {
            speedX = (int)(-speedX * 1.1); // Increase speed 10% on bounce
        }

        public void BounceY()
        {
            speedY = (int)(-speedY * 1.1);
        }

        public void MultiplySpeed(float factor)
        {
            speedX = (int)(speedX * factor);
            speedY = (int)(speedY * factor);
        }

        public void SetSpeed(int x, int y)
        {
            speedX = x;
            speedY = y;
        }

        public override void Draw(Graphics g, Brush brush)
        {
            if (ballImage != null)
                g.DrawImage(ballImage, new Rectangle(Position, Size));
            else
                g.FillEllipse(brush ?? Brushes.White, new Rectangle(Position, Size));
        }
    }
}
