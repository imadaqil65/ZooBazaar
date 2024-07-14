namespace zooproject
{
    partial class MoveAnimal
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton_Internal = new System.Windows.Forms.RadioButton();
            this.radioButton_Deceased = new System.Windows.Forms.RadioButton();
            this.radioButton_External = new System.Windows.Forms.RadioButton();
            this.cmBoxMoveAnimalZoo = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpMoveAnimalMovingDate = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.rtxtBoxMoveAnimalMovingReason = new System.Windows.Forms.RichTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnMoveAnimal = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_AnimalsInExhibit = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.flpMoveAnimalsExhibit = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.button_ApplyFilter = new System.Windows.Forms.Button();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_MoveAnimal_SelectExhibit = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(17, 20);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1139, 678);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.PaleGreen;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox21);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1131, 640);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Move Animal";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(9, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(376, 603);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Exhibit";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(9, 35);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(359, 557);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.panel1);
            this.groupBox21.Controls.Add(this.cmBoxMoveAnimalZoo);
            this.groupBox21.Controls.Add(this.label20);
            this.groupBox21.Controls.Add(this.dtpMoveAnimalMovingDate);
            this.groupBox21.Controls.Add(this.label25);
            this.groupBox21.Controls.Add(this.rtxtBoxMoveAnimalMovingReason);
            this.groupBox21.Controls.Add(this.label21);
            this.groupBox21.Controls.Add(this.btnMoveAnimal);
            this.groupBox21.Location = new System.Drawing.Point(393, 10);
            this.groupBox21.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox21.Size = new System.Drawing.Size(726, 607);
            this.groupBox21.TabIndex = 23;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Move Information";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioButton_Internal);
            this.panel1.Controls.Add(this.radioButton_Deceased);
            this.panel1.Controls.Add(this.radioButton_External);
            this.panel1.Location = new System.Drawing.Point(440, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 125);
            this.panel1.TabIndex = 29;
            // 
            // radioButton_Internal
            // 
            this.radioButton_Internal.AutoSize = true;
            this.radioButton_Internal.Location = new System.Drawing.Point(4, 5);
            this.radioButton_Internal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_Internal.Name = "radioButton_Internal";
            this.radioButton_Internal.Size = new System.Drawing.Size(146, 29);
            this.radioButton_Internal.TabIndex = 26;
            this.radioButton_Internal.TabStop = true;
            this.radioButton_Internal.Text = "Internal Move";
            this.radioButton_Internal.UseVisualStyleBackColor = true;
            // 
            // radioButton_Deceased
            // 
            this.radioButton_Deceased.AutoSize = true;
            this.radioButton_Deceased.Location = new System.Drawing.Point(4, 85);
            this.radioButton_Deceased.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_Deceased.Name = "radioButton_Deceased";
            this.radioButton_Deceased.Size = new System.Drawing.Size(113, 29);
            this.radioButton_Deceased.TabIndex = 28;
            this.radioButton_Deceased.TabStop = true;
            this.radioButton_Deceased.Text = "Deceased";
            this.radioButton_Deceased.UseVisualStyleBackColor = true;
            // 
            // radioButton_External
            // 
            this.radioButton_External.AutoSize = true;
            this.radioButton_External.Location = new System.Drawing.Point(4, 43);
            this.radioButton_External.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_External.Name = "radioButton_External";
            this.radioButton_External.Size = new System.Drawing.Size(148, 29);
            this.radioButton_External.TabIndex = 27;
            this.radioButton_External.TabStop = true;
            this.radioButton_External.Text = "External Move";
            this.radioButton_External.UseVisualStyleBackColor = true;
            // 
            // cmBoxMoveAnimalZoo
            // 
            this.cmBoxMoveAnimalZoo.DisplayMember = "Name";
            this.cmBoxMoveAnimalZoo.FormattingEnabled = true;
            this.cmBoxMoveAnimalZoo.Location = new System.Drawing.Point(114, 35);
            this.cmBoxMoveAnimalZoo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmBoxMoveAnimalZoo.Name = "cmBoxMoveAnimalZoo";
            this.cmBoxMoveAnimalZoo.Size = new System.Drawing.Size(315, 33);
            this.cmBoxMoveAnimalZoo.TabIndex = 12;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 35);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(44, 25);
            this.label20.TabIndex = 13;
            this.label20.Text = "Zoo";
            // 
            // dtpMoveAnimalMovingDate
            // 
            this.dtpMoveAnimalMovingDate.Location = new System.Drawing.Point(114, 98);
            this.dtpMoveAnimalMovingDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpMoveAnimalMovingDate.Name = "dtpMoveAnimalMovingDate";
            this.dtpMoveAnimalMovingDate.Size = new System.Drawing.Size(315, 31);
            this.dtpMoveAnimalMovingDate.TabIndex = 14;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(9, 173);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(78, 50);
            this.label25.TabIndex = 17;
            this.label25.Text = "Moving \r\nReason\r\n";
            // 
            // rtxtBoxMoveAnimalMovingReason
            // 
            this.rtxtBoxMoveAnimalMovingReason.Location = new System.Drawing.Point(114, 173);
            this.rtxtBoxMoveAnimalMovingReason.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtxtBoxMoveAnimalMovingReason.Name = "rtxtBoxMoveAnimalMovingReason";
            this.rtxtBoxMoveAnimalMovingReason.Size = new System.Drawing.Size(315, 304);
            this.rtxtBoxMoveAnimalMovingReason.TabIndex = 16;
            this.rtxtBoxMoveAnimalMovingReason.Text = "";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(9, 98);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(99, 25);
            this.label21.TabIndex = 15;
            this.label21.Text = "Move Date";
            // 
            // btnMoveAnimal
            // 
            this.btnMoveAnimal.Location = new System.Drawing.Point(114, 487);
            this.btnMoveAnimal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveAnimal.Name = "btnMoveAnimal";
            this.btnMoveAnimal.Size = new System.Drawing.Size(316, 47);
            this.btnMoveAnimal.TabIndex = 1;
            this.btnMoveAnimal.Text = "Move Animal";
            this.btnMoveAnimal.UseVisualStyleBackColor = true;
            this.btnMoveAnimal.Click += new System.EventHandler(this.btnMoveAnimal_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.PaleGreen;
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1131, 640);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Exhibit Selection";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox3.Controls.Add(this.flowLayoutPanel_AnimalsInExhibit);
            this.groupBox3.Location = new System.Drawing.Point(774, 10);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(344, 607);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Animals In Selected Exhibit";
            // 
            // flowLayoutPanel_AnimalsInExhibit
            // 
            this.flowLayoutPanel_AnimalsInExhibit.AutoScroll = true;
            this.flowLayoutPanel_AnimalsInExhibit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel_AnimalsInExhibit.Location = new System.Drawing.Point(9, 37);
            this.flowLayoutPanel_AnimalsInExhibit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel_AnimalsInExhibit.Name = "flowLayoutPanel_AnimalsInExhibit";
            this.flowLayoutPanel_AnimalsInExhibit.Size = new System.Drawing.Size(322, 555);
            this.flowLayoutPanel_AnimalsInExhibit.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox1.Controls.Add(this.groupBox23);
            this.groupBox1.Controls.Add(this.groupBox20);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(757, 607);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Exhibit";
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.flpMoveAnimalsExhibit);
            this.groupBox23.Location = new System.Drawing.Point(9, 178);
            this.groupBox23.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox23.Size = new System.Drawing.Size(739, 413);
            this.groupBox23.TabIndex = 26;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Select Exhibit";
            // 
            // flpMoveAnimalsExhibit
            // 
            this.flpMoveAnimalsExhibit.AutoScroll = true;
            this.flpMoveAnimalsExhibit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpMoveAnimalsExhibit.Location = new System.Drawing.Point(9, 35);
            this.flpMoveAnimalsExhibit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flpMoveAnimalsExhibit.Name = "flpMoveAnimalsExhibit";
            this.flpMoveAnimalsExhibit.Size = new System.Drawing.Size(718, 369);
            this.flpMoveAnimalsExhibit.TabIndex = 19;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.button_ApplyFilter);
            this.groupBox20.Controls.Add(this.button_Refresh);
            this.groupBox20.Controls.Add(this.label10);
            this.groupBox20.Controls.Add(this.comboBox_MoveAnimal_SelectExhibit);
            this.groupBox20.Location = new System.Drawing.Point(9, 35);
            this.groupBox20.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox20.Size = new System.Drawing.Size(739, 137);
            this.groupBox20.TabIndex = 25;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Exhibit Filters";
            // 
            // button_ApplyFilter
            // 
            this.button_ApplyFilter.Location = new System.Drawing.Point(623, 18);
            this.button_ApplyFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_ApplyFilter.Name = "button_ApplyFilter";
            this.button_ApplyFilter.Size = new System.Drawing.Size(107, 38);
            this.button_ApplyFilter.TabIndex = 9;
            this.button_ApplyFilter.Text = "Apply Filter";
            this.button_ApplyFilter.UseVisualStyleBackColor = true;
            this.button_ApplyFilter.Click += new System.EventHandler(this.button_ApplyFilter_Click);
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(623, 90);
            this.button_Refresh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(107, 38);
            this.button_Refresh.TabIndex = 8;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 32);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 25);
            this.label10.TabIndex = 4;
            this.label10.Text = "Zone";
            // 
            // comboBox_MoveAnimal_SelectExhibit
            // 
            this.comboBox_MoveAnimal_SelectExhibit.DisplayMember = "Name";
            this.comboBox_MoveAnimal_SelectExhibit.FormattingEnabled = true;
            this.comboBox_MoveAnimal_SelectExhibit.Location = new System.Drawing.Point(81, 25);
            this.comboBox_MoveAnimal_SelectExhibit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_MoveAnimal_SelectExhibit.Name = "comboBox_MoveAnimal_SelectExhibit";
            this.comboBox_MoveAnimal_SelectExhibit.Size = new System.Drawing.Size(215, 33);
            this.comboBox_MoveAnimal_SelectExhibit.TabIndex = 5;
            // 
            // MoveAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(1169, 712);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MoveAnimal";
            this.Text = "Move Animal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MoveAnimal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MoveRemoveAnimal_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBox21;
        private ComboBox cmBoxMoveAnimalZoo;
        private Label label20;
        private DateTimePicker dtpMoveAnimalMovingDate;
        private Label label25;
        private RichTextBox rtxtBoxMoveAnimalMovingReason;
        private Label label21;
        private Button btnMoveAnimal;
        private GroupBox groupBox2;
        private FlowLayoutPanel flowLayoutPanel2;
        private TabPage tabPage2;
        private GroupBox groupBox3;
        private FlowLayoutPanel flowLayoutPanel_AnimalsInExhibit;
        private GroupBox groupBox1;
        private GroupBox groupBox23;
        private FlowLayoutPanel flpMoveAnimalsExhibit;
        private GroupBox groupBox20;
        private Button button_Refresh;
        private Label label10;
        private ComboBox comboBox_MoveAnimal_SelectExhibit;
        private Button button_ApplyFilter;
        private RadioButton radioButton_External;
        private RadioButton radioButton_Internal;
        private RadioButton radioButton_Deceased;
        private Panel panel1;
    }
}