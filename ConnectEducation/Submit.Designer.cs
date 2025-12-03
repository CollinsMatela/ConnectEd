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
            panel3 = new Panel();
            panel1 = new Panel();
            HandoutNoLabel = new Label();
            InstructorLabel = new Label();
            label3 = new Label();
            label1 = new Label();
            btnSubmit = new Button();
            btnAddFile = new Button();
            ListBoxFiles = new ListBox();
            label2 = new Label();
            AnswerTxt = new RichTextBox();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(panel1);
            panel3.Controls.Add(HandoutNoLabel);
            panel3.Controls.Add(InstructorLabel);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(btnSubmit);
            panel3.Controls.Add(btnAddFile);
            panel3.Controls.Add(ListBoxFiles);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(AnswerTxt);
            panel3.Location = new Point(-1, -2);
            panel3.Name = "panel3";
            panel3.Size = new Size(1465, 742);
            panel3.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Location = new Point(0, 1);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1465, 50);
            panel1.TabIndex = 14;
            // 
            // HandoutNoLabel
            // 
            HandoutNoLabel.AutoSize = true;
            HandoutNoLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HandoutNoLabel.ForeColor = Color.Gray;
            HandoutNoLabel.Location = new Point(206, 112);
            HandoutNoLabel.Name = "HandoutNoLabel";
            HandoutNoLabel.Size = new Size(87, 15);
            HandoutNoLabel.TabIndex = 12;
            HandoutNoLabel.Text = "Type of activity";
            // 
            // InstructorLabel
            // 
            InstructorLabel.AutoSize = true;
            InstructorLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            InstructorLabel.ForeColor = Color.Gray;
            InstructorLabel.Location = new Point(1139, 85);
            InstructorLabel.Name = "InstructorLabel";
            InstructorLabel.Size = new Size(91, 15);
            InstructorLabel.TabIndex = 11;
            InstructorLabel.Text = "Subject Teacher";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(1093, 85);
            label3.Name = "label3";
            label3.Size = new Size(23, 15);
            label3.TabIndex = 10;
            label3.Text = "To:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiBold SemiConden", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(206, 78);
            label1.Name = "label1";
            label1.Size = new Size(170, 23);
            label1.TabIndex = 9;
            label1.Text = "Submission of Activity";
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.DodgerBlue;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(1164, 556);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(93, 38);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnAddFile
            // 
            btnAddFile.BackColor = Color.WhiteSmoke;
            btnAddFile.FlatAppearance.BorderSize = 0;
            btnAddFile.FlatStyle = FlatStyle.Flat;
            btnAddFile.Font = new Font("Bahnschrift SemiCondensed", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddFile.ForeColor = Color.DimGray;
            btnAddFile.Location = new Point(1209, 191);
            btnAddFile.Name = "btnAddFile";
            btnAddFile.Size = new Size(48, 27);
            btnAddFile.TabIndex = 7;
            btnAddFile.Text = "File";
            btnAddFile.UseVisualStyleBackColor = false;
            btnAddFile.Click += btnAddFile_Click;
            // 
            // ListBoxFiles
            // 
            ListBoxFiles.BackColor = Color.White;
            ListBoxFiles.BorderStyle = BorderStyle.None;
            ListBoxFiles.Font = new Font("Segoe Fluent Icons", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ListBoxFiles.ForeColor = Color.DimGray;
            ListBoxFiles.FormattingEnabled = true;
            ListBoxFiles.Location = new Point(206, 392);
            ListBoxFiles.Name = "ListBoxFiles";
            ListBoxFiles.Size = new Size(1051, 144);
            ListBoxFiles.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(206, 197);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 4;
            label2.Text = "Type your Answer";
            // 
            // AnswerTxt
            // 
            AnswerTxt.BackColor = Color.WhiteSmoke;
            AnswerTxt.BorderStyle = BorderStyle.None;
            AnswerTxt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AnswerTxt.Location = new Point(206, 224);
            AnswerTxt.Name = "AnswerTxt";
            AnswerTxt.Size = new Size(1051, 162);
            AnswerTxt.TabIndex = 0;
            AnswerTxt.Text = "";
            // 
            // Submit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1463, 738);
            Controls.Add(panel3);
            Name = "Submit";
            Text = "Submit";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private RichTextBox AnswerTxt;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel3;
        private ListBox ListBoxFiles;
        private Label label2;
        private Button btnAddFile;
        private Button btnSubmit;
        private Label InstructorLabel;
        private Label label3;
        private Label label1;
        private Panel panel1;
        private Label HandoutNoLabel;
    }
}