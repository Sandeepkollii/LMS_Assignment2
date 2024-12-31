
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LMS_Assignment2
{
    public class HashSetForm : Form
    {
        private HashSet<string> hashSet;
        private TextBox inputTextBox;
        private ListBox displayListBox;
        private Button addButton;
        private Button removeButton;
        private Button containsButton;
        private Button clearButton;

        public HashSetForm()
        {
            hashSet = new HashSet<string>();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Size = new System.Drawing.Size(400, 500);
            this.Text = "HashSet Operations";

           
            inputTextBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(200, 20)
            };

           
            displayListBox = new ListBox
            {
                Location = new System.Drawing.Point(20, 100),
                Size = new System.Drawing.Size(340, 300)
            };

           
            addButton = new Button
            {
                Text = "Add",
                Location = new System.Drawing.Point(230, 20),
                Size = new System.Drawing.Size(130, 30)
            };
            addButton.Click += AddButton_Click;

           
            removeButton = new Button
            {
                Text = "Remove",
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(130, 30)
            };
            removeButton.Click += RemoveButton_Click;

            
            containsButton = new Button
            {
                Text = "Contains",
                Location = new System.Drawing.Point(160, 60),
                Size = new System.Drawing.Size(130, 30)
            };
            containsButton.Click += ContainsButton_Click;

          
            clearButton = new Button
            {
                Text = "Clear",
                Location = new System.Drawing.Point(300, 60),
                Size = new System.Drawing.Size(60, 30)
            };
            clearButton.Click += ClearButton_Click;

            this.Controls.AddRange(new Control[] {
            inputTextBox, displayListBox, addButton,
            removeButton, containsButton, clearButton
        });
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputTextBox.Text))
            {
                bool added = hashSet.Add(inputTextBox.Text);
                if (!added)
                {
                    MessageBox.Show("Item already exists in the HashSet!");
                }
                UpdateDisplay();
                inputTextBox.Clear();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputTextBox.Text))
            {
                bool removed = hashSet.Remove(inputTextBox.Text);
                if (!removed)
                {
                    MessageBox.Show("Item not found in the HashSet!");
                }
                UpdateDisplay();
                inputTextBox.Clear();
            }
        }

        private void ContainsButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputTextBox.Text))
            {
                bool contains = hashSet.Contains(inputTextBox.Text);
                MessageBox.Show(contains ? "Item found in HashSet!" : "Item not found in HashSet!");
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            hashSet.Clear();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            displayListBox.Items.Clear();
            foreach (var item in hashSet)
            {
                displayListBox.Items.Add(item);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new HashSetForm());
        }
    }
}