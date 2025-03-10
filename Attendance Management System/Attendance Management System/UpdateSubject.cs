using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance_Management_System
{
    public partial class UpdateSubject: Form
    {
        SubjectForm form;

        public UpdateSubject(string subId, string title, string lecInCharge, SubjectForm form)
        {
            InitializeComponent();
            txtSubId.Text = subId;
            txtTitle.Text = title;
            txtLecInCharge.Text = lecInCharge;
            this.form = form;
        }

        private void updateSubjectBtnOnAction(object sender, EventArgs e)
        {
            string subId = txtSubId.Text.Trim();
            string title = txtTitle.Text.Trim();
            string lecinCharge = txtLecInCharge.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(subId) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(lecinCharge))
            {
                MessageBox.Show("Please fill in all fields!", "Update Subject", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True"))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"UPDATE subject SET title = @title, lecInCharge = @lecInCharge WHERE subId = @subId", conn);

                    cmd.Parameters.AddWithValue("@subId", subId);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@lecInCharge", lecinCharge);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Subject updated successfully!", "Update Subject", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtSubId.Clear();
                        txtTitle.Clear();
                        txtLecInCharge.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Subject not found or update failed!", "Update Subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Update Subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            form.showdata();
        }
    }
}
