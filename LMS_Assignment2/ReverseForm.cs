using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using ReverseLibrary;

namespace LMS_Assignment2
{
    public class ReverseForm : Form
    {
        private TextBox numberTextBox;
        private TextBox stringTextBox;
        private Label numberResultLabel;
        private Label stringResultLabel;
        private Button reverseButton;

        public ReverseForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Size = new System.Drawing.Size(400, 300);
            this.Text = "Number and String Reverser";

           
            Label numberLabel = new Label
            {
                Text = "Enter Number:",
                Location = new System.Drawing.Point(20, 20)
            };

            numberTextBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 40),
                Size = new System.Drawing.Size(200, 20)
            };

            numberResultLabel = new Label
            {
                Location = new System.Drawing.Point(20, 70),
                Size = new System.Drawing.Size(200, 20)
            };

           
            Label stringLabel = new Label
            {
                Text = "Enter String:",
                Location = new System.Drawing.Point(20, 100)
            };

            stringTextBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 120),
                Size = new System.Drawing.Size(200, 20)
            };

            stringResultLabel = new Label
            {
                Location = new System.Drawing.Point(20, 150),
                Size = new System.Drawing.Size(200, 20)
            };

         
            reverseButton = new Button
            {
                Text = "Reverse",
                Location = new System.Drawing.Point(20, 180),
                Size = new System.Drawing.Size(200, 30)
            };
            reverseButton.Click += ReverseButton_Click;

            this.Controls.AddRange(new Control[] {
            numberLabel, numberTextBox, numberResultLabel,
            stringLabel, stringTextBox, stringResultLabel,
            reverseButton
        });
        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(numberTextBox.Text, out int number))
            {
                numberResultLabel.Text = $"Reversed Number: {Reverser.ReverseNumber(number)}";
            }

            if (!string.IsNullOrEmpty(stringTextBox.Text))
            {
                stringResultLabel.Text = $"Reversed String: {Reverser.ReverseString(stringTextBox.Text)}";
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new ReverseForm());
        }
    }
}