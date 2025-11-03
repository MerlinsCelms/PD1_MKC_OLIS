using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OlasSitejs3000
{
    public partial class Form1 : Form
    {
        private GameEngine game;
        private bool moveUp;
        private bool moveDown;
        private Timer gameTimer = new Timer();
        private string playerName;
        private string selectedDifficulty = "Easy";

        public Form1()
        {
            InitializeComponent();
            this.Text = "OluSitējs3000";
            this.ClientSize = new Size(1280, 720);
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;

            // Select difficulty
            using (var diffForm = new DifficultyForm())
            {
                if (diffForm.ShowDialog() == DialogResult.OK)
                    selectedDifficulty = diffForm.SelectedDifficulty;
            }

            // Player name
            using (var nameForm = new NameForm())
            {
                if (nameForm.ShowDialog() == DialogResult.OK)
                    playerName = nameForm.PlayerName;
                else
                    playerName = "Player";
            }

            game = new GameEngine(this.ClientSize, selectedDifficulty);

            gameTimer.Interval = 20; // ~50 FPS
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            this.KeyDown += KeyIsDown;
            this.KeyUp += KeyIsUp;
            this.Paint += DrawGame;
        }

        private void GameLoop(object sender, EventArgs e)
        {
            if (!game.GameOver)
            {
                if (moveUp) game.RightPaddle.MoveUp();
                if (moveDown) game.RightPaddle.MoveDown(this.ClientSize.Height);

                game.Update();
            }
            else
            {
                gameTimer.Stop();
                string winner = game.RightScore >= 10 ? "You win!" : "AI wins!";
                var result = MessageBox.Show($"{winner}\nDo you want to play again?", "Game Over",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                SaveScore(playerName, game.RightScore, selectedDifficulty);

                if (result == DialogResult.Yes)
                {
                    game.RestartGame();
                    gameTimer.Start();
                }
                else
                {
                    Application.Exit();
                }
            }

            Invalidate();
        }

        private void DrawGame(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) moveUp = true;
            if (e.KeyCode == Keys.Down) moveDown = true;

            if (e.KeyCode == Keys.Escape)
                PauseGame();
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) moveUp = false;
            if (e.KeyCode == Keys.Down) moveDown = false;
        }

        private void PauseGame()
        {
            gameTimer.Stop();
            using (PauseMenuForm pauseMenu = new PauseMenuForm())
            {
                pauseMenu.ShowDialog(this);

                if (pauseMenu.ResumeClicked)
                {
                    gameTimer.Start();
                }
                else if (pauseMenu.ExitClicked)
                {
                    Application.Exit();
                }
                else if (pauseMenu.MainMenuClicked)
                {
                    this.Hide(); // hide current game form
                    using (var mainMenu = new DifficultyForm()) // your difficulty selection form
                    {
                        if (mainMenu.ShowDialog() == DialogResult.OK)
                        {
                            selectedDifficulty = mainMenu.SelectedDifficulty;
                            game = new GameEngine(this.ClientSize, selectedDifficulty);
                            gameTimer.Start();
                            this.Show(); // show game form again
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                }
            }
        }


        private void SaveScore(string name, int score, string difficulty)
        {
            string filePath = "HighScores.txt";
            string line = $"[{difficulty}] {DateTime.Now}: {name} - {score}";
            File.AppendAllText(filePath, line + Environment.NewLine);
        }
    }
}
