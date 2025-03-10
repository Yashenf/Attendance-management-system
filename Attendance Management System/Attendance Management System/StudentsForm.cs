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
    public partial class StudentsForm: Form
    {
        public StudentsForm()
        {
            InitializeComponent();
            showdata();
        }

        private void addNewStudentBtnOnAction(object sender, EventArgs e)
        {
            new AddNewStudentForm(this).Show();
           
        }

        private void searchBoxKeyUpOnAction(object sender, KeyEventArgs e)
        {
            string searchText = txtSearch.Text.Trim(); 

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM student WHERE regNum LIKE @search OR name LIKE @search";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewStudents.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void showdata()
        {

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT regNum, name, email, acYear, gender, dob,
                        DATEDIFF(YEAR, dob, GETDATE()) AS age FROM student", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridViewStudents.DataSource = dt; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Show Students's details ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }



        }

        private void deleteStudentBtnOnAction(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count == 1) 
            {
                DataGridViewRow row = dataGridViewStudents.SelectedRows[0]; 
                string regNum = row.Cells["regNum"].Value.ToString(); 

                DialogResult result = MessageBox.Show("Are you sure you want to delete this student?",
                    "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True"))
                    {
                        try
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("DELETE FROM student WHERE regNum = @regNum", conn);
                            cmd.Parameters.AddWithValue("@regNum", regNum);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Student deleted successfully!", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                
                                dataGridViewStudents.Rows.Remove(row);
                            }
                            else
                            {
                                MessageBox.Show("Error: Student not found!", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select one student row before deleting!", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateStudentBtnOnAction(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count == 1) 
            {
                DataGridViewRow row = dataGridViewStudents.SelectedRows[0]; 


                string regNum = row.Cells["regNum"].Value.ToString();
                string name = row.Cells["name"].Value.ToString();
                string email = row.Cells["email"].Value.ToString();
                string academicYear = row.Cells["acYear"].Value.ToString();
                string gender = row.Cells["gender"].Value.ToString();
                DateTime dob = Convert.ToDateTime(row.Cells["dob"].Value);
                int age = Convert.ToInt32(row.Cells["age"].Value);

     
                UpdateStudentForm editForm = new UpdateStudentForm(regNum, name, email, academicYear, gender, dob, age,this);
                editForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a student row before updating!", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            showdata();
        }

        //private void selectRowOnAction(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridViewRow row = dataGridViewStudents.Rows[e.RowIndex];

        //    // Get values from the selected row
        //    string regNum = row.Cells["regNum"].Value.ToString();
        //    string name = row.Cells["name"].Value.ToString();
        //    string email = row.Cells["email"].Value.ToString();
        //    string academicYear = row.Cells["acYear"].Value.ToString();
        //    string gender = row.Cells["gender"].Value.ToString();
        //    DateTime dob = Convert.ToDateTime(row.Cells["dob"].Value);
        //    int age = Convert.ToInt32(row.Cells["age"].Value);

        //    UpdateStudentForm editForm = new UpdateStudentForm(regNum, name, email, academicYear, gender, dob, age);
        //    editForm.Show();
        //}
    }
}
