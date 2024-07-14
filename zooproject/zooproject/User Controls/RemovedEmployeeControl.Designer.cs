namespace zooproject.User_Controls
{
    partial class RemovedEmployeeControl
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
            this.button_Reinstate = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.label_name = new System.Windows.Forms.Label();
            this.label_Department = new System.Windows.Forms.Label();
            this.label_Specialization = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Reinstate
            // 
            this.button_Reinstate.Location = new System.Drawing.Point(42, 142);
            this.button_Reinstate.Name = "button_Reinstate";
            this.button_Reinstate.Size = new System.Drawing.Size(112, 34);
            this.button_Reinstate.TabIndex = 0;
            this.button_Reinstate.Text = "Reinstate";
            this.button_Reinstate.UseVisualStyleBackColor = true;
            this.button_Reinstate.Click += new System.EventHandler(this.button_Reinstate_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(42, 186);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(112, 34);
            this.button_Delete.TabIndex = 1;
            this.button_Delete.Text = "Delete";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(11, 17);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(83, 25);
            this.label_name.TabIndex = 2;
            this.label_name.Text = "<Name>";
            this.label_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Department
            // 
            this.label_Department.AutoSize = true;
            this.label_Department.Location = new System.Drawing.Point(11, 54);
            this.label_Department.Name = "label_Department";
            this.label_Department.Size = new System.Drawing.Size(131, 25);
            this.label_Department.TabIndex = 3;
            this.label_Department.Text = "<Department>";
            this.label_Department.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Specialization
            // 
            this.label_Specialization.AutoSize = true;
            this.label_Specialization.Location = new System.Drawing.Point(11, 94);
            this.label_Specialization.Name = "label_Specialization";
            this.label_Specialization.Size = new System.Drawing.Size(143, 25);
            this.label_Specialization.TabIndex = 4;
            this.label_Specialization.Text = "<Specialization>";
            this.label_Specialization.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RemovedEmployeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.label_Specialization);
            this.Controls.Add(this.label_Department);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Reinstate);
            this.Name = "RemovedEmployeeControl";
            this.Size = new System.Drawing.Size(195, 236);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_Reinstate;
        private Button button_Delete;
        private Label label_name;
        private Label label_Department;
        private Label label_Specialization;
    }
}
