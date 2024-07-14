namespace zooproject
{
    partial class AddFeedingTask
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
            this.flpAnimals = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAnimalExibits = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReloadAnimal = new System.Windows.Forms.Button();
            this.btnReloadExhibit = new System.Windows.Forms.Button();
            this.dtpDateTime = new System.Windows.Forms.DateTimePicker();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flpAnimals
            // 
            this.flpAnimals.Location = new System.Drawing.Point(271, 114);
            this.flpAnimals.Name = "flpAnimals";
            this.flpAnimals.Size = new System.Drawing.Size(149, 324);
            this.flpAnimals.TabIndex = 0;
            // 
            // flpAnimalExibits
            // 
            this.flpAnimalExibits.Location = new System.Drawing.Point(499, 114);
            this.flpAnimalExibits.Name = "flpAnimalExibits";
            this.flpAnimalExibits.Size = new System.Drawing.Size(158, 324);
            this.flpAnimalExibits.TabIndex = 0;
            // 
            // btnReloadAnimal
            // 
            this.btnReloadAnimal.Location = new System.Drawing.Point(271, 85);
            this.btnReloadAnimal.Name = "btnReloadAnimal";
            this.btnReloadAnimal.Size = new System.Drawing.Size(149, 23);
            this.btnReloadAnimal.TabIndex = 1;
            this.btnReloadAnimal.Text = "Reload Animals";
            this.btnReloadAnimal.UseVisualStyleBackColor = true;
            this.btnReloadAnimal.Click += new System.EventHandler(this.btnReloadAnimal_Click);
            // 
            // btnReloadExhibit
            // 
            this.btnReloadExhibit.Location = new System.Drawing.Point(499, 85);
            this.btnReloadExhibit.Name = "btnReloadExhibit";
            this.btnReloadExhibit.Size = new System.Drawing.Size(158, 23);
            this.btnReloadExhibit.TabIndex = 1;
            this.btnReloadExhibit.Text = "Reload Exhibits";
            this.btnReloadExhibit.UseVisualStyleBackColor = true;
            this.btnReloadExhibit.Click += new System.EventHandler(this.btnReloadExhibit_Click);
            // 
            // dtpDateTime
            // 
            this.dtpDateTime.Location = new System.Drawing.Point(10, 87);
            this.dtpDateTime.Name = "dtpDateTime";
            this.dtpDateTime.Size = new System.Drawing.Size(200, 23);
            this.dtpDateTime.TabIndex = 2;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(14, 414);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(196, 23);
            this.btnAddTask.TabIndex = 3;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(499, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "WARNING! Don\'t add a Animal is it will currenly cause an Error. Add a task with j" +
    "ust an Exhibit";
            // 
            // AddFeedingTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.dtpDateTime);
            this.Controls.Add(this.btnReloadExhibit);
            this.Controls.Add(this.btnReloadAnimal);
            this.Controls.Add(this.flpAnimalExibits);
            this.Controls.Add(this.flpAnimals);
            this.Name = "AddFeedingTask";
            this.Text = "AddFeedingTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flpAnimals;
        private FlowLayoutPanel flpAnimalExibits;
        private Button btnReloadAnimal;
        private Button btnReloadExhibit;
        private DateTimePicker dtpDateTime;
        private Button btnAddTask;
        private Label label1;
    }
}