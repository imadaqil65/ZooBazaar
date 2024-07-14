namespace zooproject
{
    partial class EditExhibit
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
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExhibitEdit = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.chboxPredatorEditExhibit = new System.Windows.Forms.CheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.cmboxEditExhibitType = new System.Windows.Forms.ComboBox();
            this.chboxPreyEditExhibit = new System.Windows.Forms.CheckBox();
            this.txtboxEditExhibitName = new System.Windows.Forms.TextBox();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.button_GetZones = new System.Windows.Forms.Button();
            this.flowLayoutPanel_SelectZone = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox14.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox14
            // 
            this.groupBox14.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox14.Controls.Add(this.panel1);
            this.groupBox14.Controls.Add(this.groupBox24);
            this.groupBox14.Location = new System.Drawing.Point(18, 19);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox14.Size = new System.Drawing.Size(1391, 961);
            this.groupBox14.TabIndex = 4;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Edit Exhibit";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LimeGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnExhibitEdit);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.chboxPredatorEditExhibit);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.cmboxEditExhibitType);
            this.panel1.Controls.Add(this.chboxPreyEditExhibit);
            this.panel1.Controls.Add(this.txtboxEditExhibitName);
            this.panel1.Location = new System.Drawing.Point(1051, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 897);
            this.panel1.TabIndex = 6;
            // 
            // btnExhibitEdit
            // 
            this.btnExhibitEdit.Location = new System.Drawing.Point(68, 208);
            this.btnExhibitEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExhibitEdit.Name = "btnExhibitEdit";
            this.btnExhibitEdit.Size = new System.Drawing.Size(200, 70);
            this.btnExhibitEdit.TabIndex = 19;
            this.btnExhibitEdit.Text = "Edit Exhibit";
            this.btnExhibitEdit.UseVisualStyleBackColor = true;
            this.btnExhibitEdit.Click += new System.EventHandler(this.btnExhibitEdit_Click_1);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(4, 15);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(59, 25);
            this.label32.TabIndex = 13;
            this.label32.Text = "Name";
            // 
            // chboxPredatorEditExhibit
            // 
            this.chboxPredatorEditExhibit.AutoSize = true;
            this.chboxPredatorEditExhibit.Location = new System.Drawing.Point(68, 60);
            this.chboxPredatorEditExhibit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chboxPredatorEditExhibit.Name = "chboxPredatorEditExhibit";
            this.chboxPredatorEditExhibit.Size = new System.Drawing.Size(115, 29);
            this.chboxPredatorEditExhibit.TabIndex = 15;
            this.chboxPredatorEditExhibit.Text = "Predatory";
            this.chboxPredatorEditExhibit.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(4, 124);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(64, 50);
            this.label31.TabIndex = 18;
            this.label31.Text = "Exhibit\r\nType";
            // 
            // cmboxEditExhibitType
            // 
            this.cmboxEditExhibitType.FormattingEnabled = true;
            this.cmboxEditExhibitType.Location = new System.Drawing.Point(68, 125);
            this.cmboxEditExhibitType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmboxEditExhibitType.Name = "cmboxEditExhibitType";
            this.cmboxEditExhibitType.Size = new System.Drawing.Size(198, 33);
            this.cmboxEditExhibitType.TabIndex = 17;
            // 
            // chboxPreyEditExhibit
            // 
            this.chboxPreyEditExhibit.AutoSize = true;
            this.chboxPreyEditExhibit.Location = new System.Drawing.Point(198, 60);
            this.chboxPreyEditExhibit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chboxPreyEditExhibit.Name = "chboxPreyEditExhibit";
            this.chboxPreyEditExhibit.Size = new System.Drawing.Size(72, 29);
            this.chboxPreyEditExhibit.TabIndex = 16;
            this.chboxPreyEditExhibit.Text = "Prey";
            this.chboxPreyEditExhibit.UseVisualStyleBackColor = true;
            // 
            // txtboxEditExhibitName
            // 
            this.txtboxEditExhibitName.Location = new System.Drawing.Point(68, 18);
            this.txtboxEditExhibitName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtboxEditExhibitName.Name = "txtboxEditExhibitName";
            this.txtboxEditExhibitName.Size = new System.Drawing.Size(198, 31);
            this.txtboxEditExhibitName.TabIndex = 14;
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.button_GetZones);
            this.groupBox24.Controls.Add(this.flowLayoutPanel_SelectZone);
            this.groupBox24.ForeColor = System.Drawing.Color.Black;
            this.groupBox24.Location = new System.Drawing.Point(9, 34);
            this.groupBox24.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox24.Size = new System.Drawing.Size(1039, 910);
            this.groupBox24.TabIndex = 5;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Select Zone";
            // 
            // button_GetZones
            // 
            this.button_GetZones.Location = new System.Drawing.Point(9, 30);
            this.button_GetZones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_GetZones.Name = "button_GetZones";
            this.button_GetZones.Size = new System.Drawing.Size(140, 39);
            this.button_GetZones.TabIndex = 15;
            this.button_GetZones.Text = "Get Zones";
            this.button_GetZones.UseVisualStyleBackColor = true;
            this.button_GetZones.Click += new System.EventHandler(this.button_GetZones_Click);
            // 
            // flowLayoutPanel_SelectZone
            // 
            this.flowLayoutPanel_SelectZone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel_SelectZone.Location = new System.Drawing.Point(9, 94);
            this.flowLayoutPanel_SelectZone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel_SelectZone.Name = "flowLayoutPanel_SelectZone";
            this.flowLayoutPanel_SelectZone.Size = new System.Drawing.Size(1021, 806);
            this.flowLayoutPanel_SelectZone.TabIndex = 0;
            // 
            // EditExhibit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(1419, 990);
            this.Controls.Add(this.groupBox14);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EditExhibit";
            this.Text = "EditExhibit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditExhibit_FormClosed);
            this.groupBox14.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox24.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox14;
        private GroupBox groupBox24;
        private Button button_GetZones;
        private FlowLayoutPanel flowLayoutPanel_SelectZone;
		private Panel panel1;
		private Button btnExhibitEdit;
		private Label label32;
		private CheckBox chboxPredatorEditExhibit;
		private Label label31;
		private ComboBox cmboxEditExhibitType;
		private CheckBox chboxPreyEditExhibit;
		private TextBox txtboxEditExhibitName;
	}
}