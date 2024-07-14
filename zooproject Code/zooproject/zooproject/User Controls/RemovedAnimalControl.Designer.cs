namespace zooproject.User_Controls
{
    partial class RemovedAnimalControl
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
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblSPecies = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(2, 56);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 7;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelectClick);
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(2, 31);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(42, 15);
            this.lblAge.TabIndex = 8;
            this.lblAge.Text = "<age>";
            // 
            // lblSPecies
            // 
            this.lblSPecies.AutoSize = true;
            this.lblSPecies.Location = new System.Drawing.Point(2, 16);
            this.lblSPecies.Name = "lblSPecies";
            this.lblSPecies.Size = new System.Drawing.Size(61, 15);
            this.lblSPecies.TabIndex = 9;
            this.lblSPecies.Text = "<species>";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(2, 1);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 15);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "<name>";
            // 
            // RemovedAnimalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblSPecies);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnSelect);
            this.Name = "RemovedAnimalControl";
            this.Size = new System.Drawing.Size(81, 85);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSelect;
        private Label lblAge;
        private Label lblSPecies;
        private Label lblName;
    }
}
