namespace zooproject.User_Controls
{
    partial class AnimalControl
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
            this.btnDetails = new System.Windows.Forms.Button();
            this.lblSPecies = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(14, 71);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(109, 23);
            this.btnDetails.TabIndex = 4;
            this.btnDetails.Text = "Modify";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.DetailsClick);
            // 
            // lblSPecies
            // 
            this.lblSPecies.AutoSize = true;
            this.lblSPecies.Location = new System.Drawing.Point(62, 29);
            this.lblSPecies.Name = "lblSPecies";
            this.lblSPecies.Size = new System.Drawing.Size(61, 15);
            this.lblSPecies.TabIndex = 2;
            this.lblSPecies.Text = "<species>";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(62, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 15);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "<name>";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(62, 44);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(42, 15);
            this.lblAge.TabIndex = 2;
            this.lblAge.Text = "<age>";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Move";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.Location = new System.Drawing.Point(14, 129);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(109, 23);
            this.button_Remove.TabIndex = 6;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Species:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Age:";
            // 
            // AnimalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblSPecies);
            this.Controls.Add(this.lblName);
            this.Name = "AnimalControl";
            this.Size = new System.Drawing.Size(139, 162);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnDetails;
        private Label lblSPecies;
        private Label lblName;
        private Label lblAge;
        private Button button1;
        private Button button_Remove;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
