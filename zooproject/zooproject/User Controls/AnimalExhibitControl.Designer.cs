namespace zooproject.User_Controls
{
    partial class AnimalExhibitControl
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
			this.label_PreyPredator = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label_Zone = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblEnvironment
			// 
			this.lblEnvironment.AutoSize = true;
			this.lblEnvironment.Location = new System.Drawing.Point(99, 49);
			this.lblEnvironment.Name = "lblEnvironment";
			this.lblEnvironment.Size = new System.Drawing.Size(112, 20);
			this.lblEnvironment.TabIndex = 2;
			this.lblEnvironment.Text = "<environment>";
			this.lblEnvironment.Click += new System.EventHandler(this.lblEnvironment_Click);
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(99, 9);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(66, 20);
			this.lblName.TabIndex = 3;
			this.lblName.Text = "<name>";
			this.lblName.Click += new System.EventHandler(this.lblName_Click);
			// 
			// label_PreyPredator
			// 
			this.label_PreyPredator.AutoSize = true;
			this.label_PreyPredator.Location = new System.Drawing.Point(99, 69);
			this.label_PreyPredator.Name = "label_PreyPredator";
			this.label_PreyPredator.Size = new System.Drawing.Size(114, 20);
			this.label_PreyPredator.TabIndex = 5;
			this.label_PreyPredator.Text = "<PreyPredator>";
			this.label_PreyPredator.Click += new System.EventHandler(this.label_PreyPredator_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "Name:";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 20);
			this.label3.TabIndex = 7;
			this.label3.Text = "Environment:";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 69);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(73, 20);
			this.label4.TabIndex = 8;
			this.label4.Text = "Predator?";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 20);
			this.label1.TabIndex = 9;
			this.label1.Text = "Zone:";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label_Zone
			// 
			this.label_Zone.AutoSize = true;
			this.label_Zone.Location = new System.Drawing.Point(99, 29);
			this.label_Zone.Name = "label_Zone";
			this.label_Zone.Size = new System.Drawing.Size(61, 20);
			this.label_Zone.TabIndex = 10;
			this.label_Zone.Text = "<zone>";
			this.label_Zone.Click += new System.EventHandler(this.label_Zone_Click);
			// 
			// AnimalExhibitControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkGray;
			this.Controls.Add(this.label_Zone);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label_PreyPredator);
			this.Controls.Add(this.lblEnvironment);
			this.Controls.Add(this.lblName);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "AnimalExhibitControl";
			this.Size = new System.Drawing.Size(266, 101);
			this.Click += new System.EventHandler(this.AnimalExhibitControl_Click);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Button btnSelect;
        private Label lblEnvironment;
        private Label lblName;
        private Label label_PreyPredator;
        private Label label2;
        private Label label3;
        private Label label4;
		private Label label1;
		private Label label_Zone;
	}
}
