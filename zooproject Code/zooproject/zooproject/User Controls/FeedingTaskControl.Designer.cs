namespace zooproject.User_Controls
{
    partial class FeedingTaskControl
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
            this.lblExhibit = new System.Windows.Forms.Label();
            this.btnDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblExhibit
            // 
            this.lblExhibit.AutoSize = true;
            this.lblExhibit.Location = new System.Drawing.Point(4, 9);
            this.lblExhibit.Name = "lblExhibit";
            this.lblExhibit.Size = new System.Drawing.Size(59, 15);
            this.lblExhibit.TabIndex = 0;
            this.lblExhibit.Text = "<exhibit>";
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(4, 27);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 1;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            // 
            // FeedingTaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.lblExhibit);
            this.Name = "FeedingTaskControl";
            this.Size = new System.Drawing.Size(84, 54);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblExhibit;
        private Button btnDetails;
    }
}
