namespace zooproject
{
    partial class Login
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
            this.label_Login_Welcome = new System.Windows.Forms.Label();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.PasswordTxtBx = new System.Windows.Forms.TextBox();
            this.UsernameTxtBx = new System.Windows.Forms.TextBox();
            this.label_Login_Password = new System.Windows.Forms.Label();
            this.label_Login_Username = new System.Windows.Forms.Label();
            this.button_Login_SecretButton = new System.Windows.Forms.Button();
            this.pictureBox_Login_CatNotCat = new System.Windows.Forms.PictureBox();
            this.TestLoginAnimals = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Login_CatNotCat)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Login_Welcome
            // 
            this.label_Login_Welcome.AutoSize = true;
            this.label_Login_Welcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_Login_Welcome.Location = new System.Drawing.Point(321, 89);
            this.label_Login_Welcome.Name = "label_Login_Welcome";
            this.label_Login_Welcome.Size = new System.Drawing.Size(127, 37);
            this.label_Login_Welcome.TabIndex = 11;
            this.label_Login_Welcome.Text = "Welcome";
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(274, 307);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(216, 23);
            this.LoginBtn.TabIndex = 10;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // PasswordTxtBx
            // 
            this.PasswordTxtBx.Location = new System.Drawing.Point(344, 226);
            this.PasswordTxtBx.Name = "PasswordTxtBx";
            this.PasswordTxtBx.PasswordChar = '*';
            this.PasswordTxtBx.Size = new System.Drawing.Size(145, 23);
            this.PasswordTxtBx.TabIndex = 9;
            this.PasswordTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTxtBx_KeyDown);
            // 
            // UsernameTxtBx
            // 
            this.UsernameTxtBx.Location = new System.Drawing.Point(344, 163);
            this.UsernameTxtBx.Name = "UsernameTxtBx";
            this.UsernameTxtBx.Size = new System.Drawing.Size(145, 23);
            this.UsernameTxtBx.TabIndex = 8;
            // 
            // label_Login_Password
            // 
            this.label_Login_Password.AutoSize = true;
            this.label_Login_Password.Location = new System.Drawing.Point(274, 229);
            this.label_Login_Password.Name = "label_Login_Password";
            this.label_Login_Password.Size = new System.Drawing.Size(57, 15);
            this.label_Login_Password.TabIndex = 7;
            this.label_Login_Password.Text = "Password";
            // 
            // label_Login_Username
            // 
            this.label_Login_Username.AutoSize = true;
            this.label_Login_Username.Location = new System.Drawing.Point(274, 166);
            this.label_Login_Username.Name = "label_Login_Username";
            this.label_Login_Username.Size = new System.Drawing.Size(60, 15);
            this.label_Login_Username.TabIndex = 6;
            this.label_Login_Username.Text = "Username";
            // 
            // button_Login_SecretButton
            // 
            this.button_Login_SecretButton.Location = new System.Drawing.Point(10, 419);
            this.button_Login_SecretButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Login_SecretButton.Name = "button_Login_SecretButton";
            this.button_Login_SecretButton.Size = new System.Drawing.Size(136, 22);
            this.button_Login_SecretButton.TabIndex = 13;
            this.button_Login_SecretButton.Text = "Super Secret Button";
            this.button_Login_SecretButton.UseVisualStyleBackColor = true;
            this.button_Login_SecretButton.Click += new System.EventHandler(this.button_Login_SecretButton_Click);
            // 
            // pictureBox_Login_CatNotCat
            // 
            this.pictureBox_Login_CatNotCat.Location = new System.Drawing.Point(10, 9);
            this.pictureBox_Login_CatNotCat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_Login_CatNotCat.Name = "pictureBox_Login_CatNotCat";
            this.pictureBox_Login_CatNotCat.Size = new System.Drawing.Size(778, 406);
            this.pictureBox_Login_CatNotCat.TabIndex = 14;
            this.pictureBox_Login_CatNotCat.TabStop = false;
            // 
            // TestLoginAnimals
            // 
            this.TestLoginAnimals.Location = new System.Drawing.Point(302, 419);
            this.TestLoginAnimals.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TestLoginAnimals.Name = "TestLoginAnimals";
            this.TestLoginAnimals.Size = new System.Drawing.Size(164, 20);
            this.TestLoginAnimals.TabIndex = 15;
            this.TestLoginAnimals.Text = "Bypass (for debug)";
            this.TestLoginAnimals.UseVisualStyleBackColor = true;
            this.TestLoginAnimals.Click += new System.EventHandler(this.TestLoginAnimals_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 450);
            this.Controls.Add(this.TestLoginAnimals);
            this.Controls.Add(this.button_Login_SecretButton);
            this.Controls.Add(this.label_Login_Welcome);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PasswordTxtBx);
            this.Controls.Add(this.UsernameTxtBx);
            this.Controls.Add(this.label_Login_Password);
            this.Controls.Add(this.label_Login_Username);
            this.Controls.Add(this.pictureBox_Login_CatNotCat);
            this.Name = "Login";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Login_CatNotCat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		private Label label_Login_Welcome;
		private Button LoginBtn;
		private TextBox PasswordTxtBx;
		private TextBox UsernameTxtBx;
		private Label label_Login_Password;
		private Label label_Login_Username;
        private Button button_Login_SecretButton;
        private PictureBox pictureBox_Login_CatNotCat;
        private Button TestLoginAnimals;
    }
}