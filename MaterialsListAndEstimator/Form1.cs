using System.Windows.Forms;
using System.IO;
using System.Data;
using System;

namespace MaterialsListAndEstimator
{
    public partial class Form1 : Form
    {
        private double GrandTotal = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Add event handlers for CellValidating
            dataGridView1.CellValidating += DataGridView1_CellValidating;
        }

        private void DataGridView1_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Column1"].Index || // Unit Cost column
                e.ColumnIndex == dataGridView1.Columns["Column2"].Index)   // Quantity column
            {
                // Convert value in either box to string
                string value = e.FormattedValue.ToString();

                // If conversion to int fails then it is not an int, throw error
                if (!Double.TryParse(value, out double result))
                {
                    e.Cancel = true;
                    MessageBox.Show("Unit Cost and/or Quantity must be numerical.  Clear the box and try again.", "Error");
                }
            }
        }

        private void MultiplyColumns(object sender, EventArgs e)
        {
            // Get the DataGridView
            DataGridView dataGridView = this.dataGridView1;

            // Get the indexes of the 2nd and 3rd columns
            int columnIndex1 = dataGridView.Columns["Column1"].Index; // Unit Cost column
            int columnIndex2 = dataGridView.Columns["Column2"].Index; // Quantity column

            // Loop through all rows
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                // Get the values of the 2nd and 3rd columns
                double value1 = Convert.ToDouble(dataGridView.Rows[i].Cells[columnIndex1].Value);
                double value2 = Convert.ToDouble(dataGridView.Rows[i].Cells[columnIndex2].Value);

                // Multiply the values and set the value in the 4th column
                dataGridView.Rows[i].Cells[3].Value = value1 * value2;
            }
        }

        private void AddTotal(object sender, EventArgs e)
        {
            // Get the DataGridView
            DataGridView dataGridView = this.dataGridView1;

            // Get the index of the 4th column
            int columnIndex3 = dataGridView.Columns["Column3"].Index; //Subtotal column

            // Reset grandTotal
            GrandTotal = 0;

            // Loop through all rows
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                // Get the values of the 4th columns
                double value3 = Convert.ToDouble(dataGridView.Rows[i].Cells[columnIndex3].Value);

                // Increment grand total by each subtotal
                GrandTotal += value3;
            }
            // Set value to textBox in bottom left
            textBox1.Text = "$" + GrandTotal.ToString();
        }

        private void Save(object sender, EventArgs e)
        {
            // Create a SaveFileDialog object
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set the initial directory to the current directory
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;

            // Set the filter to text files.
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";

            // Show the SaveFileDialog.
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path and name of the selected file
                string fileName = saveFileDialog.FileName;

                // Create a StreamWriter object to write to the file
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    string line = "Name, Unit Cost, Quantity, Subtotal \n";

                    //This for loop loops through each row in the table except the last one it is the empty row that always gets created
                    for (int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
                    {
                        //This for loop loops loops loop through each column. Loop.
                        for (int j = 0; j <= dataGridView1.Columns.Count - 1; j++)
                        {
                            line = line + dataGridView1.Rows[i].Cells[j].Value;

                            if (j != dataGridView1.Columns.Count - 1)
                            {
                                //A comma and 7 spaced are added to separate each field in the text file
                                line = line + ",       ";
                            }
                        }

                        // check for empty but doesn't work idk, look into it
                        if (line != "")
                        {
                            // Write the text to the file
                            writer.WriteLine(line);
                            line = "";
                        }

                    }
                }
            }
        }

        // Save Button
        private void button1_Click(object sender, EventArgs e)
        {
            // incase you made a change and didn't click calculate again
            MultiplyColumns(sender, e);
            AddTotal(sender, e);
            Save(sender, e);
        }

        // Calculate Button
        private void button2_Click(object sender, EventArgs e)
        {
            MultiplyColumns(sender, e);
            AddTotal(sender, e);
        }

        // Clear Button
        private void button3_Click(object sender, EventArgs e)
        {
            //Clear the grid
            dataGridView1.Rows.Clear();

            // Reset grandTotal
            GrandTotal = 0;

            // Set value to textBox in bottom left 
            textBox1.Text = "$" + GrandTotal.ToString();
        }
    }
}
