namespace zooproject
{
    partial class RemovedEmployee
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
            this.flp_TerminatedEmployee = new System.Windows.Forms.FlowLayoutPanel();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.btn_Filter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flp_TerminatedEmployee
            // 
            this.flp_TerminatedEmployee.BackColor = System.Drawing.Color.PaleGreen;
            this.flp_TerminatedEmployee.Location = new System.Drawing.Point(12, 76);
            this.flp_TerminatedEmployee.Name = "flp_TerminatedEmployee";
            this.flp_TerminatedEmployee.Size = new System.Drawing.Size(1015, 624);
            this.flp_TerminatedEmployee.TabIndex = 0;
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(12, 36);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(112, 34);
            this.button_Refresh.TabIndex = 1;
            this.button_Refresh.Text = "Refresh list";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // btn_Filter
            // 
            this.btn_Filter.Location = new System.Drawing.Point(915, 36);
            this.btn_Filter.Name = "btn_Filter";
            this.btn_Filter.Size = new System.Drawing.Size(112, 34);
            this.btn_Filter.TabIndex = 2;
            this.btn_Filter.Text = "Filter";
            this.btn_Filter.UseVisualStyleBackColor = true;
            this.btn_Filter.Click += new System.EventHandler(this.btn_Filter_Click);
            // 
            // RemovedEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(1039, 716);
            this.Controls.Add(this.btn_Filter);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.flp_TerminatedEmployee);
            this.Name = "RemovedEmployee";
            this.Text = "RemovedEmployee";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RemovedEmployee_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flp_TerminatedEmployee;
        private Button button_Refresh;
        private Button btn_Filter;
    }
}