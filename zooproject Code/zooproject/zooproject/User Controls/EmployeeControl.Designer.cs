namespace zooproject.User_Controls
{
    partial class EmployeeControl
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
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblDeparment = new System.Windows.Forms.Label();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.EmpDetailsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(25, 67);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(87, 15);
            this.lblDateOfBirth.TabIndex = 4;
            this.lblDateOfBirth.Text = "<DateOFBirth>";
            // 
            // lblDeparment
            // 
            this.lblDeparment.AutoSize = true;
            this.lblDeparment.Location = new System.Drawing.Point(25, 52);
            this.lblDeparment.Name = "lblDeparment";
            this.lblDeparment.Size = new System.Drawing.Size(86, 15);
            this.lblDeparment.TabIndex = 5;
            this.lblDeparment.Text = "<Department>";
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Location = new System.Drawing.Point(25, 27);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(53, 15);
            this.lblEmpName.TabIndex = 6;
            this.lblEmpName.Text = "<name>";
            // 
            // EmpDetailsBtn
            // 
            this.EmpDetailsBtn.Location = new System.Drawing.Point(34, 100);
            this.EmpDetailsBtn.Name = "EmpDetailsBtn";
            this.EmpDetailsBtn.Size = new System.Drawing.Size(75, 23);
            this.EmpDetailsBtn.TabIndex = 7;
            this.EmpDetailsBtn.Text = "Details";
            this.EmpDetailsBtn.UseVisualStyleBackColor = true;
            this.EmpDetailsBtn.Click += new System.EventHandler(this.EmpDetailsBtn_Click);
            // 
            // EmployeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.EmpDetailsBtn);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.lblDeparment);
            this.Controls.Add(this.lblEmpName);
            this.Name = "EmployeeControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblDateOfBirth;
        private Label lblDeparment;
        private Label lblEmpName;
        private Button EmpDetailsBtn;
    }
}
