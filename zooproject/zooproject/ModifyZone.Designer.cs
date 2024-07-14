namespace zooproject
{
    partial class ModifyZone
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.EditZoneBtn = new System.Windows.Forms.Button();
			this.EditZoneNameTxtBx = new System.Windows.Forms.TextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.groupBox10.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox10
			// 
			this.groupBox10.BackColor = System.Drawing.Color.PaleGreen;
			this.groupBox10.Controls.Add(this.EditZoneBtn);
			this.groupBox10.Controls.Add(this.EditZoneNameTxtBx);
			this.groupBox10.Controls.Add(this.label37);
			this.groupBox10.Location = new System.Drawing.Point(14, 15);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(569, 337);
			this.groupBox10.TabIndex = 5;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Edit Zone";
			// 
			// EditZoneBtn
			// 
			this.EditZoneBtn.Location = new System.Drawing.Point(63, 61);
			this.EditZoneBtn.Name = "EditZoneBtn";
			this.EditZoneBtn.Size = new System.Drawing.Size(160, 29);
			this.EditZoneBtn.TabIndex = 17;
			this.EditZoneBtn.Text = "Edit Zone";
			this.EditZoneBtn.UseVisualStyleBackColor = true;
			this.EditZoneBtn.Click += new System.EventHandler(this.EditZoneBtn_Click);
			// 
			// EditZoneNameTxtBx
			// 
			this.EditZoneNameTxtBx.Location = new System.Drawing.Point(63, 25);
			this.EditZoneNameTxtBx.Name = "EditZoneNameTxtBx";
			this.EditZoneNameTxtBx.Size = new System.Drawing.Size(159, 27);
			this.EditZoneNameTxtBx.TabIndex = 16;
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.Location = new System.Drawing.Point(7, 24);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(49, 20);
			this.label37.TabIndex = 15;
			this.label37.Text = "Name";
			// 
			// ModifyZone
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LimeGreen;
			this.ClientSize = new System.Drawing.Size(606, 365);
			this.Controls.Add(this.groupBox10);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ModifyZone";
			this.Text = "ModifyZone";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModifyZone_FormClosed_1);
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox10;
        private Button EditZoneBtn;
        private TextBox EditZoneNameTxtBx;
        private Label label37;
    }
}