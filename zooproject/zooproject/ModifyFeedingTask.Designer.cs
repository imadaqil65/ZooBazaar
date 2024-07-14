namespace zooproject
{
    partial class ModifyFeedingTask
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
            lblExhibit = new Label();
            lblSpecies = new Label();
            lblDiet = new Label();
            groupBox1 = new GroupBox();
            btnAssign = new Button();
            btnReload = new Button();
            flpEmployees = new FlowLayoutPanel();
            lblEmployeeLimit = new Label();
            groupBox2 = new GroupBox();
            btnReloadAssigned = new Button();
            flpAssignedEmp = new FlowLayoutPanel();
            groupBox3 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // lblExhibit
            // 
            lblExhibit.AutoSize = true;
            lblExhibit.Location = new Point(8, 18);
            lblExhibit.Name = "lblExhibit";
            lblExhibit.Size = new Size(59, 15);
            lblExhibit.TabIndex = 0;
            lblExhibit.Text = "<exhibit>";
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new Point(8, 42);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(61, 15);
            lblSpecies.TabIndex = 0;
            lblSpecies.Text = "<species>";
            // 
            // lblDiet
            // 
            lblDiet.AutoSize = true;
            lblDiet.Location = new Point(8, 67);
            lblDiet.Name = "lblDiet";
            lblDiet.Size = new Size(43, 15);
            lblDiet.TabIndex = 0;
            lblDiet.Text = "<diet>";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAssign);
            groupBox1.Controls.Add(btnReload);
            groupBox1.Controls.Add(flpEmployees);
            groupBox1.Location = new Point(453, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(241, 390);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Employees";
            // 
            // btnAssign
            // 
            btnAssign.Location = new Point(5, 352);
            btnAssign.Name = "btnAssign";
            btnAssign.Size = new Size(230, 23);
            btnAssign.TabIndex = 0;
            btnAssign.Text = "Assign Employee";
            btnAssign.UseVisualStyleBackColor = true;
            btnAssign.Click += btnAssign_Click;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(5, 22);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(230, 23);
            btnReload.TabIndex = 0;
            btnReload.Text = "Reload Employees";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // flpEmployees
            // 
            flpEmployees.AutoScroll = true;
            flpEmployees.Location = new Point(5, 55);
            flpEmployees.Name = "flpEmployees";
            flpEmployees.Size = new Size(230, 291);
            flpEmployees.TabIndex = 0;
            // 
            // lblEmployeeLimit
            // 
            lblEmployeeLimit.AutoSize = true;
            lblEmployeeLimit.Location = new Point(8, 82);
            lblEmployeeLimit.Name = "lblEmployeeLimit";
            lblEmployeeLimit.Size = new Size(99, 15);
            lblEmployeeLimit.TabIndex = 0;
            lblEmployeeLimit.Text = "<employeelimit>";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnReloadAssigned);
            groupBox2.Controls.Add(flpAssignedEmp);
            groupBox2.Location = new Point(173, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(241, 390);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Assigned Employees";
            // 
            // btnReloadAssigned
            // 
            btnReloadAssigned.Location = new Point(5, 22);
            btnReloadAssigned.Name = "btnReloadAssigned";
            btnReloadAssigned.Size = new Size(230, 23);
            btnReloadAssigned.TabIndex = 0;
            btnReloadAssigned.Text = "Reload Employees";
            btnReloadAssigned.UseVisualStyleBackColor = true;
            btnReloadAssigned.Click += btnReloadAssigned_Click;
            // 
            // flpAssignedEmp
            // 
            flpAssignedEmp.AutoScroll = true;
            flpAssignedEmp.Location = new Point(5, 55);
            flpAssignedEmp.Name = "flpAssignedEmp";
            flpAssignedEmp.Size = new Size(230, 291);
            flpAssignedEmp.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblExhibit);
            groupBox3.Controls.Add(lblSpecies);
            groupBox3.Controls.Add(lblDiet);
            groupBox3.Controls.Add(lblEmployeeLimit);
            groupBox3.Location = new Point(2, 34);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(165, 324);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Details";
            // 
            // ModifyFeedingTask
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGreen;
            ClientSize = new Size(861, 431);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "ModifyFeedingTask";
            Text = "Feeding Task Details";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblExhibit;
        private Label lblSpecies;
        private Label lblDiet;
        private GroupBox groupBox1;
        private Button btnAssign;
        private Button btnReload;
        private FlowLayoutPanel flpEmployees;
        private Label lblEmployeeLimit;
        private GroupBox groupBox2;
        private Button btnReloadAssigned;
        private FlowLayoutPanel flpAssignedEmp;
        private GroupBox groupBox3;
    }
}