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
    public partial class UpdateStudentForm: Form
    {

        StudentsForm form;
        public UpdateStudentForm(string regNum, string name, string email, string academicYear, string gender, DateTime dob, int age,StudentsForm form)
        {
            InitializeComponent();
            txtRegNum.Text = regNum;
            txtName.Text = name;
            txtEmail.Text = email;
            cmbAcademicYear.Text = academicYear;
            if (gender == "Male") rdbMale.Checked = true;
            else if (gender == "Female") rdbFemale.Checked = true;
            dpkDob.Value = dob;
            this.form = form;
            
        }

        private void updateStudentBtnOnAction(object sender, EventArgs e)
        {
            string regNum = txtRegNum.Text;
            string name = txtName.Text;
            string email = txtEmail.Text;
            string academicYear = cmbAcademicYear.Text;
            DateTime dob = dpkDob.Value;
            string gender = rdbMale.Checked ? "Male" : "Female";

            // Calculate Age
            int age = DateTime.Now.Year - dob.Year;

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE student SET name=@name, email=@email, acYear=@academicYear, gender=@gender, dob=@dob WHERE regNum=@regNum", conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@regNum", regNum);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@academicYear", academicYear);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@dob", dob);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Student details updated successfully!", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update failed. Please try again!", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                form.showdata();
            }
        }
    }
}
