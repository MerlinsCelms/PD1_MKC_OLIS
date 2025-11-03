using System;
using System.Drawing;

namespace OlasSitejs3000
{
    public class GameEngine
    {
        public Ball Ball;
        public Paddle RightPaddle;
        public Paddle LeftPaddle;
        public int RightScore;
        public int LeftScore;
        public bool GameOver;
        private string difficulty;
        private Size clientSize;
        private int winScore = 10;

        private int initialSpeedX;
        private int initialSpeedY;

        public GameEngine(Size clientSize, string difficulty = "Easy")
        {
            this.clientSize = clientSize;
            this.difficulty = difficulty;

            Ball = new Ball(clientSize.Width / 2, clientSize.Height / 2);
            RightPaddle = new Paddle(clientSize.Width - 50, clientSize.Height / 2 - 50);
            LeftPaddle = new Paddle(30, clientSize.Height / 2 - 50);

            SetBallSpeedByDifficulty();
        }

        private void SetBallSpeedByDifficulty()
        {
            switch (difficulty)
            {
                case "Easy":
                    initialSpeedX = 10; initialSpeedY = 10; break;
                case "Normal":
                    initialSpeedX = 15; initialSpeedY = 15; break;
                case "Insane":
                    initialSpeedX = 30; initialSpeedY = 30; break;
            }
            Ball.SetSpeed(initialSpeedX, initialSpeedY);
        }

        public void Update()
        {
            if (GameOver) return;

            Ball.Move();

            // Bounce off top/bottom
            if (Ball.Position.Y <= 0 || Ball.Position.Y + Ball.Size.Height >= clientSize.Height)
                Ball.BounceY();

            // Right paddle collision
            if (Ball.Position.X + Ball.Size.Width >= RightPaddle.Position.X &&
                Ball.Position.Y + Ball.Size.Height >= RightPaddle.Position.Y &&
                Ball.Position.Y <= RightPaddle.Position.Y + RightPaddle.Size.Height)
            {
                Ball.BounceX();
            }

            // Left paddle collision
            if (Ball.Position.X <= LeftPaddle.Position.X + LeftPaddle.Size.Width &&
                Ball.Position.Y + Ball.Size.Height >= LeftPaddle.Position.Y &&
                Ball.Position.Y <= LeftPaddle.Position.Y + LeftPaddle.Size.Height)
            {
                Ball.BounceX();
            }

            // AI movement
            int aiSpeed = difficulty == "Easy" ? 3 : difficulty == "Normal" ? 5 : 8;
            if (Ball.Position.Y + Ball.Size.Height / 2 < LeftPaddle.Position.Y + LeftPaddle.Size.Height / 2)
                LeftPaddle.Position = new Point(LeftPaddle.Position.X, Math.Max(0, LeftPaddle.Position.Y - aiSpeed));
            else if (Ball.Position.Y + Ball.Size.Height / 2 > LeftPaddle.Position.Y + LeftPaddle.Size.Height / 2)
                LeftPaddle.Position = new Point(LeftPaddle.Position.X, Math.Min(clientSize.Height - LeftPaddle.Size.Height, LeftPaddle.Position.Y + aiSpeed));

            // Scoring
            if (Ball.Position.X <= 0)
            {
                RightScore++;
                ResetBall();
            }

            if (Ball.Position.X + Ball.Size.Width >= clientSize.Width)
            {
                LeftScore++;
                ResetBall();
            }

            // Check win condition
            if (RightScore >= winScore || LeftScore >= winScore)
                GameOver = true;
        }

        private void ResetBall()
        {
            Ball.Position = new Point(clientSize.Width / 2, clientSize.Height / 2);
            Ball.SetSpeed(initialSpeedX, initialSpeedY);
        }

        public void RestartGame()
        {
            RightScore = 0;
            LeftScore = 0;
            GameOver = false;
            ResetBall();
        }

        public void Draw(Graphics g)
        {
            // Center line
            Pen linePen = new Pen(Color.White, 2);
            int segmentHeight = 20;
            for (int y = 0; y < clientSize.Height; y += segmentHeight * 2)
                g.DrawLine(linePen, clientSize.Width / 2, y, clientSize.Width / 2, y + segmentHeight);

            Ball.Draw(g, Brushes.White);
            RightPaddle.Draw(g, Brushes.White);
            LeftPaddle.Draw(g, Brushes.White);

            using (Font scoreFont = new Font("Arial", 24))
            {
                g.DrawString(LeftScore.ToString(), scoreFont, Brushes.White, clientSize.Width / 4, 20);
                g.DrawString(RightScore.ToString(), scoreFont, Brushes.White, clientSize.Width * 3 / 4, 20);
            }
        }
    }
}
