using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LMS_Assignment2
{
    public class SortedListForm : Form
    {
        private SortedList<string, string> sortedList;
        private TextBox keyTextBox;
        private TextBox valueTextBox;
        private ListBox displayListBox;
        private Button addButton;
        private Button removeButton;
        private Button containsButton;
        private Button clearButton;

        public SortedListForm()
        {
            sortedList = new SortedList<string, string>();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Size = new System.Drawing.Size(400, 500);
            this.Text = "SortedList Operations";

          
            keyTextBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(100, 20),
                PlaceholderText = "Key"
            };

        
            valueTextBox = new TextBox
            {
                Location = new System.Drawing.Point(130, 20),
                Size = new System.Drawing.Size(100, 20),
                PlaceholderText = "Value"
            };

          
            displayListBox = new ListBox
            {
                Location = new System.Drawing.Point(20, 100),
                Size = new System.Drawing.Size(340, 300)
            };

         
            addButton = new Button
            {
                Text = "Add",
                Location = new System.Drawing.Point(240, 20),
                Size = new System.Drawing.Size(120, 30)
            };
            addButton.Click += AddButton_Click;

        
            removeButton = new Button
            {
                Text = "Remove",
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(100, 30)
            };
            removeButton.Click += RemoveButton_Click;

          
            containsButton = new Button
            {
                Text = "Contains Key",
                Location = new System.Drawing.Point(130, 60),
                Size = new System.Drawing.Size(100, 30)
            };
            containsButton.Click += ContainsButton_Click;

         
            clearButton = new Button
            {
                Text = "Clear",
                Location = new System.Drawing.Point(240, 60),
                Size = new System.Drawing.Size(120, 30)
            };
            clearButton.Click += ClearButton_Click;

            this.Controls.AddRange(new Control[] {
            keyTextBox, valueTextBox, displayListBox,
            addButton, removeButton, containsButton, clearButton
        });
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(keyTextBox.Text) &&
                !string.IsNullOrWhiteSpace(valueTextBox.Text))
            {
                try
                {
                    sortedList.Add(keyTextBox.Text, valueTextBox.Text);
                    UpdateDisplay();
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Key already exists!");
                }
                keyTextBox.Clear();
                valueTextBox.Clear();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(keyTextBox.Text))
            {
                bool removed = sortedList.Remove(keyTextBox.Text);
                if (!removed)
                {
                    MessageBox.Show("Key not found!");
                }
                UpdateDisplay();
                keyTextBox.Clear();
            }
        }

        private void ContainsButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(keyTextBox.Text))
            {
                bool contains = sortedList.ContainsKey(keyTextBox.Text);
                MessageBox.Show(contains ? "Key found!" : "Key not found!");
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            sortedList.Clear();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            displayListBox.Items.Clear();
            foreach (var pair in sortedList)
            {
                displayListBox.Items.Add($"{pair.Key}: {pair.Value}");
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new SortedListForm());
        }
    }
}