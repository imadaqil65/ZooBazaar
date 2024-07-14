namespace zooproject.User_Controls
{
    partial class AnimalDisplayControl
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
			this.lblAge = new System.Windows.Forms.Label();
			this.lblSPecies = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblAge
			// 
			this.lblAge.AutoSize = true;
			this.lblAge.Location = new System.Drawing.Point(71, 40);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(54, 20);
			this.lblAge.TabIndex = 4;
			this.lblAge.Text = "<age>";
			// 
			// lblSPecies
			// 
			this.lblSPecies.AutoSize = true;
			this.lblSPecies.Location = new System.Drawing.Point(71, 20);
			this.lblSPecies.Name = "lblSPecies";
			this.lblSPecies.Size = new System.Drawing.Size(77, 20);
			this.lblSPecies.TabIndex = 5;
			this.lblSPecies.Text = "<species>";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(71, 0);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(66, 20);
			this.lblName.TabIndex = 6;
			this.lblName.Text = "<name>";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 20);
			this.label1.TabIndex = 7;
			this.label1.Text = "Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 20);
			this.label2.TabIndex = 8;
			this.label2.Text = "Species:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 20);
			this.label3.TabIndex = 9;
			this.label3.Text = "Age:";
			// 
			// AnimalDisplayControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblAge);
			this.Controls.Add(this.lblSPecies);
			this.Controls.Add(this.lblName);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "AnimalDisplayControl";
			this.Size = new System.Drawing.Size(219, 67);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Label lblAge;
        private Label lblSPecies;
        private Label lblName;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
