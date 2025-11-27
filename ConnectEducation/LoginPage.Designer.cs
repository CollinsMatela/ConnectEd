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
            panel2 = new Panel();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            typeOfUserCb = new ComboBox();
            EnterBtn = new Button();
            UsernameTxt = new TextBox();
            PasswordTxt = new TextBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(typeOfUserCb);
            panel2.Controls.Add(EnterBtn);
            panel2.Controls.Add(UsernameTxt);
            panel2.Controls.Add(PasswordTxt);
            panel2.Location = new Point(483, 92);
            panel2.Name = "panel2";
            panel2.Size = new Size(490, 550);
            panel2.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe Fluent Icons", 11.25F);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(190, 254);
            label4.Name = "label4";
            label4.Size = new Size(131, 15);
            label4.TabIndex = 11;
            label4.Text = "LOGIN YOUR ACCOUNT";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(159, 56);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(187, 177);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Fluent Icons", 11.25F);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(137, 287);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 8;
            label3.Text = "Type of user";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Fluent Icons", 11.25F);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(137, 387);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 7;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Fluent Icons", 11.25F);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(137, 336);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 6;
            label1.Text = "Identification";
            // 
            // typeOfUserCb
            // 
            typeOfUserCb.BackColor = Color.WhiteSmoke;
            typeOfUserCb.DropDownStyle = ComboBoxStyle.DropDownList;
            typeOfUserCb.FlatStyle = FlatStyle.Flat;
            typeOfUserCb.Font = new Font("Segoe Fluent Icons", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeOfUserCb.ForeColor = Color.DimGray;
            typeOfUserCb.FormattingEnabled = true;
            typeOfUserCb.Items.AddRange(new object[] { "Admin", "Student", "Teacher" });
            typeOfUserCb.Location = new Point(137, 305);
            typeOfUserCb.Name = "typeOfUserCb";
            typeOfUserCb.Size = new Size(232, 24);
            typeOfUserCb.TabIndex = 5;
            // 
            // EnterBtn
            // 
            EnterBtn.BackColor = Color.DodgerBlue;
            EnterBtn.FlatAppearance.BorderSize = 0;
            EnterBtn.FlatAppearance.MouseOverBackColor = Color.SteelBlue;
            EnterBtn.FlatStyle = FlatStyle.Flat;
            EnterBtn.Font = new Font("Segoe Fluent Icons", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EnterBtn.ForeColor = Color.White;
            EnterBtn.Location = new Point(137, 445);
            EnterBtn.Name = "EnterBtn";
            EnterBtn.Size = new Size(232, 49);
            EnterBtn.TabIndex = 3;
            EnterBtn.Text = "ENTER";
            EnterBtn.UseVisualStyleBackColor = false;
            EnterBtn.Click += EnterBtn_Click;
            // 
            // UsernameTxt
            // 
            UsernameTxt.BackColor = Color.White;
            UsernameTxt.BorderStyle = BorderStyle.FixedSingle;
            UsernameTxt.Font = new Font("Segoe Fluent Icons", 12F);
            UsernameTxt.ForeColor = Color.DimGray;
            UsernameTxt.Location = new Point(137, 354);
            UsernameTxt.Name = "UsernameTxt";
            UsernameTxt.Size = new Size(232, 23);
            UsernameTxt.TabIndex = 1;
            // 
            // PasswordTxt
            // 
            PasswordTxt.BackColor = Color.White;
            PasswordTxt.BorderStyle = BorderStyle.FixedSingle;
            PasswordTxt.Font = new Font("Segoe Fluent Icons", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordTxt.ForeColor = Color.Black;
            PasswordTxt.Location = new Point(137, 405);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.Size = new Size(232, 23);
            PasswordTxt.TabIndex = 2;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1463, 738);
            Controls.Add(panel2);
            Name = "LoginPage";
            Text = "Login your account";
            Load += LoginPage_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox UsernameTxt;
        private Panel panel2;
        private TextBox PasswordTxt;
        private Button EnterBtn;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox typeOfUserCb;
        private PictureBox pictureBox1;
        private Label label4;
    }
}