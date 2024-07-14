namespace zooproject.User_Controls
{
	partial class AddAnimalSelectExhibitControl
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
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.btnReloadExhibits = new System.Windows.Forms.Button();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.flpExhibitAnimals = new System.Windows.Forms.FlowLayoutPanel();
			this.flpAnimalExibits = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBox6.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.btnReloadExhibits);
			this.groupBox6.Controls.Add(this.groupBox13);
			this.groupBox6.Controls.Add(this.flpAnimalExibits);
			this.groupBox6.Location = new System.Drawing.Point(3, 3);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(823, 717);
			this.groupBox6.TabIndex = 29;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Select Exhibit";
			// 
			// btnReloadExhibits
			// 
			this.btnReloadExhibits.Location = new System.Drawing.Point(9, 25);
			this.btnReloadExhibits.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnReloadExhibits.Name = "btnReloadExhibits";
			this.btnReloadExhibits.Size = new System.Drawing.Size(120, 31);
			this.btnReloadExhibits.TabIndex = 6;
			this.btnReloadExhibits.Text = "Reload Exhibits";
			this.btnReloadExhibits.UseVisualStyleBackColor = true;
			this.btnReloadExhibits.Click += new System.EventHandler(this.btnReloadExhibits_Click);
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.flpExhibitAnimals);
			this.groupBox13.Location = new System.Drawing.Point(573, 19);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox13.Size = new System.Drawing.Size(243, 693);
			this.groupBox13.TabIndex = 5;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Animals In Selected Exhibit";
			// 
			// flpExhibitAnimals
			// 
			this.flpExhibitAnimals.AutoScroll = true;
			this.flpExhibitAnimals.Location = new System.Drawing.Point(7, 23);
			this.flpExhibitAnimals.Name = "flpExhibitAnimals";
			this.flpExhibitAnimals.Size = new System.Drawing.Size(227, 664);
			this.flpExhibitAnimals.TabIndex = 0;
			// 
			// flpAnimalExibits
			// 
			this.flpAnimalExibits.AutoScroll = true;
			this.flpAnimalExibits.Location = new System.Drawing.Point(9, 67);
			this.flpAnimalExibits.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.flpAnimalExibits.Name = "flpAnimalExibits";
			this.flpAnimalExibits.Size = new System.Drawing.Size(557, 639);
			this.flpAnimalExibits.TabIndex = 4;
			// 
			// AddAnimalSelectExhibitControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.PaleGreen;
			this.Controls.Add(this.groupBox6);
			this.Name = "AddAnimalSelectExhibitControl";
			this.Size = new System.Drawing.Size(819, 719);
			this.groupBox6.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private GroupBox groupBox6;
		private Button btnReloadExhibits;
		private GroupBox groupBox13;
		private FlowLayoutPanel flpExhibitAnimals;
		private FlowLayoutPanel flpAnimalExibits;
	}
}
