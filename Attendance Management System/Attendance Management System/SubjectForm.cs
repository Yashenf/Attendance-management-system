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
    public partial class SubjectForm: Form
    {
        public SubjectForm()
        {
            InitializeComponent();
            showdata();
        }


        public void showdata()
        {

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM subject", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                subjectDataGrideView.DataSource = dt;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }



        }

        private void updateSubjectBtnOnClick(object sender, EventArgs e)
        {
            if (subjectDataGrideView.SelectedRows.Count == 1)
            {
                DataGridViewRow row = subjectDataGrideView.SelectedRows[0];


                string id = row.Cells["subId"].Value.ToString();
                string title = row.Cells["title"].Value.ToString();
                string lecInCharge = row.Cells["lecInCharge"].Value.ToString();
               


                UpdateSubject editForm = new UpdateSubject(id, title, lecInCharge, this);
                editForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a Subject row before updating!", "Update Subject", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteBtnOnClick(object sender, EventArgs e)
        {
            if (subjectDataGrideView.SelectedRows.Count == 1)
            {
                DataGridViewRow row = subjectDataGrideView.SelectedRows[0];
                string subId = row.Cells["subId"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete this Subject?",
                    "Delete Subject", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True"))
                    {
                        try
                        {
                            conn.Open();

                            // First, delete all related records from the lec table
                            SqlCommand deleteLecCmd = new SqlCommand("DELETE FROM lec WHERE subId = @subId", conn);
                            deleteLecCmd.Parameters.AddWithValue("@subId", subId);
                            deleteLecCmd.ExecuteNonQuery();

                            // Then, delete the subject from the subject table
                            SqlCommand deleteSubjectCmd = new SqlCommand("DELETE FROM subject WHERE subId = @subId", conn);
                            deleteSubjectCmd.Parameters.AddWithValue("@subId", subId);
                            int rowsAffected = deleteSubjectCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Subject deleted successfully!", "Delete Subject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                subjectDataGrideView.Rows.Remove(row);
                            }
                            else
                            {
                                MessageBox.Show("Error: Subject not found!", "Delete Subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Delete Subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select one subject row before deleting!", "Delete Subject", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void addNewSubjectBtnOnClick(object sender, EventArgs e)
        {
            new AddNewSubject().Show();
        }

        private void searchKeyUpAction(object sender, KeyEventArgs e)
        {
            string searchText = txtSearchSubjects.Text.Trim();

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM subject WHERE title LIKE @search OR subId LIKE @search";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    subjectDataGrideView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
