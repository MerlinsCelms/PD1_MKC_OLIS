using System;
using System.Windows.Forms;

namespace OlasSitejs3000
{
    public partial class DifficultyForm : Form
    {
        public string SelectedDifficulty { get; private set; } = "Easy";

        public DifficultyForm()
        {
            this.Text = "Select Difficulty";
            this.Size = new System.Drawing.Size(300, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            Button easyBtn = new Button() { Text = "Easy", Location = new System.Drawing.Point(100, 20), Size = new System.Drawing.Size(100, 30) };
            easyBtn.Click += (s, e) => { SelectedDifficulty = "Easy"; this.DialogResult = DialogResult.OK; this.Close(); };
            this.Controls.Add(easyBtn);

            Button normalBtn = new Button() { Text = "Normal", Location = new System.Drawing.Point(100, 70), Size = new System.Drawing.Size(100, 30) };
            normalBtn.Click += (s, e) => { SelectedDifficulty = "Normal"; this.DialogResult = DialogResult.OK; this.Close(); };
            this.Controls.Add(normalBtn);

            Button insaneBtn = new Button() { Text = "Insane", Location = new System.Drawing.Point(100, 120), Size = new System.Drawing.Size(100, 30) };
            insaneBtn.Click += (s, e) => { SelectedDifficulty = "Insane"; this.DialogResult = DialogResult.OK; this.Close(); };
            this.Controls.Add(insaneBtn);
        }
    }
}
