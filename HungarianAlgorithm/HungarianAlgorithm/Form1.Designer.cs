namespace HungarianAlgorithm
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
            dataGridView1 = new DataGridView();
            comboBoxTests = new ComboBox();
            nudSize = new NumericUpDown();
            btnResize = new Button();
            btnSolve = new Button();
            txtLog = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSize).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(433, 426);
            dataGridView1.TabIndex = 0;
            // 
            // comboBoxTests
            // 
            comboBoxTests.FormattingEnabled = true;
            comboBoxTests.Location = new Point(451, 12);
            comboBoxTests.Name = "comboBoxTests";
            comboBoxTests.Size = new Size(121, 23);
            comboBoxTests.TabIndex = 1;
            comboBoxTests.SelectedIndexChanged += comboBoxTests_SelectedIndexChanged;
            // 
            // nudSize
            // 
            nudSize.Location = new Point(578, 13);
            nudSize.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudSize.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nudSize.Name = "nudSize";
            nudSize.Size = new Size(120, 23);
            nudSize.TabIndex = 2;
            nudSize.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // btnResize
            // 
            btnResize.Location = new Point(704, 13);
            btnResize.Name = "btnResize";
            btnResize.Size = new Size(84, 23);
            btnResize.TabIndex = 3;
            btnResize.Text = "Resize";
            btnResize.UseVisualStyleBackColor = true;
            btnResize.Click += btnResize_Click;
            // 
            // btnSolve
            // 
            btnSolve.Location = new Point(704, 42);
            btnSolve.Name = "btnSolve";
            btnSolve.Size = new Size(84, 23);
            btnSolve.TabIndex = 4;
            btnSolve.Text = "Solve";
            btnSolve.UseVisualStyleBackColor = true;
            btnSolve.Click += btnSolve_Click;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(451, 41);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(247, 397);
            txtLog.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtLog);
            Controls.Add(btnSolve);
            Controls.Add(btnResize);
            Controls.Add(nudSize);
            Controls.Add(comboBoxTests);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBoxTests;
        private NumericUpDown nudSize;
        private Button btnResize;
        private Button btnSolve;
        private TextBox txtLog;
    }
}
