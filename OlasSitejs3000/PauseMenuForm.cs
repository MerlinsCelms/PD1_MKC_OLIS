using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OlasSitejs3000
{
    public partial class PauseMenuForm : Form
    {
        public bool ResumeClicked { get; private set; } = false;
        public bool ExitClicked { get; private set; } = false;
        public bool MainMenuClicked { get; private set; } = false;

        public PauseMenuForm()
        {
            this.Text = "Pause Menu";
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(300, 250);
            this.BackColor = Color.DarkSlateGray;
            this.ForeColor = Color.White;

            // Resume Button
            Button resumeBtn = new Button()
            {
                Text = "Resume",
                Location = new Point(100, 20),
                Size = new Size(100, 30),
                BackColor = Color.Gray,
                ForeColor = Color.White
            };
            resumeBtn.Click += (s, e) => { ResumeClicked = true; this.Close(); };
            this.Controls.Add(resumeBtn);

            // High Scores Button
            Button scoresBtn = new Button()
            {
                Text = "High Scores",
                Location = new Point(100, 70),
                Size = new Size(100, 30),
                BackColor = Color.Gray,
                ForeColor = Color.White
            };
            scoresBtn.Click += (s, e) =>
            {
                string easy = LoadHighScores("Easy");
                string normal = LoadHighScores("Normal");
                string insane = LoadHighScores("Insane");

                MessageBox.Show(
                    $"---Easy---\n{easy}\n\n---Normal---\n{normal}\n\n---Insane---\n{insane}",
                    "High Scores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            };
            this.Controls.Add(scoresBtn);

            // Main Menu Button
            Button mainMenuBtn = new Button()
            {
                Text = "Main Menu",
                Location = new Point(100, 120),
                Size = new Size(100, 30),
                BackColor = Color.Gray,
                ForeColor = Color.White
            };
            mainMenuBtn.Click += (s, e) => { MainMenuClicked = true; this.Close(); };
            this.Controls.Add(mainMenuBtn);

            // Exit Button
            Button exitBtn = new Button()
            {
                Text = "Exit Game",
                Location = new Point(100, 170),
                Size = new Size(100, 30),
                BackColor = Color.Gray,
                ForeColor = Color.White
            };
            exitBtn.Click += (s, e) => { ExitClicked = true; this.Close(); };
            this.Controls.Add(exitBtn);
        }

        private string LoadHighScores(string difficulty)
        {
            string filePath = "HighScores.txt";
            if (!File.Exists(filePath)) return "No saved scores.";

            var lines = File.ReadAllLines(filePath);
            var filtered = Array.FindAll(lines, l => l.StartsWith($"[{difficulty}]"));
            return string.Join(Environment.NewLine, filtered);
        }
    }
}
