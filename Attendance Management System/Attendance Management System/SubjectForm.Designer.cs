namespace Attendance_Management_System
{
    partial class SubjectForm
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
            this.subjectDataGrideView = new System.Windows.Forms.DataGridView();
            this.txtSearchSubjects = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.subjectDataGrideView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subjects Details";
            // 
            // subjectDataGrideView
            // 
            this.subjectDataGrideView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectDataGrideView.Location = new System.Drawing.Point(12, 142);
            this.subjectDataGrideView.Name = "subjectDataGrideView";
            this.subjectDataGrideView.RowHeadersWidth = 51;
            this.subjectDataGrideView.RowTemplate.Height = 24;
            this.subjectDataGrideView.Size = new System.Drawing.Size(1002, 461);
            this.subjectDataGrideView.TabIndex = 1;
            // 
            // txtSearchSubjects
            // 
            this.txtSearchSubjects.Location = new System.Drawing.Point(27, 75);
            this.txtSearchSubjects.Name = "txtSearchSubjects";
            this.txtSearchSubjects.Size = new System.Drawing.Size(333, 22);
            this.txtSearchSubjects.TabIndex = 2;
            this.txtSearchSubjects.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchKeyUpAction);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(623, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.deleteBtnOnClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(811, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(176, 43);
            this.button2.TabIndex = 4;
            this.button2.Text = "Add New Subject";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.addNewSubjectBtnOnClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(428, 54);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 45);
            this.button3.TabIndex = 5;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.updateSubjectBtnOnClick);
            // 
            // SubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 603);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSearchSubjects);
            this.Controls.Add(this.subjectDataGrideView);
            this.Controls.Add(this.label1);
            this.Name = "SubjectForm";
            this.Text = "    ";
            ((System.ComponentModel.ISupportInitialize)(this.subjectDataGrideView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView subjectDataGrideView;
        private System.Windows.Forms.TextBox txtSearchSubjects;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}