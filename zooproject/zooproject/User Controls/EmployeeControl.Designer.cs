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
            this.lblDateOfBirth.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDateOfBirth.Location = new System.Drawing.Point(17, 108);
            this.lblDateOfBirth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(132, 25);
            this.lblDateOfBirth.TabIndex = 4;
            this.lblDateOfBirth.Text = "<DateOFBirth>";
            // 
            // lblDeparment
            // 
            this.lblDeparment.AutoSize = true;
            this.lblDeparment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDeparment.Location = new System.Drawing.Point(17, 64);
            this.lblDeparment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeparment.Name = "lblDeparment";
            this.lblDeparment.Size = new System.Drawing.Size(131, 25);
            this.lblDeparment.TabIndex = 5;
            this.lblDeparment.Text = "<Department>";
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblEmpName.Location = new System.Drawing.Point(17, 26);
            this.lblEmpName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(80, 25);
            this.lblEmpName.TabIndex = 6;
            this.lblEmpName.Text = "<name>";
            // 
            // EmpDetailsBtn
            // 
            this.EmpDetailsBtn.Location = new System.Drawing.Point(50, 161);
            this.EmpDetailsBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EmpDetailsBtn.Name = "EmpDetailsBtn";
            this.EmpDetailsBtn.Size = new System.Drawing.Size(107, 38);
            this.EmpDetailsBtn.TabIndex = 7;
            this.EmpDetailsBtn.Text = "Modify";
            this.EmpDetailsBtn.UseVisualStyleBackColor = true;
            this.EmpDetailsBtn.Click += new System.EventHandler(this.EmpDetailsBtn_Click);
            // 
            // EmployeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.Controls.Add(this.EmpDetailsBtn);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.lblDeparment);
            this.Controls.Add(this.lblEmpName);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EmployeeControl";
            this.Size = new System.Drawing.Size(209, 218);
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
