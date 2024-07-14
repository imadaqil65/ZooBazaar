namespace zooproject
{
	partial class Exhibits
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
            this.button_GetAllZonesExhibit = new System.Windows.Forms.Button();
            this.flowLayoutPanel_SelectZone = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnCreateExhibit = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.cmboxExhibitType = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cboxExhibitPrey = new System.Windows.Forms.CheckBox();
            this.cboxExhibitPredator = new System.Windows.Forms.CheckBox();
            this.txtboxExhibitName = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_GetExhibits = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Zones = new System.Windows.Forms.Button();
            this.button_Exhibits_Exhibits = new System.Windows.Forms.Button();
            this.button_Exhibits_LogOut = new System.Windows.Forms.Button();
            this.Button_Exhibits_Employee = new System.Windows.Forms.Button();
            this.button_Exhibits_Animals = new System.Windows.Forms.Button();
            this.button_Exhibit_Home = new System.Windows.Forms.Button();
            this.button_ZooPartner = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(114, 13);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(575, 487);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox9);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(567, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Exhibit";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_GetAllZonesExhibit);
            this.groupBox2.Controls.Add(this.flowLayoutPanel_SelectZone);
            this.groupBox2.Location = new System.Drawing.Point(219, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 447);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Zone";
            // 
            // button_GetAllZonesExhibit
            // 
            this.button_GetAllZonesExhibit.Location = new System.Drawing.Point(6, 17);
            this.button_GetAllZonesExhibit.Name = "button_GetAllZonesExhibit";
            this.button_GetAllZonesExhibit.Size = new System.Drawing.Size(75, 23);
            this.button_GetAllZonesExhibit.TabIndex = 1;
            this.button_GetAllZonesExhibit.Text = "Get All";
            this.button_GetAllZonesExhibit.UseVisualStyleBackColor = true;
            this.button_GetAllZonesExhibit.Click += new System.EventHandler(this.button_GetAllZonesExhibit_Click);
            // 
            // flowLayoutPanel_SelectZone
            // 
            this.flowLayoutPanel_SelectZone.Location = new System.Drawing.Point(6, 45);
            this.flowLayoutPanel_SelectZone.Name = "flowLayoutPanel_SelectZone";
            this.flowLayoutPanel_SelectZone.Size = new System.Drawing.Size(330, 396);
            this.flowLayoutPanel_SelectZone.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnCreateExhibit);
            this.groupBox9.Controls.Add(this.label30);
            this.groupBox9.Controls.Add(this.cmboxExhibitType);
            this.groupBox9.Controls.Add(this.label29);
            this.groupBox9.Controls.Add(this.cboxExhibitPrey);
            this.groupBox9.Controls.Add(this.cboxExhibitPredator);
            this.groupBox9.Controls.Add(this.txtboxExhibitName);
            this.groupBox9.Location = new System.Drawing.Point(6, 7);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Size = new System.Drawing.Size(207, 448);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Information";
            // 
            // btnCreateExhibit
            // 
            this.btnCreateExhibit.Location = new System.Drawing.Point(53, 116);
            this.btnCreateExhibit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateExhibit.Name = "btnCreateExhibit";
            this.btnCreateExhibit.Size = new System.Drawing.Size(137, 22);
            this.btnCreateExhibit.TabIndex = 5;
            this.btnCreateExhibit.Text = "Create Exhibit";
            this.btnCreateExhibit.UseVisualStyleBackColor = true;
            this.btnCreateExhibit.Click += new System.EventHandler(this.btnCreateExhibit_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(1, 68);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(43, 30);
            this.label30.TabIndex = 4;
            this.label30.Text = "Exhibit\r\nType";
            // 
            // cmboxExhibitType
            // 
            this.cmboxExhibitType.FormattingEnabled = true;
            this.cmboxExhibitType.Location = new System.Drawing.Point(53, 69);
            this.cmboxExhibitType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmboxExhibitType.Name = "cmboxExhibitType";
            this.cmboxExhibitType.Size = new System.Drawing.Size(140, 23);
            this.cmboxExhibitType.TabIndex = 3;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 21);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(39, 15);
            this.label29.TabIndex = 0;
            this.label29.Text = "Name";
            // 
            // cboxExhibitPrey
            // 
            this.cboxExhibitPrey.AutoSize = true;
            this.cboxExhibitPrey.Location = new System.Drawing.Point(141, 45);
            this.cboxExhibitPrey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboxExhibitPrey.Name = "cboxExhibitPrey";
            this.cboxExhibitPrey.Size = new System.Drawing.Size(49, 19);
            this.cboxExhibitPrey.TabIndex = 2;
            this.cboxExhibitPrey.Text = "Prey";
            this.cboxExhibitPrey.UseVisualStyleBackColor = true;
            // 
            // cboxExhibitPredator
            // 
            this.cboxExhibitPredator.AutoSize = true;
            this.cboxExhibitPredator.Location = new System.Drawing.Point(53, 45);
            this.cboxExhibitPredator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboxExhibitPredator.Name = "cboxExhibitPredator";
            this.cboxExhibitPredator.Size = new System.Drawing.Size(77, 19);
            this.cboxExhibitPredator.TabIndex = 1;
            this.cboxExhibitPredator.Text = "Predatory";
            this.cboxExhibitPredator.UseVisualStyleBackColor = true;
            // 
            // txtboxExhibitName
            // 
            this.txtboxExhibitName.Location = new System.Drawing.Point(53, 22);
            this.txtboxExhibitName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtboxExhibitName.Name = "txtboxExhibitName";
            this.txtboxExhibitName.Size = new System.Drawing.Size(140, 23);
            this.txtboxExhibitName.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(567, 459);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Modify Exhibits";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_GetExhibits);
            this.groupBox3.Controls.Add(this.flowLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(6, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(555, 446);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Exhibit";
            // 
            // button_GetExhibits
            // 
            this.button_GetExhibits.Location = new System.Drawing.Point(6, 23);
            this.button_GetExhibits.Name = "button_GetExhibits";
            this.button_GetExhibits.Size = new System.Drawing.Size(98, 23);
            this.button_GetExhibits.TabIndex = 16;
            this.button_GetExhibits.Text = "Get Exhibits";
            this.button_GetExhibits.UseVisualStyleBackColor = true;
            this.button_GetExhibits.Click += new System.EventHandler(this.button_GetExhibits_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 52);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(543, 380);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_ZooPartner);
            this.groupBox1.Controls.Add(this.button_Zones);
            this.groupBox1.Controls.Add(this.button_Exhibits_Exhibits);
            this.groupBox1.Controls.Add(this.button_Exhibits_LogOut);
            this.groupBox1.Controls.Add(this.Button_Exhibits_Employee);
            this.groupBox1.Controls.Add(this.button_Exhibits_Animals);
            this.groupBox1.Controls.Add(this.button_Exhibit_Home);
            this.groupBox1.Location = new System.Drawing.Point(10, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(99, 487);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // button_Zones
            // 
            this.button_Zones.Location = new System.Drawing.Point(7, 134);
            this.button_Zones.Name = "button_Zones";
            this.button_Zones.Size = new System.Drawing.Size(83, 23);
            this.button_Zones.TabIndex = 6;
            this.button_Zones.Text = "Zones";
            this.button_Zones.UseVisualStyleBackColor = true;
            this.button_Zones.Click += new System.EventHandler(this.button_Zones_Click);
            // 
            // button_Exhibits_Exhibits
            // 
            this.button_Exhibits_Exhibits.Location = new System.Drawing.Point(7, 109);
            this.button_Exhibits_Exhibits.Margin = new System.Windows.Forms.Padding(2);
            this.button_Exhibits_Exhibits.Name = "button_Exhibits_Exhibits";
            this.button_Exhibits_Exhibits.Size = new System.Drawing.Size(83, 20);
            this.button_Exhibits_Exhibits.TabIndex = 5;
            this.button_Exhibits_Exhibits.Text = "Exhibits";
            this.button_Exhibits_Exhibits.UseVisualStyleBackColor = true;
            // 
            // button_Exhibits_LogOut
            // 
            this.button_Exhibits_LogOut.Location = new System.Drawing.Point(7, 460);
            this.button_Exhibits_LogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Exhibits_LogOut.Name = "button_Exhibits_LogOut";
            this.button_Exhibits_LogOut.Size = new System.Drawing.Size(83, 22);
            this.button_Exhibits_LogOut.TabIndex = 4;
            this.button_Exhibits_LogOut.Text = "Logout";
            this.button_Exhibits_LogOut.UseVisualStyleBackColor = true;
            this.button_Exhibits_LogOut.Click += new System.EventHandler(this.button_Exhibits_LogOut_Click);
            // 
            // Button_Exhibits_Employee
            // 
            this.Button_Exhibits_Employee.Location = new System.Drawing.Point(7, 83);
            this.Button_Exhibits_Employee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button_Exhibits_Employee.Name = "Button_Exhibits_Employee";
            this.Button_Exhibits_Employee.Size = new System.Drawing.Size(83, 22);
            this.Button_Exhibits_Employee.TabIndex = 2;
            this.Button_Exhibits_Employee.Text = "Employees";
            this.Button_Exhibits_Employee.UseVisualStyleBackColor = true;
            this.Button_Exhibits_Employee.Click += new System.EventHandler(this.Button_Exhibits_Employee_Click);
            // 
            // button_Exhibits_Animals
            // 
            this.button_Exhibits_Animals.Location = new System.Drawing.Point(7, 57);
            this.button_Exhibits_Animals.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Exhibits_Animals.Name = "button_Exhibits_Animals";
            this.button_Exhibits_Animals.Size = new System.Drawing.Size(83, 22);
            this.button_Exhibits_Animals.TabIndex = 1;
            this.button_Exhibits_Animals.Text = "Animals";
            this.button_Exhibits_Animals.UseVisualStyleBackColor = true;
            this.button_Exhibits_Animals.Click += new System.EventHandler(this.button_Exhibits_Animals_Click);
            // 
            // button_Exhibit_Home
            // 
            this.button_Exhibit_Home.Location = new System.Drawing.Point(7, 31);
            this.button_Exhibit_Home.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Exhibit_Home.Name = "button_Exhibit_Home";
            this.button_Exhibit_Home.Size = new System.Drawing.Size(83, 22);
            this.button_Exhibit_Home.TabIndex = 0;
            this.button_Exhibit_Home.Text = "Home";
            this.button_Exhibit_Home.UseVisualStyleBackColor = true;
            this.button_Exhibit_Home.Click += new System.EventHandler(this.button_Exhibit_Home_Click);
            // 
            // button_ZooPartner
            // 
            this.button_ZooPartner.Location = new System.Drawing.Point(7, 163);
            this.button_ZooPartner.Name = "button_ZooPartner";
            this.button_ZooPartner.Size = new System.Drawing.Size(83, 23);
            this.button_ZooPartner.TabIndex = 9;
            this.button_ZooPartner.Text = "Zoo Partner";
            this.button_ZooPartner.UseVisualStyleBackColor = true;
            this.button_ZooPartner.Click += new System.EventHandler(this.button_ZooPartner_Click);
            // 
            // Exhibits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 506);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Exhibits";
            this.Text = "Exhibits";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Exhibits_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Exhibits_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private TabControl tabControl1;
		private TabPage tabPage1;
		private GroupBox groupBox1;
		private Button button_Exhibits_Exhibits;
		private Button button_Exhibits_LogOut;
		private Button Button_Exhibits_Employee;
		private Button button_Exhibits_Animals;
		private Button button_Exhibit_Home;
        private GroupBox groupBox9;
        private Button btnCreateExhibit;
        private Label label30;
        private ComboBox cmboxExhibitType;
        private Label label29;
        private CheckBox cboxExhibitPrey;
        private CheckBox cboxExhibitPredator;
        private TextBox txtboxExhibitName;
        private GroupBox groupBox2;
        private FlowLayoutPanel flowLayoutPanel_SelectZone;
        private Button button_GetAllZonesExhibit;
        private TabPage tabPage3;
        private GroupBox groupBox3;
        private Button button_GetExhibits;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button_Zones;
        private Button button_ZooPartner;
    }
}