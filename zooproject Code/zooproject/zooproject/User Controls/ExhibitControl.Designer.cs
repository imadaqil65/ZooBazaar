namespace zooproject.User_Controls
{
    partial class ExhibitControl
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
            this.lblEnvironment = new System.Windows.Forms.Label();
            this.btnDetails = new System.Windows.Forms.Button();
            this.button_RemoveExhibit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 17);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "<name>";
            // 
            // lblEnvironment
            // 
            this.lblEnvironment.AutoSize = true;
            this.lblEnvironment.Location = new System.Drawing.Point(12, 42);
            this.lblEnvironment.Name = "lblEnvironment";
            this.lblEnvironment.Size = new System.Drawing.Size(91, 15);
            this.lblEnvironment.TabIndex = 0;
            this.lblEnvironment.Text = "<environment>";
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(12, 79);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 1;
            this.btnDetails.Text = "Edit";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.DetailsClick);
            // 
            // button_RemoveExhibit
            // 
            this.button_RemoveExhibit.Location = new System.Drawing.Point(12, 108);
            this.button_RemoveExhibit.Name = "button_RemoveExhibit";
            this.button_RemoveExhibit.Size = new System.Drawing.Size(75, 23);
            this.button_RemoveExhibit.TabIndex = 2;
            this.button_RemoveExhibit.Text = "Remove";
            this.button_RemoveExhibit.UseVisualStyleBackColor = true;
            this.button_RemoveExhibit.Click += new System.EventHandler(this.button_RemoveExhibit_Click);
            // 
            // ExhibitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.button_RemoveExhibit);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.lblEnvironment);
            this.Controls.Add(this.lblName);
            this.Name = "ExhibitControl";
            this.Size = new System.Drawing.Size(129, 137);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblName;
        private Label lblEnvironment;
        private Button btnDetails;
        private Button button_RemoveExhibit;
    }
}
