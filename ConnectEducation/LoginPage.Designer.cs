namespace ConnectEducation
{
    partial class LoginPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPage));
            loginPanel = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            typeOfUserCb = new ComboBox();
            EnterBtn = new Button();
            UsernameTxt = new TextBox();
            PasswordTxt = new TextBox();
            pictureBox1 = new PictureBox();
            ExBtn = new Button();
            loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // loginPanel
            // 
            loginPanel.BackColor = Color.White;
            loginPanel.Controls.Add(label6);
            loginPanel.Controls.Add(label5);
            loginPanel.Controls.Add(label4);
            loginPanel.Controls.Add(label3);
            loginPanel.Controls.Add(label2);
            loginPanel.Controls.Add(label1);
            loginPanel.Controls.Add(typeOfUserCb);
            loginPanel.Controls.Add(EnterBtn);
            loginPanel.Controls.Add(UsernameTxt);
            loginPanel.Controls.Add(PasswordTxt);
            loginPanel.Location = new Point(524, 149);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(409, 411);
            loginPanel.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(25, 25, 25);
            label6.Location = new Point(128, 72);
            label6.Name = "label6";
            label6.Size = new Size(171, 32);
            label6.TabIndex = 13;
            label6.Text = "HAWTHORNE SENIOR HIGH SCHOOL\r\nMANAGEMENT SYSTEM\r\n";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(25, 25, 25);
            label5.Location = new Point(151, 43);
            label5.Name = "label5";
            label5.Size = new Size(126, 29);
            label5.TabIndex = 12;
            label5.Text = "CONNECT ED";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe Fluent Icons", 11.25F);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(110, 115);
            label4.Name = "label4";
            label4.Size = new Size(205, 15);
            label4.TabIndex = 11;
            label4.Text = "Welcome back, Please enter your details";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Fluent Icons", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(56, 149);
            label3.Name = "label3";
            label3.Size = new Size(61, 13);
            label3.TabIndex = 8;
            label3.Text = "Type of user";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Fluent Icons", 9.75F);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(56, 258);
            label2.Name = "label2";
            label2.Size = new Size(49, 13);
            label2.TabIndex = 7;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Fluent Icons", 9.75F);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(56, 197);
            label1.Name = "label1";
            label1.Size = new Size(60, 13);
            label1.TabIndex = 6;
            label1.Text = "Identification";
            // 
            // typeOfUserCb
            // 
            typeOfUserCb.BackColor = Color.White;
            typeOfUserCb.DropDownStyle = ComboBoxStyle.DropDownList;
            typeOfUserCb.FlatStyle = FlatStyle.Flat;
            typeOfUserCb.Font = new Font("Segoe Fluent Icons", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeOfUserCb.ForeColor = Color.DimGray;
            typeOfUserCb.FormattingEnabled = true;
            typeOfUserCb.Items.AddRange(new object[] { "Admin", "Student", "Teacher" });
            typeOfUserCb.Location = new Point(56, 165);
            typeOfUserCb.Name = "typeOfUserCb";
            typeOfUserCb.Size = new Size(300, 29);
            typeOfUserCb.TabIndex = 5;
            // 
            // EnterBtn
            // 
            EnterBtn.BackColor = Color.FromArgb(25, 25, 25);
            EnterBtn.FlatAppearance.BorderSize = 0;
            EnterBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 25);
            EnterBtn.FlatStyle = FlatStyle.Flat;
            EnterBtn.Font = new Font("Segoe Fluent Icons", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EnterBtn.ForeColor = Color.White;
            EnterBtn.Location = new Point(56, 326);
            EnterBtn.Name = "EnterBtn";
            EnterBtn.Size = new Size(300, 28);
            EnterBtn.TabIndex = 3;
            EnterBtn.Text = "Get Started";
            EnterBtn.TextAlign = ContentAlignment.TopCenter;
            EnterBtn.UseVisualStyleBackColor = false;
            EnterBtn.Click += EnterBtn_Click;
            // 
            // UsernameTxt
            // 
            UsernameTxt.BackColor = Color.White;
            UsernameTxt.BorderStyle = BorderStyle.FixedSingle;
            UsernameTxt.Font = new Font("Segoe Fluent Icons", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UsernameTxt.ForeColor = Color.DimGray;
            UsernameTxt.Location = new Point(56, 215);
            UsernameTxt.Name = "UsernameTxt";
            UsernameTxt.PlaceholderText = " Enter you identification";
            UsernameTxt.Size = new Size(300, 28);
            UsernameTxt.TabIndex = 1;
            // 
            // PasswordTxt
            // 
            PasswordTxt.BackColor = Color.White;
            PasswordTxt.BorderStyle = BorderStyle.FixedSingle;
            PasswordTxt.Font = new Font("Segoe Fluent Icons", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordTxt.ForeColor = Color.Black;
            PasswordTxt.Location = new Point(56, 276);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.PlaceholderText = " Enter your password";
            PasswordTxt.Size = new Size(300, 28);
            PasswordTxt.TabIndex = 2;
            PasswordTxt.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(30, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(79, 76);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // ExBtn
            // 
            ExBtn.BackColor = Color.Transparent;
            ExBtn.FlatAppearance.BorderSize = 0;
            ExBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            ExBtn.FlatStyle = FlatStyle.Flat;
            ExBtn.Font = new Font("Segoe Fluent Icons", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExBtn.ForeColor = Color.FromArgb(25, 25, 25);
            ExBtn.Location = new Point(1408, 23);
            ExBtn.Name = "ExBtn";
            ExBtn.Size = new Size(34, 28);
            ExBtn.TabIndex = 14;
            ExBtn.Text = "X";
            ExBtn.TextAlign = ContentAlignment.TopCenter;
            ExBtn.UseVisualStyleBackColor = false;
            ExBtn.Click += ExBtn_Click;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1463, 738);
            Controls.Add(ExBtn);
            Controls.Add(loginPanel);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login your account";
            Load += LoginPage_Load;
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox UsernameTxt;
        private Panel loginPanel;
        private TextBox PasswordTxt;
        private Button EnterBtn;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox typeOfUserCb;
        private PictureBox pictureBox1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button ExBtn;
    }
}