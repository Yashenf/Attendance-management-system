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
    public partial class MarkAttendance: Form
    {
        List<string> regNumList = new List<string>();
        public MarkAttendance()
        {
            InitializeComponent();
            btnAddAttendance.Enabled = false;
            loadSubjects();
            loadStudents();
            cmbLecHours.Text = "1";
            attendedStudentsView.AutoGenerateColumns = true;
        }

        private void loadSubjects()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT subId FROM subject", conn); // Query to get subject titles
                    SqlDataReader reader = cmd.ExecuteReader();

                    cmbSubject.Items.Clear(); // Clear existing items before adding new ones

                    while (reader.Read())
                    {
                        cmbSubject.Items.Add(reader["subId"].ToString()); // Add each title to ComboBox
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading subjects: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void loadStudents()
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
                studentsGridView.DataSource = dt;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void createSessionBtnOnAction(object sender, EventArgs e)
        {
            
            string subId = cmbSubject.Text.Trim();
            string newLecHoursStr = cmbLecHours.Text.Trim();

           
            if (string.IsNullOrEmpty(subId))
            {
                MessageBox.Show("Please select a Subject ID!", "Update Subject", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(newLecHoursStr) || !int.TryParse(newLecHoursStr, out int newLecHours) || newLecHours <= 0)
            {
                MessageBox.Show("Please enter a valid number of lecture hours!", "Update Subject", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                   
                    string selectQuery = "SELECT lecHours FROM subject WHERE subId = @subId";
                    int previousLecHours = 0;

                    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@subId", subId);
                        object result = selectCmd.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int tempLecHours))
                        {
                            previousLecHours = tempLecHours;
                        }
                    }

                    
                    int updatedLecHours = previousLecHours + newLecHours;

                    
                    string updateQuery = "UPDATE subject SET lecHours = @updatedLecHours WHERE subId = @subId";

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@subId", subId);
                        updateCmd.Parameters.AddWithValue("@updatedLecHours", updatedLecHours);

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Lecture hours updated successfully!", "Update Subject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnAddAttendance.Enabled = true; 
                        }
                        else
                        {
                            MessageBox.Show("Subject ID not found!", "Update Subject", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Update Subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void markAttendanceBtnOnAction(object sender, EventArgs e)
        {
  
            if (regNumList.Count == 0)
            {
                MessageBox.Show("No students selected!", "Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string subId = cmbSubject.Text.Trim();
            string lecHours = cmbLecHours.Text.Trim();

            if (string.IsNullOrEmpty(subId) || string.IsNullOrEmpty(lecHours))
            {
                MessageBox.Show("Please select a subject and lecture hours!", "Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True";

           
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();


                    string query = "INSERT INTO lec (stuId, subId, lecHours) VALUES (@stuId, @subId, @lecHours)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        foreach (string stuId in regNumList)
                        {
                            
                            cmd.Parameters.Clear();  
                            cmd.Parameters.AddWithValue("@stuId", stuId);
                            cmd.Parameters.AddWithValue("@subId", subId);
                            cmd.Parameters.AddWithValue("@lecHours", lecHours);

                           
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Data inserted successfully into lecs table!", "Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                
                    MessageBox.Show("Error: " + ex.Message, "Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void removeBtnOnAction(object sender, EventArgs e)
        {

        }

        private void dataGridViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {

           
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = studentsGridView.Rows[e.RowIndex];

                string regNum = selectedRow.Cells["regNum"].Value.ToString();

                regNumList.Add(regNum);

               
                attendedStudentsView.DataSource = null;  

               
                DataTable dt = new DataTable();
                dt.Columns.Add("regNum"); 

                foreach (var item in regNumList)
                {
                    dt.Rows.Add(item);  
                }

              
                attendedStudentsView.DataSource = dt;
            }
        }
    }
}
