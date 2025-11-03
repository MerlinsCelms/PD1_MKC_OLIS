using System;
using System.Windows.Forms;

namespace OlasSitejs3000
{
    public partial class NameForm : Form
    {
        public string PlayerName { get; private set; }

        public NameForm()
        {
            InitializeComponent();
            this.Text = "Ievadi vārdu";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new System.Drawing.Size(300, 150);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var label = new Label() { Text = "Ievadi savu vārdu:", AutoSize = true, Location = new System.Drawing.Point(30, 20) };
            var textBox = new TextBox() { Location = new System.Drawing.Point(30, 50), Width = 220 };
            var okButton = new Button() { Text = "OK", Location = new System.Drawing.Point(90, 80), DialogResult = DialogResult.OK };

            this.Controls.Add(label);
            this.Controls.Add(textBox);
            this.Controls.Add(okButton);

            this.AcceptButton = okButton;

            okButton.Click += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    PlayerName = textBox.Text.Trim();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lūdzu, ievadi vārdu!");
                }
            };
        }
    }
}
