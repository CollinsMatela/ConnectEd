namespace ConnectEducation
{
    partial class Submit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel3 = new Panel();
            btnAddFile = new Button();
            label3 = new Label();
            ListBoxFiles = new ListBox();
            label2 = new Label();
            richTextBox1 = new RichTextBox();
            panel2 = new Panel();
            label1 = new Label();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            btnSubmit = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(806, 543);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(btnSubmit);
            panel3.Controls.Add(btnAddFile);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(ListBoxFiles);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(richTextBox1);
            panel3.Location = new Point(13, 69);
            panel3.Name = "panel3";
            panel3.Size = new Size(776, 463);
            panel3.TabIndex = 3;
            // 
            // btnAddFile
            // 
            btnAddFile.Location = new Point(671, 216);
            btnAddFile.Name = "btnAddFile";
            btnAddFile.Size = new Size(93, 27);
            btnAddFile.TabIndex = 7;
            btnAddFile.Text = "Add File";
            btnAddFile.UseVisualStyleBackColor = true;
            btnAddFile.Click += btnAddFile_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(16, 225);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 6;
            label3.Text = "Inserted Files";
            // 
            // ListBoxFiles
            // 
            ListBoxFiles.FormattingEnabled = true;
            ListBoxFiles.ItemHeight = 15;
            ListBoxFiles.Location = new Point(15, 249);
            ListBoxFiles.Name = "ListBoxFiles";
            ListBoxFiles.Size = new Size(749, 154);
            ListBoxFiles.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(15, 18);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 4;
            label2.Text = "Type your Answer";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(15, 45);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(749, 162);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(comboBox2);
            panel2.Controls.Add(comboBox1);
            panel2.Location = new Point(13, 14);
            panel2.Name = "panel2";
            panel2.Size = new Size(776, 49);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(15, 17);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 3;
            label1.Text = "Submit your work";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Type of Activity", "Seatwork / Assignment", "Performance Task" });
            comboBox2.Location = new Point(597, 14);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(167, 23);
            comboBox2.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Select a Week", "Week 1", "Week 2", "Week 3", "Week 4", "Week 5", "Week 6", "Week 7", "Week 8" });
            comboBox1.Location = new Point(499, 14);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(92, 23);
            comboBox1.TabIndex = 1;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(671, 418);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(93, 27);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // Submit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 543);
            Controls.Add(panel1);
            Name = "Submit";
            Text = "Submit";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private RichTextBox richTextBox1;
        private ComboBox comboBox1;
        private Panel panel2;
        private ComboBox comboBox2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Panel panel3;
        private ListBox ListBoxFiles;
        private Label label2;
        private Label label3;
        private Button btnAddFile;
        private Button btnSubmit;
    }
}