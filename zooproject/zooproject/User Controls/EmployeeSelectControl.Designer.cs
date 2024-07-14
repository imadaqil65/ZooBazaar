namespace zooproject.User_Controls
{
    partial class EmployeeSelectControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(83, 54);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(87, 15);
            this.lblDateOfBirth.TabIndex = 8;
            this.lblDateOfBirth.Text = "<DateOFBirth>";
            this.lblDateOfBirth.Click += new System.EventHandler(this.lblDateOfBirth_Click);
            // 
            // lblDeparment
            // 
            this.lblDeparment.AutoSize = true;
            this.lblDeparment.Location = new System.Drawing.Point(83, 29);
            this.lblDeparment.Name = "lblDeparment";
            this.lblDeparment.Size = new System.Drawing.Size(86, 15);
            this.lblDeparment.TabIndex = 9;
            this.lblDeparment.Text = "<Department>";
            this.lblDeparment.Click += new System.EventHandler(this.lblDeparment_Click);
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Location = new System.Drawing.Point(83, 5);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(53, 15);
            this.lblEmpName.TabIndex = 10;
            this.lblEmpName.Text = "<name>";
            this.lblEmpName.Click += new System.EventHandler(this.lblEmpName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "DateOFBirth:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Department:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Name:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // EmployeeSelectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.lblDeparment);
            this.Controls.Add(this.lblEmpName);
            this.Name = "EmployeeSelectControl";
            this.Size = new System.Drawing.Size(173, 79);
            this.Click += new System.EventHandler(this.EmployeeSelectControl_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblDateOfBirth;
        private Label lblDeparment;
        private Label lblEmpName;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
