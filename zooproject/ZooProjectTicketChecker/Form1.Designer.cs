namespace ZooProjectTicketChecker
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			BarcodeTxtBx = new TextBox();
			label1 = new Label();
			SuspendLayout();
			// 
			// BarcodeTxtBx
			// 
			BarcodeTxtBx.Location = new Point(90, 12);
			BarcodeTxtBx.Name = "BarcodeTxtBx";
			BarcodeTxtBx.Size = new Size(478, 23);
			BarcodeTxtBx.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(11, 15);
			label1.Name = "label1";
			label1.Size = new Size(53, 15);
			label1.TabIndex = 5;
			label1.Text = "Barcode:";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(605, 46);
			Controls.Add(label1);
			Controls.Add(BarcodeTxtBx);
			Name = "Form1";
			Text = "Ticket Scanner";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private TextBox BarcodeTxtBx;
		private Label label1;
	}
}