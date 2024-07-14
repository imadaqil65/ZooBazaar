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
            lblExhibit = new Label();
            btnDetails = new Button();
            lblTime = new Label();
            lblDate = new Label();
            SuspendLayout();
            // 
            // lblExhibit
            // 
            lblExhibit.AutoSize = true;
            lblExhibit.Location = new Point(4, 9);
            lblExhibit.Name = "lblExhibit";
            lblExhibit.Size = new Size(59, 15);
            lblExhibit.TabIndex = 0;
            lblExhibit.Text = "<exhibit>";
            // 
            // btnDetails
            // 
            btnDetails.Location = new Point(0, 57);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(99, 24);
            btnDetails.TabIndex = 1;
            btnDetails.Text = "Details";
            btnDetails.UseVisualStyleBackColor = true;
            btnDetails.Click += btnDetails_Click;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(4, 39);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(47, 15);
            lblTime.TabIndex = 2;
            lblTime.Text = "<time>";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(4, 24);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(46, 15);
            lblDate.TabIndex = 2;
            lblDate.Text = "<date>";
            // 
            // FeedingTaskControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            Controls.Add(lblDate);
            Controls.Add(lblTime);
            Controls.Add(btnDetails);
            Controls.Add(lblExhibit);
            Name = "FeedingTaskControl";
            Size = new Size(107, 85);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblExhibit;
        private Button btnDetails;
        private Label lblTime;
        private Label lblDate;
    }
}
