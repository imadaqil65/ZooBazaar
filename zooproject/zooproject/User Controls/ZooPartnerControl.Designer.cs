namespace zooproject.User_Controls
{
    partial class ZooPartnerControl
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
			this.label1 = new System.Windows.Forms.Label();
			this.label_SetName = new System.Windows.Forms.Label();
			this.button_Select = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name:";
			// 
			// label_SetName
			// 
			this.label_SetName.AutoSize = true;
			this.label_SetName.Location = new System.Drawing.Point(61, 9);
			this.label_SetName.Name = "label_SetName";
			this.label_SetName.Size = new System.Drawing.Size(66, 20);
			this.label_SetName.TabIndex = 1;
			this.label_SetName.Text = "<name>";
			// 
			// button_Select
			// 
			this.button_Select.Location = new System.Drawing.Point(3, 33);
			this.button_Select.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_Select.Name = "button_Select";
			this.button_Select.Size = new System.Drawing.Size(104, 31);
			this.button_Select.TabIndex = 2;
			this.button_Select.Text = "Remove";
			this.button_Select.UseVisualStyleBackColor = true;
			this.button_Select.Click += new System.EventHandler(this.button_Select_Click);
			// 
			// ZooPartnerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.Controls.Add(this.button_Select);
			this.Controls.Add(this.label_SetName);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ZooPartnerControl";
			this.Size = new System.Drawing.Size(182, 80);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label_SetName;
        private Button button_Select;
    }
}
