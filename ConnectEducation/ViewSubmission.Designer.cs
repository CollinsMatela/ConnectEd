namespace ConnectEducation
{
    partial class ViewSubmission
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
            SubmissionSubjectLabel = new Label();
            SubmissionStudentLabel = new Label();
            SubmissionSectionLabel = new Label();
            SubmissionHandoutLabel = new Label();
            SubmissionActivityLabel = new Label();
            SubmissionDateLabel = new Label();
            SubmissionTextRTB = new RichTextBox();
            label7 = new Label();
            label8 = new Label();
            panel1 = new Panel();
            SubmissionIDLabel = new Label();
            FilesListBox = new ListBox();
            ScoreUpdateBtn = new Button();
            ScoreTxt = new TextBox();
            SuspendLayout();
            // 
            // SubmissionSubjectLabel
            // 
            SubmissionSubjectLabel.AutoSize = true;
            SubmissionSubjectLabel.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SubmissionSubjectLabel.ForeColor = Color.DimGray;
            SubmissionSubjectLabel.Location = new Point(36, 140);
            SubmissionSubjectLabel.Name = "SubmissionSubjectLabel";
            SubmissionSubjectLabel.Size = new Size(48, 19);
            SubmissionSubjectLabel.TabIndex = 0;
            SubmissionSubjectLabel.Text = "Subject";
            // 
            // SubmissionStudentLabel
            // 
            SubmissionStudentLabel.AutoSize = true;
            SubmissionStudentLabel.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SubmissionStudentLabel.ForeColor = Color.DimGray;
            SubmissionStudentLabel.Location = new Point(36, 45);
            SubmissionStudentLabel.Name = "SubmissionStudentLabel";
            SubmissionStudentLabel.Size = new Size(39, 19);
            SubmissionStudentLabel.TabIndex = 1;
            SubmissionStudentLabel.Text = "Name";
            // 
            // SubmissionSectionLabel
            // 
            SubmissionSectionLabel.AutoSize = true;
            SubmissionSectionLabel.Font = new Font("Segoe Fluent Icons", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SubmissionSectionLabel.ForeColor = Color.DimGray;
            SubmissionSectionLabel.Location = new Point(36, 75);
            SubmissionSectionLabel.Name = "SubmissionSectionLabel";
            SubmissionSectionLabel.Size = new Size(38, 13);
            SubmissionSectionLabel.TabIndex = 2;
            SubmissionSectionLabel.Text = "Section";
            // 
            // SubmissionHandoutLabel
            // 
            SubmissionHandoutLabel.AutoSize = true;
            SubmissionHandoutLabel.Font = new Font("Segoe Fluent Icons", 9.75F);
            SubmissionHandoutLabel.ForeColor = Color.DimGray;
            SubmissionHandoutLabel.Location = new Point(36, 170);
            SubmissionHandoutLabel.Name = "SubmissionHandoutLabel";
            SubmissionHandoutLabel.Size = new Size(42, 13);
            SubmissionHandoutLabel.TabIndex = 3;
            SubmissionHandoutLabel.Text = "Handout";
            // 
            // SubmissionActivityLabel
            // 
            SubmissionActivityLabel.AutoSize = true;
            SubmissionActivityLabel.Font = new Font("Segoe Fluent Icons", 9.75F);
            SubmissionActivityLabel.ForeColor = Color.DimGray;
            SubmissionActivityLabel.Location = new Point(94, 170);
            SubmissionActivityLabel.Name = "SubmissionActivityLabel";
            SubmissionActivityLabel.Size = new Size(40, 13);
            SubmissionActivityLabel.TabIndex = 4;
            SubmissionActivityLabel.Text = "Activity";
            // 
            // SubmissionDateLabel
            // 
            SubmissionDateLabel.AutoSize = true;
            SubmissionDateLabel.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SubmissionDateLabel.ForeColor = Color.DimGray;
            SubmissionDateLabel.Location = new Point(446, 140);
            SubmissionDateLabel.Name = "SubmissionDateLabel";
            SubmissionDateLabel.Size = new Size(33, 19);
            SubmissionDateLabel.TabIndex = 5;
            SubmissionDateLabel.Text = "Date";
            // 
            // SubmissionTextRTB
            // 
            SubmissionTextRTB.BackColor = Color.WhiteSmoke;
            SubmissionTextRTB.BorderStyle = BorderStyle.None;
            SubmissionTextRTB.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SubmissionTextRTB.ForeColor = Color.DimGray;
            SubmissionTextRTB.Location = new Point(94, 206);
            SubmissionTextRTB.Name = "SubmissionTextRTB";
            SubmissionTextRTB.Size = new Size(470, 142);
            SubmissionTextRTB.TabIndex = 6;
            SubmissionTextRTB.Text = "";
            SubmissionTextRTB.TextChanged += richTextBox1_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.DimGray;
            label7.Location = new Point(36, 206);
            label7.Name = "label7";
            label7.Size = new Size(48, 19);
            label7.TabIndex = 8;
            label7.Text = "Subject";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.DimGray;
            label8.Location = new Point(36, 367);
            label8.Name = "label8";
            label8.Size = new Size(34, 19);
            label8.TabIndex = 9;
            label8.Text = "Files";
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Location = new Point(-1, 544);
            panel1.Name = "panel1";
            panel1.Size = new Size(625, 55);
            panel1.TabIndex = 10;
            // 
            // SubmissionIDLabel
            // 
            SubmissionIDLabel.AutoSize = true;
            SubmissionIDLabel.Font = new Font("Segoe Fluent Icons", 9.75F);
            SubmissionIDLabel.ForeColor = Color.DimGray;
            SubmissionIDLabel.Location = new Point(388, 75);
            SubmissionIDLabel.Name = "SubmissionIDLabel";
            SubmissionIDLabel.Size = new Size(60, 13);
            SubmissionIDLabel.TabIndex = 12;
            SubmissionIDLabel.Text = "Identification";
            // 
            // FilesListBox
            // 
            FilesListBox.BorderStyle = BorderStyle.None;
            FilesListBox.Font = new Font("Segoe Fluent Icons", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FilesListBox.ForeColor = Color.DimGray;
            FilesListBox.FormattingEnabled = true;
            FilesListBox.Location = new Point(94, 367);
            FilesListBox.Name = "FilesListBox";
            FilesListBox.Size = new Size(470, 144);
            FilesListBox.TabIndex = 11;
            FilesListBox.SelectedIndexChanged += FilesListBox_SelectedIndexChanged;
            // 
            // ScoreUpdateBtn
            // 
            ScoreUpdateBtn.BackColor = Color.DodgerBlue;
            ScoreUpdateBtn.FlatStyle = FlatStyle.Flat;
            ScoreUpdateBtn.Font = new Font("Bahnschrift Condensed", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ScoreUpdateBtn.ForeColor = Color.White;
            ScoreUpdateBtn.Location = new Point(514, 46);
            ScoreUpdateBtn.Name = "ScoreUpdateBtn";
            ScoreUpdateBtn.Size = new Size(50, 24);
            ScoreUpdateBtn.TabIndex = 12;
            ScoreUpdateBtn.Text = "Score";
            ScoreUpdateBtn.UseVisualStyleBackColor = false;
            ScoreUpdateBtn.Click += ScoreUpdateBtn_Click;
            // 
            // ScoreTxt
            // 
            ScoreTxt.BackColor = Color.WhiteSmoke;
            ScoreTxt.BorderStyle = BorderStyle.None;
            ScoreTxt.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ScoreTxt.ForeColor = Color.DimGray;
            ScoreTxt.Location = new Point(473, 46);
            ScoreTxt.Name = "ScoreTxt";
            ScoreTxt.Size = new Size(35, 23);
            ScoreTxt.TabIndex = 14;
            // 
            // ViewSubmission
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(619, 597);
            Controls.Add(SubmissionIDLabel);
            Controls.Add(ScoreTxt);
            Controls.Add(ScoreUpdateBtn);
            Controls.Add(FilesListBox);
            Controls.Add(panel1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(SubmissionTextRTB);
            Controls.Add(SubmissionDateLabel);
            Controls.Add(SubmissionActivityLabel);
            Controls.Add(SubmissionHandoutLabel);
            Controls.Add(SubmissionSectionLabel);
            Controls.Add(SubmissionStudentLabel);
            Controls.Add(SubmissionSubjectLabel);
            Name = "ViewSubmission";
            Text = "ViewSubmission";
            Load += ViewSubmission_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label SubmissionSubjectLabel;
        private Label SubmissionStudentLabel;
        private Label SubmissionSectionLabel;
        private Label SubmissionHandoutLabel;
        private Label SubmissionActivityLabel;
        private Label SubmissionDateLabel;
        private RichTextBox SubmissionTextRTB;
        private Label label7;
        private Label label8;
        private Panel panel1;
        private ListBox FilesListBox;
        private Label SubmissionIDLabel;
        private Button ScoreUpdateBtn;
        private TextBox ScoreTxt;
    }
}