namespace zooproject.User_Controls
{
    partial class ModifyZoneControl
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
            this.ZoneNameLabel = new System.Windows.Forms.Label();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ZoneNameLabel
            // 
            this.ZoneNameLabel.AutoSize = true;
            this.ZoneNameLabel.Location = new System.Drawing.Point(51, 31);
            this.ZoneNameLabel.Name = "ZoneNameLabel";
            this.ZoneNameLabel.Size = new System.Drawing.Size(38, 15);
            this.ZoneNameLabel.TabIndex = 2;
            this.ZoneNameLabel.Text = "label1";
            // 
            // button_Edit
            // 
            this.button_Edit.Location = new System.Drawing.Point(34, 60);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(75, 23);
            this.button_Edit.TabIndex = 3;
            this.button_Edit.Text = "Edit";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.Location = new System.Drawing.Point(34, 89);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(75, 23);
            this.button_Remove.TabIndex = 4;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // ModifyZoneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.ZoneNameLabel);
            this.Name = "ModifyZoneControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label ZoneNameLabel;
        private Button button_Edit;
        private Button button_Remove;
    }
}
