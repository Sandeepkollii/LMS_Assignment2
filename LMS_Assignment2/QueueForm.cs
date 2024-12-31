using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LMS_Assignment2
{
    public class QueueForm : Form
    {
        private Queue<string> queue;
        private TextBox inputTextBox;
        private ListBox displayListBox;
        private Button enqueueButton;
        private Button dequeueButton;
        private Button peekButton;
        private Button clearButton;

        public QueueForm()
        {
            queue = new Queue<string>();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Size = new System.Drawing.Size(400, 500);
            this.Text = "Queue Operations";

            // Input TextBox
            inputTextBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(200, 20)
            };

            // Display ListBox
            displayListBox = new ListBox
            {
                Location = new System.Drawing.Point(20, 100),
                Size = new System.Drawing.Size(340, 300)
            };

            // Enqueue Button
            enqueueButton = new Button
            {
                Text = "Enqueue",
                Location = new System.Drawing.Point(230, 20),
                Size = new System.Drawing.Size(130, 30)
            };
            enqueueButton.Click += EnqueueButton_Click;

            // Dequeue Button
            dequeueButton = new Button
            {
                Text = "Dequeue",
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(130, 30)
            };
            dequeueButton.Click += DequeueButton_Click;

            // Peek Button
            peekButton = new Button
            {
                Text = "Peek",
                Location = new System.Drawing.Point(160, 60),
                Size = new System.Drawing.Size(130, 30)
            };
            peekButton.Click += PeekButton_Click;

            // Clear Button
            clearButton = new Button
            {
                Text = "Clear",
                Location = new System.Drawing.Point(300, 60),
                Size = new System.Drawing.Size(60, 30)
            };
            clearButton.Click += ClearButton_Click;

            this.Controls.AddRange(new Control[] {
            inputTextBox, displayListBox, enqueueButton,
            dequeueButton, peekButton, clearButton
        });
        }

        private void EnqueueButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputTextBox.Text))
            {
                queue.Enqueue(inputTextBox.Text);
                UpdateDisplay();
                inputTextBox.Clear();
            }
        }

        private void DequeueButton_Click(object sender, EventArgs e)
        {
            if (queue.Count > 0)
            {
                MessageBox.Show($"Dequeued: {queue.Dequeue()}");
                UpdateDisplay();
            }
        }

        private void PeekButton_Click(object sender, EventArgs e)
        {
            if (queue.Count > 0)
            {
                MessageBox.Show($"Front element: {queue.Peek()}");
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            queue.Clear();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            displayListBox.Items.Clear();
            foreach (var item in queue)
            {
                displayListBox.Items.Add(item);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new QueueForm());
        }
    }
}