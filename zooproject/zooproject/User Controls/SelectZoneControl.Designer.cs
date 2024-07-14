namespace zooproject.User_Controls
{
    partial class SelectZoneControl
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
			this.lblName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(58, 12);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(66, 20);
			this.lblName.TabIndex = 6;
			this.lblName.Text = "<name>";
			this.lblName.Click += new System.EventHandler(this.lblName_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 20);
			this.label1.TabIndex = 8;
			this.label1.Text = "Name:";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// SelectZoneControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkGray;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblName);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SelectZoneControl";
			this.Size = new System.Drawing.Size(177, 58);
			this.Click += new System.EventHandler(this.SelectZoneControl_Click);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private Label lblName;
        private Label label1;
    }
}
