namespace Attendance_Management_System
{
    partial class ViewAttendance
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
            this.studentsGridView = new System.Windows.Forms.DataGridView();
            this.txtSearchStudents = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAcYear = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.viewAttendanceGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.studentsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewAttendanceGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // studentsGridView
            // 
            this.studentsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentsGridView.Location = new System.Drawing.Point(12, 73);
            this.studentsGridView.Name = "studentsGridView";
            this.studentsGridView.RowHeadersWidth = 51;
            this.studentsGridView.RowTemplate.Height = 24;
            this.studentsGridView.Size = new System.Drawing.Size(431, 518);
            this.studentsGridView.TabIndex = 0;
            this.studentsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.selectStudent);
            // 
            // txtSearchStudents
            // 
            this.txtSearchStudents.Location = new System.Drawing.Point(13, 24);
            this.txtSearchStudents.Name = "txtSearchStudents";
            this.txtSearchStudents.Size = new System.Drawing.Size(430, 22);
            this.txtSearchStudents.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(730, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "View Attendance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(514, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(605, 112);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 16);
            this.lblName.TabIndex = 4;
            // 
            // lblAcYear
            // 
            this.lblAcYear.AutoSize = true;
            this.lblAcYear.Location = new System.Drawing.Point(905, 112);
            this.lblAcYear.Name = "lblAcYear";
            this.lblAcYear.Size = new System.Drawing.Size(0, 16);
            this.lblAcYear.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(801, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Academic year";
            // 
            // viewAttendanceGridView
            // 
            this.viewAttendanceGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewAttendanceGridView.Location = new System.Drawing.Point(469, 159);
            this.viewAttendanceGridView.Name = "viewAttendanceGridView";
            this.viewAttendanceGridView.RowHeadersWidth = 51;
            this.viewAttendanceGridView.RowTemplate.Height = 24;
            this.viewAttendanceGridView.Size = new System.Drawing.Size(532, 432);
            this.viewAttendanceGridView.TabIndex = 7;
            // 
            // ViewAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 603);
            this.Controls.Add(this.viewAttendanceGridView);
            this.Controls.Add(this.lblAcYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchStudents);
            this.Controls.Add(this.studentsGridView);
            this.Name = "ViewAttendance";
            this.Text = "ViewAttendance";
            ((System.ComponentModel.ISupportInitialize)(this.studentsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewAttendanceGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView studentsGridView;
        private System.Windows.Forms.TextBox txtSearchStudents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAcYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView viewAttendanceGridView;
    }
}