namespace zooproject.User_Controls
{
    partial class ZoneControl
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
            this.ZoneDetailsBtn = new System.Windows.Forms.Button();
            this.ZoneNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ZoneDetailsBtn
            // 
            this.ZoneDetailsBtn.Location = new System.Drawing.Point(3, 35);
            this.ZoneDetailsBtn.Name = "ZoneDetailsBtn";
            this.ZoneDetailsBtn.Size = new System.Drawing.Size(75, 23);
            this.ZoneDetailsBtn.TabIndex = 0;
            this.ZoneDetailsBtn.Text = "Details";
            this.ZoneDetailsBtn.UseVisualStyleBackColor = true;
            this.ZoneDetailsBtn.Click += new System.EventHandler(this.ZoneDetailsBtn_Click);
            // 
            // ZoneNameLabel
            // 
            this.ZoneNameLabel.AutoSize = true;
            this.ZoneNameLabel.Location = new System.Drawing.Point(55, 17);
            this.ZoneNameLabel.Name = "ZoneNameLabel";
            this.ZoneNameLabel.Size = new System.Drawing.Size(55, 15);
            this.ZoneNameLabel.TabIndex = 1;
            this.ZoneNameLabel.Text = "<Name>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "<Name:";
            // 
            // ZoneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ZoneNameLabel);
            this.Controls.Add(this.ZoneDetailsBtn);
            this.Name = "ZoneControl";
            this.Size = new System.Drawing.Size(141, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ZoneDetailsBtn;
        private Label ZoneNameLabel;
        private Label label1;
    }
}
