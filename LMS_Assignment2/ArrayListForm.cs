using System;
using System.Collections;
using System.Windows.Forms;

namespace LMS_Assignment2
{
    public class ArrayListForm : Form
    {
        private ArrayList arrayList;
        private TextBox inputTextBox;
        private ListBox displayListBox;
        private Button addButton;
        private Button removeButton;
        private Button insertButton;
        private Button clearButton;
        private TextBox indexTextBox;

        public ArrayListForm()
        {
            arrayList = new ArrayList();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Size = new System.Drawing.Size(400, 500);
            this.Text = "ArrayList Operations";

           
            inputTextBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(200, 20)
            };

          
            indexTextBox = new TextBox
            {
                Location = new System.Drawing.Point(230, 20),
                Size = new System.Drawing.Size(50, 20),
                PlaceholderText = "Index"
            };

         
            displayListBox = new ListBox
            {
                Location = new System.Drawing.Point(20, 100),
                Size = new System.Drawing.Size(340, 300)
            };

         
            addButton = new Button
            {
                Text = "Add",
                Location = new System.Drawing.Point(290, 20),
                Size = new System.Drawing.Size(70, 30)
            };
            addButton.Click += AddButton_Click;

           
            removeButton = new Button
            {
                Text = "Remove",
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(100, 30)
            };
            removeButton.Click += RemoveButton_Click;

         
            insertButton = new Button
            {
                Text = "Insert",
                Location = new System.Drawing.Point(130, 60),
                Size = new System.Drawing.Size(100, 30)
            };
            insertButton.Click += InsertButton_Click;

        
            clearButton = new Button
            {
                Text = "Clear",
                Location = new System.Drawing.Point(240, 60),
                Size = new System.Drawing.Size(120, 30)
            };
            clearButton.Click += ClearButton_Click;

            this.Controls.AddRange(new Control[] {
            inputTextBox, indexTextBox, displayListBox,
            addButton, removeButton, insertButton, clearButton
        });
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputTextBox.Text))
            {
                arrayList.Add(inputTextBox.Text);
                UpdateDisplay();
                inputTextBox.Clear();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputTextBox.Text))
            {
                arrayList.Remove(inputTextBox.Text);
                UpdateDisplay();
                inputTextBox.Clear();
            }
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputTextBox.Text) &&
                int.TryParse(indexTextBox.Text, out int index) &&
                index >= 0 && index <= arrayList.Count)
            {
                arrayList.Insert(index, inputTextBox.Text);
                UpdateDisplay();
                inputTextBox.Clear();
                indexTextBox.Clear();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            arrayList.Clear();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            displayListBox.Items.Clear();
            foreach (var item in arrayList)
            {
                displayListBox.Items.Add(item);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new ArrayListForm());
        }
    }
}