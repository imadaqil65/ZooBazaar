namespace zooproject
{
    partial class AnimalFilters
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
            this.comboBox_Species = new System.Windows.Forms.ComboBox();
            this.comboBox_Exhibit = new System.Windows.Forms.ComboBox();
            this.checkBox_Predator = new System.Windows.Forms.CheckBox();
            this.checkBox_Prey = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_EnviromentType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_ApplyFilter = new System.Windows.Forms.Button();
            this.checkBox_Species = new System.Windows.Forms.CheckBox();
            this.checkBox_EnviromentType = new System.Windows.Forms.CheckBox();
            this.checkBox_Exhibit = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_Species
            // 
            this.comboBox_Species.FormattingEnabled = true;
            this.comboBox_Species.Location = new System.Drawing.Point(134, 9);
            this.comboBox_Species.Name = "comboBox_Species";
            this.comboBox_Species.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Species.TabIndex = 0;
            // 
            // comboBox_Exhibit
            // 
            this.comboBox_Exhibit.DisplayMember = "Name";
            this.comboBox_Exhibit.FormattingEnabled = true;
            this.comboBox_Exhibit.Location = new System.Drawing.Point(134, 67);
            this.comboBox_Exhibit.Name = "comboBox_Exhibit";
            this.comboBox_Exhibit.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Exhibit.TabIndex = 1;
            // 
            // checkBox_Predator
            // 
            this.checkBox_Predator.AutoSize = true;
            this.checkBox_Predator.Location = new System.Drawing.Point(134, 96);
            this.checkBox_Predator.Name = "checkBox_Predator";
            this.checkBox_Predator.Size = new System.Drawing.Size(71, 19);
            this.checkBox_Predator.TabIndex = 2;
            this.checkBox_Predator.Text = "Predator";
            this.checkBox_Predator.UseVisualStyleBackColor = true;
            // 
            // checkBox_Prey
            // 
            this.checkBox_Prey.AutoSize = true;
            this.checkBox_Prey.Location = new System.Drawing.Point(206, 96);
            this.checkBox_Prey.Name = "checkBox_Prey";
            this.checkBox_Prey.Size = new System.Drawing.Size(49, 19);
            this.checkBox_Prey.TabIndex = 3;
            this.checkBox_Prey.Text = "Prey";
            this.checkBox_Prey.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Species";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Exhibit";
            // 
            // comboBox_EnviromentType
            // 
            this.comboBox_EnviromentType.FormattingEnabled = true;
            this.comboBox_EnviromentType.Location = new System.Drawing.Point(134, 38);
            this.comboBox_EnviromentType.Name = "comboBox_EnviromentType";
            this.comboBox_EnviromentType.Size = new System.Drawing.Size(121, 23);
            this.comboBox_EnviromentType.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Enviroment Type";
            // 
            // button_ApplyFilter
            // 
            this.button_ApplyFilter.Location = new System.Drawing.Point(134, 121);
            this.button_ApplyFilter.Name = "button_ApplyFilter";
            this.button_ApplyFilter.Size = new System.Drawing.Size(121, 23);
            this.button_ApplyFilter.TabIndex = 8;
            this.button_ApplyFilter.Text = "Apply Filter";
            this.button_ApplyFilter.UseVisualStyleBackColor = true;
            this.button_ApplyFilter.Click += new System.EventHandler(this.button_ApplyFilter_Click);
            // 
            // checkBox_Species
            // 
            this.checkBox_Species.AutoSize = true;
            this.checkBox_Species.Location = new System.Drawing.Point(113, 9);
            this.checkBox_Species.Name = "checkBox_Species";
            this.checkBox_Species.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Species.TabIndex = 9;
            this.checkBox_Species.UseVisualStyleBackColor = true;
            this.checkBox_Species.CheckedChanged += new System.EventHandler(this.checkBox_Species_CheckedChanged);
            // 
            // checkBox_EnviromentType
            // 
            this.checkBox_EnviromentType.AutoSize = true;
            this.checkBox_EnviromentType.Location = new System.Drawing.Point(113, 38);
            this.checkBox_EnviromentType.Name = "checkBox_EnviromentType";
            this.checkBox_EnviromentType.Size = new System.Drawing.Size(15, 14);
            this.checkBox_EnviromentType.TabIndex = 10;
            this.checkBox_EnviromentType.UseVisualStyleBackColor = true;
            this.checkBox_EnviromentType.CheckedChanged += new System.EventHandler(this.checkBox_EnviromentType_CheckedChanged);
            // 
            // checkBox_Exhibit
            // 
            this.checkBox_Exhibit.AutoSize = true;
            this.checkBox_Exhibit.Location = new System.Drawing.Point(113, 67);
            this.checkBox_Exhibit.Name = "checkBox_Exhibit";
            this.checkBox_Exhibit.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Exhibit.TabIndex = 11;
            this.checkBox_Exhibit.UseVisualStyleBackColor = true;
            this.checkBox_Exhibit.CheckedChanged += new System.EventHandler(this.checkBox_Exhibit_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "label6";
            // 
            // AnimalFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(326, 154);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox_Exhibit);
            this.Controls.Add(this.checkBox_EnviromentType);
            this.Controls.Add(this.checkBox_Species);
            this.Controls.Add(this.button_ApplyFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_EnviromentType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_Prey);
            this.Controls.Add(this.checkBox_Predator);
            this.Controls.Add(this.comboBox_Exhibit);
            this.Controls.Add(this.comboBox_Species);
            this.Name = "AnimalFilters";
            this.Text = "AnimalFilters";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnimalFilters_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboBox_Species;
        private ComboBox comboBox_Exhibit;
        private CheckBox checkBox_Predator;
        private CheckBox checkBox_Prey;
        private Label label1;
        private Label label2;
        private ComboBox comboBox_EnviromentType;
        private Label label3;
        private Button button_ApplyFilter;
        private CheckBox checkBox_Species;
        private CheckBox checkBox_EnviromentType;
        private CheckBox checkBox_Exhibit;
		private Label label4;
		private Label label5;
		private Label label6;
	}
}