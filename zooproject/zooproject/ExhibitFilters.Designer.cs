namespace zooproject
{
    partial class ExhibitFilters
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
            this.comboBox_EnviromentType = new System.Windows.Forms.ComboBox();
            this.comboBox_Zone = new System.Windows.Forms.ComboBox();
            this.checkBox_Predetory = new System.Windows.Forms.CheckBox();
            this.checkBox_Prey = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_ApplyFilter = new System.Windows.Forms.Button();
            this.checkBox_Enviroment = new System.Windows.Forms.CheckBox();
            this.checkBox_Zone = new System.Windows.Forms.CheckBox();
            this.label_ZoneSelected = new System.Windows.Forms.Label();
            this.label_EnviromentSelected = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_EnviromentType
            // 
            this.comboBox_EnviromentType.FormattingEnabled = true;
            this.comboBox_EnviromentType.Location = new System.Drawing.Point(144, 10);
            this.comboBox_EnviromentType.Name = "comboBox_EnviromentType";
            this.comboBox_EnviromentType.Size = new System.Drawing.Size(132, 23);
            this.comboBox_EnviromentType.TabIndex = 0;
            // 
            // comboBox_Zone
            // 
            this.comboBox_Zone.DisplayMember = "Name";
            this.comboBox_Zone.FormattingEnabled = true;
            this.comboBox_Zone.Location = new System.Drawing.Point(144, 39);
            this.comboBox_Zone.Name = "comboBox_Zone";
            this.comboBox_Zone.Size = new System.Drawing.Size(132, 23);
            this.comboBox_Zone.TabIndex = 1;
            // 
            // checkBox_Predetory
            // 
            this.checkBox_Predetory.AutoSize = true;
            this.checkBox_Predetory.Location = new System.Drawing.Point(144, 68);
            this.checkBox_Predetory.Name = "checkBox_Predetory";
            this.checkBox_Predetory.Size = new System.Drawing.Size(77, 19);
            this.checkBox_Predetory.TabIndex = 2;
            this.checkBox_Predetory.Text = "Predetory";
            this.checkBox_Predetory.UseVisualStyleBackColor = true;
            this.checkBox_Predetory.Click += new System.EventHandler(this.checkBox_Predetory_Click);
            // 
            // checkBox_Prey
            // 
            this.checkBox_Prey.AutoSize = true;
            this.checkBox_Prey.Location = new System.Drawing.Point(227, 68);
            this.checkBox_Prey.Name = "checkBox_Prey";
            this.checkBox_Prey.Size = new System.Drawing.Size(49, 19);
            this.checkBox_Prey.TabIndex = 3;
            this.checkBox_Prey.Text = "Prey";
            this.checkBox_Prey.UseVisualStyleBackColor = true;
            this.checkBox_Prey.Click += new System.EventHandler(this.checkBox_Prey_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enviroment type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Zone";
            // 
            // button_ApplyFilter
            // 
            this.button_ApplyFilter.Location = new System.Drawing.Point(144, 93);
            this.button_ApplyFilter.Name = "button_ApplyFilter";
            this.button_ApplyFilter.Size = new System.Drawing.Size(132, 23);
            this.button_ApplyFilter.TabIndex = 6;
            this.button_ApplyFilter.Text = "Apply Filter";
            this.button_ApplyFilter.UseVisualStyleBackColor = true;
            this.button_ApplyFilter.Click += new System.EventHandler(this.button_ApplyFilter_Click);
            // 
            // checkBox_Enviroment
            // 
            this.checkBox_Enviroment.AutoSize = true;
            this.checkBox_Enviroment.Location = new System.Drawing.Point(123, 10);
            this.checkBox_Enviroment.Name = "checkBox_Enviroment";
            this.checkBox_Enviroment.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Enviroment.TabIndex = 7;
            this.checkBox_Enviroment.UseVisualStyleBackColor = true;
            this.checkBox_Enviroment.CheckedChanged += new System.EventHandler(this.checkBox_Enviroment_CheckedChanged);
            // 
            // checkBox_Zone
            // 
            this.checkBox_Zone.AutoSize = true;
            this.checkBox_Zone.Location = new System.Drawing.Point(123, 39);
            this.checkBox_Zone.Name = "checkBox_Zone";
            this.checkBox_Zone.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Zone.TabIndex = 8;
            this.checkBox_Zone.UseVisualStyleBackColor = true;
            this.checkBox_Zone.CheckedChanged += new System.EventHandler(this.checkBox_Zone_CheckedChanged);
            // 
            // label_ZoneSelected
            // 
            this.label_ZoneSelected.AutoSize = true;
            this.label_ZoneSelected.Location = new System.Drawing.Point(282, 39);
            this.label_ZoneSelected.Name = "label_ZoneSelected";
            this.label_ZoneSelected.Size = new System.Drawing.Size(51, 15);
            this.label_ZoneSelected.TabIndex = 10;
            this.label_ZoneSelected.Text = "Selected";
            // 
            // label_EnviromentSelected
            // 
            this.label_EnviromentSelected.AutoSize = true;
            this.label_EnviromentSelected.Location = new System.Drawing.Point(282, 10);
            this.label_EnviromentSelected.Name = "label_EnviromentSelected";
            this.label_EnviromentSelected.Size = new System.Drawing.Size(51, 15);
            this.label_EnviromentSelected.TabIndex = 9;
            this.label_EnviromentSelected.Text = "Selected";
            // 
            // ExhibitFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(337, 129);
            this.Controls.Add(this.label_ZoneSelected);
            this.Controls.Add(this.label_EnviromentSelected);
            this.Controls.Add(this.checkBox_Zone);
            this.Controls.Add(this.checkBox_Enviroment);
            this.Controls.Add(this.button_ApplyFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_Prey);
            this.Controls.Add(this.checkBox_Predetory);
            this.Controls.Add(this.comboBox_Zone);
            this.Controls.Add(this.comboBox_EnviromentType);
            this.Name = "ExhibitFilters";
            this.Text = "ExhibitFilters";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExhibitFilters_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboBox_EnviromentType;
        private ComboBox comboBox_Zone;
        private CheckBox checkBox_Predetory;
        private CheckBox checkBox_Prey;
        private Label label1;
        private Label label2;
        private Button button_ApplyFilter;
        private CheckBox checkBox_Enviroment;
        private CheckBox checkBox_Zone;
        private Label label_ZoneSelected;
        private Label label_EnviromentSelected;
    }
}