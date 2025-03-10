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

    public partial class ViewAttendance: Form
    {
        public ViewAttendance()
        {
            InitializeComponent();
            showStudents();

            viewAttendanceGridView.Columns.Add("SubId", "Subject ID");
            viewAttendanceGridView.Columns.Add("TotalHours", "Total Hours");
            viewAttendanceGridView.Columns.Add("AttendedHours", "Attended Hours");
            viewAttendanceGridView.Columns.Add("AttendancePercentage", "Attendance Percentage");
        }

        private void showStudents()
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


        private void CalculateStudentAttendance(string regNum)
        {
            // Create a list to store the attendance data
            List<AttendanceInfo> attendanceList = new List<AttendanceInfo>();

            // Use a HashSet to ensure no duplicate subjects
            HashSet<string> processedSubjects = new HashSet<string>();

            // Database connection
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // First, get all subjects the student is enrolled in
                    string query = @"SELECT subId FROM lec WHERE stuId = @stuId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@stuId", regNum);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<string> subjects = new List<string>();

                    while (reader.Read())
                    {
                        subjects.Add(reader["subId"].ToString());
                    }
                    reader.Close(); // Close reader after fetching subjects

                    // Loop through all subjects and calculate attendance for each
                    foreach (string subId in subjects)
                    {
                        // Check if the subject has already been processed
                        if (processedSubjects.Contains(subId))
                        {
                            continue; // Skip this subject if it has already been processed
                        }

                        // Mark the subject as processed
                        processedSubjects.Add(subId);

                        // Get the total lecture hours for the subject from the subject table
                        string lecHoursQuery = @"SELECT lecHours FROM subject WHERE subId = @subId";
                        SqlCommand lecCmd = new SqlCommand(lecHoursQuery, conn);
                        lecCmd.Parameters.AddWithValue("@subId", subId);
                        int totalLecHours = Convert.ToInt32(lecCmd.ExecuteScalar());

                        // Now, get the attended hours for the student in that subject
                        string attendedQuery = @"SELECT COUNT(*) FROM lec WHERE stuId = @stuId AND subId = @subId";
                        SqlCommand attendedCmd = new SqlCommand(attendedQuery, conn);
                        attendedCmd.Parameters.AddWithValue("@stuId", regNum);
                        attendedCmd.Parameters.AddWithValue("@subId", subId);

                        int attendedHours = Convert.ToInt32(attendedCmd.ExecuteScalar());

                        // Calculate the attendance percentage
                        double attendancePercentage = (double)attendedHours / totalLecHours * 100;

                        // Add the data to the attendance list
                        AttendanceInfo info = new AttendanceInfo
                        {
                            SubId = subId,
                            TotalHours = totalLecHours,
                            AttendedHours = attendedHours,
                            AttendancePercentage = attendancePercentage
                        };

                        attendanceList.Add(info);
                    }

                    // After collecting all data, show it in a new DataGridView or some other control
                    DisplayAttendanceData(attendanceList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Calculate Attendance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DisplayAttendanceData(List<AttendanceInfo> attendanceList)
        {
            // Clear any previous data
            viewAttendanceGridView.Rows.Clear();

            // Add the attendance data to the DataGridView
            foreach (var info in attendanceList)
            {
                viewAttendanceGridView.Rows.Add(info.SubId, info.TotalHours, info.AttendedHours, info.AttendancePercentage);
            }
        }

        private void selectStudent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow row = studentsGridView.Rows[e.RowIndex];

                
                string regNum = row.Cells["regNum"].Value.ToString();
                string name = row.Cells["name"].Value.ToString();
                string academicYear = row.Cells["acYear"].Value.ToString();

                lblName.Text = name;
                lblAcYear.Text = academicYear;

                CalculateStudentAttendance(regNum);
            }
        }
    }
}
