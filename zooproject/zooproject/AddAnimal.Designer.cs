namespace zooproject
{
    partial class AddAnimal
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.button_Previous = new System.Windows.Forms.Button();
			this.button_Next = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.button_AddAnimal = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LimeGreen;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.button_AddAnimal);
			this.panel1.Controls.Add(this.button_Previous);
			this.panel1.Controls.Add(this.button_Next);
			this.panel1.Location = new System.Drawing.Point(837, 42);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(114, 720);
			this.panel1.TabIndex = 29;
			// 
			// button_Previous
			// 
			this.button_Previous.Location = new System.Drawing.Point(3, 686);
			this.button_Previous.Name = "button_Previous";
			this.button_Previous.Size = new System.Drawing.Size(106, 29);
			this.button_Previous.TabIndex = 1;
			this.button_Previous.Text = "Previous";
			this.button_Previous.UseVisualStyleBackColor = true;
			this.button_Previous.Click += new System.EventHandler(this.button_Previous_Click);
			// 
			// button_Next
			// 
			this.button_Next.Location = new System.Drawing.Point(3, 6);
			this.button_Next.Name = "button_Next";
			this.button_Next.Size = new System.Drawing.Size(106, 29);
			this.button_Next.TabIndex = 0;
			this.button_Next.Text = "Next";
			this.button_Next.UseVisualStyleBackColor = true;
			this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 42);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(819, 719);
			this.flowLayoutPanel1.TabIndex = 30;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 42);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(819, 719);
			this.flowLayoutPanel2.TabIndex = 0;
			// 
			// button_AddAnimal
			// 
			this.button_AddAnimal.Location = new System.Drawing.Point(3, 345);
			this.button_AddAnimal.Name = "button_AddAnimal";
			this.button_AddAnimal.Size = new System.Drawing.Size(106, 29);
			this.button_AddAnimal.TabIndex = 2;
			this.button_AddAnimal.Text = "Add Animal";
			this.button_AddAnimal.UseVisualStyleBackColor = true;
			this.button_AddAnimal.Click += new System.EventHandler(this.button_AddAnimal_Click);
			// 
			// AddAnimal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LimeGreen;
			this.ClientSize = new System.Drawing.Size(963, 789);
			this.Controls.Add(this.flowLayoutPanel2);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Name = "AddAnimal";
			this.Text = "AddAnimal";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddAnimal_FormClosed);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
		private Panel panel1;
		private Button button_Previous;
		private Button button_Next;
		public FlowLayoutPanel flowLayoutPanel1;
		public FlowLayoutPanel flowLayoutPanel2;
		private Button button_AddAnimal;
	}
}