namespace zooproject
{
    partial class EmployeeFilter
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
            this.cbx_JobType = new System.Windows.Forms.ComboBox();
            this.cbx_Rank = new System.Windows.Forms.ComboBox();
            this.cbx_Contract = new System.Windows.Forms.ComboBox();
            this.btn_ApplyEmployeeFilter = new System.Windows.Forms.Button();
            this.select_job = new System.Windows.Forms.Label();
            this.select_rank = new System.Windows.Forms.Label();
            this.select_contract = new System.Windows.Forms.Label();
            this.checkBox_Rank = new System.Windows.Forms.CheckBox();
            this.checkBox_Job = new System.Windows.Forms.CheckBox();
            this.checkBox_Contract = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_ActiveDate = new System.Windows.Forms.DateTimePicker();
            this.ActiveDate = new System.Windows.Forms.Label();
            this.checkBox_Active = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbx_JobType
            // 
            this.cbx_JobType.FormattingEnabled = true;
            this.cbx_JobType.Location = new System.Drawing.Point(151, 23);
            this.cbx_JobType.Name = "cbx_JobType";
            this.cbx_JobType.Size = new System.Drawing.Size(182, 33);
            this.cbx_JobType.TabIndex = 0;
            // 
            // cbx_Rank
            // 
            this.cbx_Rank.FormattingEnabled = true;
            this.cbx_Rank.Location = new System.Drawing.Point(151, 80);
            this.cbx_Rank.Name = "cbx_Rank";
            this.cbx_Rank.Size = new System.Drawing.Size(182, 33);
            this.cbx_Rank.TabIndex = 1;
            // 
            // cbx_Contract
            // 
            this.cbx_Contract.FormattingEnabled = true;
            this.cbx_Contract.Location = new System.Drawing.Point(151, 139);
            this.cbx_Contract.Name = "cbx_Contract";
            this.cbx_Contract.Size = new System.Drawing.Size(182, 33);
            this.cbx_Contract.TabIndex = 2;
            // 
            // btn_ApplyEmployeeFilter
            // 
            this.btn_ApplyEmployeeFilter.Location = new System.Drawing.Point(151, 243);
            this.btn_ApplyEmployeeFilter.Name = "btn_ApplyEmployeeFilter";
            this.btn_ApplyEmployeeFilter.Size = new System.Drawing.Size(182, 34);
            this.btn_ApplyEmployeeFilter.TabIndex = 3;
            this.btn_ApplyEmployeeFilter.Text = "Apply Filter";
            this.btn_ApplyEmployeeFilter.UseVisualStyleBackColor = true;
            this.btn_ApplyEmployeeFilter.Click += new System.EventHandler(this.btn_ApplyEmployeeFilter_Click);
            // 
            // select_job
            // 
            this.select_job.AutoSize = true;
            this.select_job.Location = new System.Drawing.Point(351, 26);
            this.select_job.Name = "select_job";
            this.select_job.Size = new System.Drawing.Size(78, 25);
            this.select_job.TabIndex = 4;
            this.select_job.Text = "Selected";
            // 
            // select_rank
            // 
            this.select_rank.AutoSize = true;
            this.select_rank.Location = new System.Drawing.Point(351, 83);
            this.select_rank.Name = "select_rank";
            this.select_rank.Size = new System.Drawing.Size(78, 25);
            this.select_rank.TabIndex = 5;
            this.select_rank.Text = "Selected";
            // 
            // select_contract
            // 
            this.select_contract.AutoSize = true;
            this.select_contract.Location = new System.Drawing.Point(351, 142);
            this.select_contract.Name = "select_contract";
            this.select_contract.Size = new System.Drawing.Size(78, 25);
            this.select_contract.TabIndex = 6;
            this.select_contract.Text = "Selected";
            // 
            // checkBox_Rank
            // 
            this.checkBox_Rank.AutoSize = true;
            this.checkBox_Rank.Location = new System.Drawing.Point(123, 83);
            this.checkBox_Rank.Name = "checkBox_Rank";
            this.checkBox_Rank.Size = new System.Drawing.Size(22, 21);
            this.checkBox_Rank.TabIndex = 7;
            this.checkBox_Rank.UseVisualStyleBackColor = true;
            this.checkBox_Rank.CheckedChanged += new System.EventHandler(this.checkBox_Rank_CheckedChanged);
            // 
            // checkBox_Job
            // 
            this.checkBox_Job.AutoSize = true;
            this.checkBox_Job.Location = new System.Drawing.Point(123, 26);
            this.checkBox_Job.Name = "checkBox_Job";
            this.checkBox_Job.Size = new System.Drawing.Size(22, 21);
            this.checkBox_Job.TabIndex = 8;
            this.checkBox_Job.UseVisualStyleBackColor = true;
            this.checkBox_Job.CheckedChanged += new System.EventHandler(this.checkBox_Job_CheckedChanged);
            // 
            // checkBox_Contract
            // 
            this.checkBox_Contract.AutoSize = true;
            this.checkBox_Contract.Location = new System.Drawing.Point(123, 142);
            this.checkBox_Contract.Name = "checkBox_Contract";
            this.checkBox_Contract.Size = new System.Drawing.Size(22, 21);
            this.checkBox_Contract.TabIndex = 9;
            this.checkBox_Contract.UseVisualStyleBackColor = true;
            this.checkBox_Contract.CheckedChanged += new System.EventHandler(this.checkBox_Contract_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Job Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Rank";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 50);
            this.label2.TabIndex = 12;
            this.label2.Text = "Work\r\nContract";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Active";
            // 
            // dtp_ActiveDate
            // 
            this.dtp_ActiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ActiveDate.Location = new System.Drawing.Point(151, 195);
            this.dtp_ActiveDate.Name = "dtp_ActiveDate";
            this.dtp_ActiveDate.Size = new System.Drawing.Size(182, 31);
            this.dtp_ActiveDate.TabIndex = 14;
            // 
            // ActiveDate
            // 
            this.ActiveDate.AutoSize = true;
            this.ActiveDate.Location = new System.Drawing.Point(351, 198);
            this.ActiveDate.Name = "ActiveDate";
            this.ActiveDate.Size = new System.Drawing.Size(78, 25);
            this.ActiveDate.TabIndex = 15;
            this.ActiveDate.Text = "Selected";
            // 
            // checkBox_Active
            // 
            this.checkBox_Active.AutoSize = true;
            this.checkBox_Active.Location = new System.Drawing.Point(123, 198);
            this.checkBox_Active.Name = "checkBox_Active";
            this.checkBox_Active.Size = new System.Drawing.Size(22, 21);
            this.checkBox_Active.TabIndex = 16;
            this.checkBox_Active.UseVisualStyleBackColor = true;
            this.checkBox_Active.CheckedChanged += new System.EventHandler(this.checkBox_Active_CheckedChanged);
            // 
            // EmployeeFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(453, 292);
            this.Controls.Add(this.checkBox_Active);
            this.Controls.Add(this.ActiveDate);
            this.Controls.Add(this.dtp_ActiveDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox_Contract);
            this.Controls.Add(this.checkBox_Job);
            this.Controls.Add(this.checkBox_Rank);
            this.Controls.Add(this.select_contract);
            this.Controls.Add(this.select_rank);
            this.Controls.Add(this.select_job);
            this.Controls.Add(this.btn_ApplyEmployeeFilter);
            this.Controls.Add(this.cbx_Contract);
            this.Controls.Add(this.cbx_Rank);
            this.Controls.Add(this.cbx_JobType);
            this.Name = "EmployeeFilter";
            this.Text = "EmployeeFilter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeFilter_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbx_JobType;
        private ComboBox cbx_Rank;
        private ComboBox cbx_Contract;
        private Button btn_ApplyEmployeeFilter;
        private Label select_job;
        private Label select_rank;
        private Label select_contract;
        private CheckBox checkBox_Rank;
        private CheckBox checkBox_Job;
        private CheckBox checkBox_Contract;
        private Label label4;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dtp_ActiveDate;
        private Label ActiveDate;
        private CheckBox checkBox_Active;
    }
}