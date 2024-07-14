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
            flpAnimalExibits = new FlowLayoutPanel();
            btnReloadExhibit = new Button();
            dtpDateTime = new DateTimePicker();
            btnAddTask = new Button();
            grpBoxExhibit = new GroupBox();
            cboxFeedingTimeSlot = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            numEmployeeLimit = new NumericUpDown();
            label3 = new Label();
            grpBoxExhibit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numEmployeeLimit).BeginInit();
            SuspendLayout();
            // 
            // flpAnimalExibits
            // 
            flpAnimalExibits.AutoScroll = true;
            flpAnimalExibits.Location = new Point(6, 76);
            flpAnimalExibits.Name = "flpAnimalExibits";
            flpAnimalExibits.Size = new Size(195, 324);
            flpAnimalExibits.TabIndex = 0;
            // 
            // btnReloadExhibit
            // 
            btnReloadExhibit.Location = new Point(6, 47);
            btnReloadExhibit.Name = "btnReloadExhibit";
            btnReloadExhibit.Size = new Size(158, 23);
            btnReloadExhibit.TabIndex = 1;
            btnReloadExhibit.Text = "Reload Exhibits";
            btnReloadExhibit.UseVisualStyleBackColor = true;
            btnReloadExhibit.Click += btnReloadExhibit_Click;
            // 
            // dtpDateTime
            // 
            dtpDateTime.Location = new Point(10, 87);
            dtpDateTime.Name = "dtpDateTime";
            dtpDateTime.Size = new Size(200, 23);
            dtpDateTime.TabIndex = 2;
            dtpDateTime.ValueChanged += ValueUpdated;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(14, 414);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(196, 23);
            btnAddTask.TabIndex = 3;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // grpBoxExhibit
            // 
            grpBoxExhibit.Controls.Add(flpAnimalExibits);
            grpBoxExhibit.Controls.Add(btnReloadExhibit);
            grpBoxExhibit.Location = new Point(246, 12);
            grpBoxExhibit.Name = "grpBoxExhibit";
            grpBoxExhibit.Size = new Size(207, 413);
            grpBoxExhibit.TabIndex = 4;
            grpBoxExhibit.TabStop = false;
            grpBoxExhibit.Text = "Exhibit";
            // 
            // cboxFeedingTimeSlot
            // 
            cboxFeedingTimeSlot.FormattingEnabled = true;
            cboxFeedingTimeSlot.Location = new Point(9, 154);
            cboxFeedingTimeSlot.Name = "cboxFeedingTimeSlot";
            cboxFeedingTimeSlot.Size = new Size(201, 23);
            cboxFeedingTimeSlot.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 59);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 7;
            label1.Text = "Feeding Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 136);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 7;
            label2.Text = "Feeding Time Slot";
            // 
            // numEmployeeLimit
            // 
            numEmployeeLimit.Location = new Point(10, 212);
            numEmployeeLimit.Name = "numEmployeeLimit";
            numEmployeeLimit.Size = new Size(120, 23);
            numEmployeeLimit.TabIndex = 8;
            numEmployeeLimit.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 194);
            label3.Name = "label3";
            label3.Size = new Size(125, 15);
            label3.TabIndex = 9;
            label3.Text = "Number of Employees";
            // 
            // AddFeedingTask
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGreen;
            ClientSize = new Size(511, 450);
            Controls.Add(label3);
            Controls.Add(numEmployeeLimit);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboxFeedingTimeSlot);
            Controls.Add(grpBoxExhibit);
            Controls.Add(btnAddTask);
            Controls.Add(dtpDateTime);
            Name = "AddFeedingTask";
            Text = "Add Feeding Task";
            grpBoxExhibit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numEmployeeLimit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel flpAnimalExibits;
        private Button btnReloadExhibit;
        private DateTimePicker dtpDateTime;
        private Button btnAddTask;
        private GroupBox grpBoxExhibit;
        private ComboBox cboxFeedingTimeSlot;
        private Label label1;
        private Label label2;
        private NumericUpDown numEmployeeLimit;
        private Label label3;
    }
}