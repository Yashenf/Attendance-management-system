namespace Attendance_Management_System
{
    partial class MarkAttendance
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.cmbLecHours = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.attendedStudentsView = new System.Windows.Forms.DataGridView();
            this.btnAddAttendance = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.studentsGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.attendedStudentsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Session";
            // 
            // cmbSubject
            // 
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(297, 20);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(165, 24);
            this.cmbSubject.TabIndex = 1;
            // 
            // cmbLecHours
            // 
            this.cmbLecHours.FormattingEnabled = true;
            this.cmbLecHours.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbLecHours.Location = new System.Drawing.Point(610, 23);
            this.cmbLecHours.Name = "cmbLecHours";
            this.cmbLecHours.Size = new System.Drawing.Size(163, 24);
            this.cmbLecHours.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(845, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create Session";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.createSessionBtnOnAction);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Subject";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(536, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lec Hours";
            // 
            // attendedStudentsView
            // 
            this.attendedStudentsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attendedStudentsView.Location = new System.Drawing.Point(683, 140);
            this.attendedStudentsView.Name = "attendedStudentsView";
            this.attendedStudentsView.RowHeadersWidth = 51;
            this.attendedStudentsView.RowTemplate.Height = 24;
            this.attendedStudentsView.Size = new System.Drawing.Size(318, 409);
            this.attendedStudentsView.TabIndex = 6;
            // 
            // btnAddAttendance
            // 
            this.btnAddAttendance.Location = new System.Drawing.Point(845, 560);
            this.btnAddAttendance.Name = "btnAddAttendance";
            this.btnAddAttendance.Size = new System.Drawing.Size(156, 36);
            this.btnAddAttendance.TabIndex = 7;
            this.btnAddAttendance.Text = "Mark Attendance";
            this.btnAddAttendance.UseVisualStyleBackColor = true;
            this.btnAddAttendance.Click += new System.EventHandler(this.markAttendanceBtnOnAction);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(683, 560);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(156, 36);
            this.btn1.TabIndex = 8;
            this.btn1.Text = "Remove";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.removeBtnOnAction);
            // 
            // studentsGridView
            // 
            this.studentsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentsGridView.Location = new System.Drawing.Point(12, 140);
            this.studentsGridView.Name = "studentsGridView";
            this.studentsGridView.RowHeadersWidth = 51;
            this.studentsGridView.RowTemplate.Height = 24;
            this.studentsGridView.Size = new System.Drawing.Size(640, 409);
            this.studentsGridView.TabIndex = 9;
            this.studentsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudents_CellClick);
            // 
            // MarkAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 603);
            this.Controls.Add(this.studentsGridView);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btnAddAttendance);
            this.Controls.Add(this.attendedStudentsView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbLecHours);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.label1);
            this.Name = "MarkAttendance";
            this.Text = "MarkAttendance";
            ((System.ComponentModel.ISupportInitialize)(this.attendedStudentsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.ComboBox cmbLecHours;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView attendedStudentsView;
        private System.Windows.Forms.Button btnAddAttendance;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.DataGridView studentsGridView;
    }
}