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
            this.groupBox10.Controls.Add(this.EditZoneBtn);
            this.groupBox10.Controls.Add(this.EditZoneNameTxtBx);
            this.groupBox10.Controls.Add(this.label37);
            this.groupBox10.Location = new System.Drawing.Point(12, 11);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Size = new System.Drawing.Size(498, 253);
            this.groupBox10.TabIndex = 5;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Edit Zone";
            // 
            // EditZoneBtn
            // 
            this.EditZoneBtn.Location = new System.Drawing.Point(55, 46);
            this.EditZoneBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditZoneBtn.Name = "EditZoneBtn";
            this.EditZoneBtn.Size = new System.Drawing.Size(140, 22);
            this.EditZoneBtn.TabIndex = 17;
            this.EditZoneBtn.Text = "Edit Zone";
            this.EditZoneBtn.UseVisualStyleBackColor = true;
            this.EditZoneBtn.Click += new System.EventHandler(this.EditZoneBtn_Click);
            // 
            // EditZoneNameTxtBx
            // 
            this.EditZoneNameTxtBx.Location = new System.Drawing.Point(55, 19);
            this.EditZoneNameTxtBx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditZoneNameTxtBx.Name = "EditZoneNameTxtBx";
            this.EditZoneNameTxtBx.Size = new System.Drawing.Size(140, 23);
            this.EditZoneNameTxtBx.TabIndex = 16;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(6, 18);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(39, 15);
            this.label37.TabIndex = 15;
            this.label37.Text = "Name";
            // 
            // ModifyZone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 274);
            this.Controls.Add(this.groupBox10);
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