namespace zooproject.User_Controls
{
    partial class FeedingEmployeeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EmpSelectBtn = new System.Windows.Forms.Button();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblDeparment = new System.Windows.Forms.Label();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EmpSelectBtn
            // 
            this.EmpSelectBtn.Location = new System.Drawing.Point(41, 100);
            this.EmpSelectBtn.Name = "EmpSelectBtn";
            this.EmpSelectBtn.Size = new System.Drawing.Size(75, 23);
            this.EmpSelectBtn.TabIndex = 11;
            this.EmpSelectBtn.Text = "Select";
            this.EmpSelectBtn.UseVisualStyleBackColor = true;
            this.EmpSelectBtn.Click += new System.EventHandler(this.EmpSelectBtn_Click);
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(32, 67);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(87, 15);
            this.lblDateOfBirth.TabIndex = 8;
            this.lblDateOfBirth.Text = "<DateOFBirth>";
            // 
            // lblDeparment
            // 
            this.lblDeparment.AutoSize = true;
            this.lblDeparment.Location = new System.Drawing.Point(32, 52);
            this.lblDeparment.Name = "lblDeparment";
            this.lblDeparment.Size = new System.Drawing.Size(86, 15);
            this.lblDeparment.TabIndex = 9;
            this.lblDeparment.Text = "<Department>";
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Location = new System.Drawing.Point(32, 27);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(53, 15);
            this.lblEmpName.TabIndex = 10;
            this.lblEmpName.Text = "<name>";
            // 
            // FeedingEmployeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.EmpSelectBtn);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.lblDeparment);
            this.Controls.Add(this.lblEmpName);
            this.Name = "FeedingEmployeeControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button EmpSelectBtn;
        private Label lblDateOfBirth;
        private Label lblDeparment;
        private Label lblEmpName;
    }
}
