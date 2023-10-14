namespace MaterialsListAndEstimator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            buttonCalc = new Button();
            dataGridView1 = new DataGridView();
            Column0 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            buttonSave = new Button();
            button_clear = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            buttonLoad = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonCalc
            // 
            buttonCalc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCalc.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCalc.Location = new Point(912, 525);
            buttonCalc.Margin = new Padding(4);
            buttonCalc.Name = "buttonCalc";
            buttonCalc.Size = new Size(95, 46);
            buttonCalc.TabIndex = 1;
            buttonCalc.Text = "Calculate";
            buttonCalc.UseVisualStyleBackColor = true;
            buttonCalc.Click += buttonCalc_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column0, Column1, Column2, Column3 });
            dataGridView1.Location = new Point(13, 13);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(994, 404);
            dataGridView1.TabIndex = 20;
            // 
            // Column0
            // 
            Column0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column0.FillWeight = 500F;
            Column0.HeaderText = "Material Name";
            Column0.Name = "Column0";
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = "0";
            Column1.DefaultCellStyle = dataGridViewCellStyle7;
            Column1.FillWeight = 50F;
            Column1.HeaderText = "Unit Cost";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = "0";
            Column2.DefaultCellStyle = dataGridViewCellStyle8;
            Column2.FillWeight = 50F;
            Column2.HeaderText = "Quantity";
            Column2.Name = "Column2";
            Column2.Resizable = DataGridViewTriState.True;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = "0";
            Column3.DefaultCellStyle = dataGridViewCellStyle9;
            Column3.FillWeight = 150F;
            Column3.HeaderText = "Subtotal";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom;
            buttonSave.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSave.Location = new Point(360, 525);
            buttonSave.Margin = new Padding(4);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(97, 46);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // button_clear
            // 
            button_clear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_clear.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button_clear.Location = new Point(13, 525);
            button_clear.Margin = new Padding(4);
            button_clear.Name = "button_clear";
            button_clear.Size = new Size(100, 46);
            button_clear.TabIndex = 21;
            button_clear.Text = "Clear";
            button_clear.UseVisualStyleBackColor = true;
            button_clear.Click += buttonClear_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox1.Location = new Point(807, 424);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(200, 26);
            textBox1.TabIndex = 22;
            textBox1.Text = "$0";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(720, 427);
            label1.Name = "label1";
            label1.Size = new Size(81, 19);
            label1.TabIndex = 23;
            label1.Text = "Grand Total";
            // 
            // buttonLoad
            // 
            buttonLoad.Anchor = AnchorStyles.Bottom;
            buttonLoad.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLoad.Location = new Point(527, 525);
            buttonLoad.Margin = new Padding(4);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(97, 46);
            buttonLoad.TabIndex = 24;
            buttonLoad.Text = "Load CSV";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 584);
            Controls.Add(buttonLoad);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button_clear);
            Controls.Add(dataGridView1);
            Controls.Add(buttonCalc);
            Controls.Add(buttonSave);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Materials List And Estimator";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonCalc;
        private DataGridView dataGridView1;
        private Button buttonSave;
        private Button button_clear;
        private TextBox textBox1;
        private Label label1;
        private DataGridViewTextBoxColumn Column0;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private Button buttonLoad;
    }
}