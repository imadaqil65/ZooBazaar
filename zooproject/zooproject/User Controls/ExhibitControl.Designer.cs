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
			this.label4 = new System.Windows.Forms.Label();
			this.label_PreyPredator = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label_zone = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(99, 3);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(66, 20);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "<name>";
			// 
			// lblEnvironment
			// 
			this.lblEnvironment.AutoSize = true;
			this.lblEnvironment.Location = new System.Drawing.Point(99, 43);
			this.lblEnvironment.Name = "lblEnvironment";
			this.lblEnvironment.Size = new System.Drawing.Size(112, 20);
			this.lblEnvironment.TabIndex = 0;
			this.lblEnvironment.Text = "<environment>";
			// 
			// btnDetails
			// 
			this.btnDetails.Location = new System.Drawing.Point(3, 118);
			this.btnDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnDetails.Name = "btnDetails";
			this.btnDetails.Size = new System.Drawing.Size(86, 31);
			this.btnDetails.TabIndex = 1;
			this.btnDetails.Text = "Edit";
			this.btnDetails.UseVisualStyleBackColor = true;
			this.btnDetails.Click += new System.EventHandler(this.DetailsClick);
			// 
			// button_RemoveExhibit
			// 
			this.button_RemoveExhibit.Location = new System.Drawing.Point(3, 157);
			this.button_RemoveExhibit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_RemoveExhibit.Name = "button_RemoveExhibit";
			this.button_RemoveExhibit.Size = new System.Drawing.Size(86, 31);
			this.button_RemoveExhibit.TabIndex = 2;
			this.button_RemoveExhibit.Text = "Remove";
			this.button_RemoveExhibit.UseVisualStyleBackColor = true;
			this.button_RemoveExhibit.Click += new System.EventHandler(this.button_RemoveExhibit_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 63);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(73, 20);
			this.label4.TabIndex = 10;
			this.label4.Text = "Predator?";
			// 
			// label_PreyPredator
			// 
			this.label_PreyPredator.AutoSize = true;
			this.label_PreyPredator.Location = new System.Drawing.Point(99, 63);
			this.label_PreyPredator.Name = "label_PreyPredator";
			this.label_PreyPredator.Size = new System.Drawing.Size(114, 20);
			this.label_PreyPredator.TabIndex = 9;
			this.label_PreyPredator.Text = "<PreyPredator>";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 20);
			this.label3.TabIndex = 12;
			this.label3.Text = "Environment:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 20);
			this.label2.TabIndex = 11;
			this.label2.Text = "Name:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 20);
			this.label1.TabIndex = 14;
			this.label1.Text = "Zone:";
			// 
			// label_zone
			// 
			this.label_zone.AutoSize = true;
			this.label_zone.Location = new System.Drawing.Point(99, 23);
			this.label_zone.Name = "label_zone";
			this.label_zone.Size = new System.Drawing.Size(61, 20);
			this.label_zone.TabIndex = 13;
			this.label_zone.Text = "<zone>";
			// 
			// ExhibitControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label_zone);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label_PreyPredator);
			this.Controls.Add(this.button_RemoveExhibit);
			this.Controls.Add(this.btnDetails);
			this.Controls.Add(this.lblEnvironment);
			this.Controls.Add(this.lblName);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ExhibitControl";
			this.Size = new System.Drawing.Size(249, 194);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Label lblName;
        private Label lblEnvironment;
        private Button btnDetails;
        private Button button_RemoveExhibit;
        private Label label4;
        private Label label_PreyPredator;
        private Label label3;
        private Label label2;
		private Label label1;
		private Label label_zone;
	}
}
