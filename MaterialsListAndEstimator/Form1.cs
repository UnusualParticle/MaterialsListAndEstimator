using System.Windows.Forms;
using System.IO;
using System.Data;
using System;
using System.Globalization;

namespace MaterialsListAndEstimator
{
    public partial class Form1 : Form
    {
        private double GrandTotal = 0;
        private CultureInfo culture = CultureInfo.GetCultureInfo("en-US");

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

        // updates the subtotal column
        private void MultiplyColumns()
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

        // updates the grand total
        private void AddTotal()
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

        // updates all totals
        private void UpdateTotals()
        {
            MultiplyColumns();
            AddTotal();
        }

        // saves the data to a csv file
        private void SaveFile()
        {
            // Create a SaveFileDialog object
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set the initial directory to the current directory
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;

            // Set the filter to csv files.
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";

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

                    // Add the grand total so it wont have to be calculated by someonee just viewing the .csv file
                    line = "\nGrand Total:       ";
                    line += GrandTotal.ToString("C", culture);
                    writer.WriteLine(line);
                }
            }
        }

        // Clear all the data from the form
        private void ClearTable()
        {
            //Clear the grid
            dataGridView1.Rows.Clear();

            // Reset grandTotal
            GrandTotal = 0;

            // Set value to textBox in bottom left 
            textBox1.Text = "$" + GrandTotal.ToString();
        }

        // load a csv int othe table
        private void LoadFile(string filename)
        {
            // Open the file
            var f = File.OpenText(filename);
            if (f == null) return;

            // If the file can open, clear the data
            ClearTable();

            // read until file end
            while (!f.EndOfStream)
            {
                // get a line with a minimum of 3 fields
                string line = f.ReadLine();
                string[] fields = line.Split(',');
                if (fields.Length < 3)
                    continue;

                // trim any whitespace
                for (int i = 0; i < fields.Length; i++)
                {
                    fields[i] = fields[i].Trim();
                }

                // validate that the data can be used
                double test;
                if (!Double.TryParse(fields[1], out test)
                    || !Double.TryParse(fields[1], out test))
                    continue;

                // add data to the grid
                dataGridView1.Rows.Add(fields);
            }
            f.Close();

            // update totals based on data found
            UpdateTotals();
        }

        // Save Button
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // incase you made a change and didn't click calculate again
            UpdateTotals();
            SaveFile();
        }

        // Calculate Button
        private void buttonCalc_Click(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        // Clear Button
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearTable();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Get the path and name of the selected file
                LoadFile(ofd.FileName);
            }
        }
    }
}
