namespace zooproject.User_Controls
{
    partial class CurrentExhibitControl
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
			this.lblEnvironment = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblEnvironment
			// 
			this.lblEnvironment.AutoSize = true;
			this.lblEnvironment.Location = new System.Drawing.Point(103, 35);
			this.lblEnvironment.Name = "lblEnvironment";
			this.lblEnvironment.Size = new System.Drawing.Size(112, 20);
			this.lblEnvironment.TabIndex = 1;
			this.lblEnvironment.Text = "<environment>";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(103, 15);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(66, 20);
			this.lblName.TabIndex = 2;
			this.lblName.Text = "<name>";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 20);
			this.label1.TabIndex = 3;
			this.label1.Text = "Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(2, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Environment:";
			// 
			// CurrentExhibitControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblEnvironment);
			this.Controls.Add(this.lblName);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "CurrentExhibitControl";
			this.Size = new System.Drawing.Size(241, 68);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Label lblEnvironment;
        private Label lblName;
        private Label label1;
        private Label label2;
    }
}
