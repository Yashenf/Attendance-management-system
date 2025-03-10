using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Attendance_Management_System
{
    public partial class AddNewStudentForm: Form
    {
        StudentsForm form;
        public AddNewStudentForm(StudentsForm form)
        {
            this.form = form;
            InitializeComponent();
        }

        private void addNewStudentBtnOnAction(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string regNum = txtRegNum.Text;
            string email = txtEmail.Text;
            DateTime dob = dpkDob.Value;  // Get Date of Birth from DateTimePicker
            string gender = null;
            string academicYear = cmbAcademicYear.Text;

            if (rdbMale.Checked)
            { 
                gender = "Male";
            }
            else if (rdbFemale.Checked)
            {
                gender = "Female";
            }
            else
            {
                MessageBox.Show("Select your gender!", "Adding New Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO student (regNum, name, email, acYear, gender, dob) 
                                          VALUES (@regNum, @name, @email, @acYear, @gender, @dob)", conn);

                cmd.Parameters.AddWithValue("@regNum", regNum);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@acYear", academicYear);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@dob", dob); 

                cmd.CommandType = CommandType.Text;

                int row = cmd.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("New Student Registered!", "Adding New Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Adding New Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
               form.showdata();
            }

            this.Close();
        }

        private void validateRegNum(object sender, CancelEventArgs e)
        {
            Regex regNumRegex = new Regex(@"^\d{4}/ICTS/\d{1,3}$");

            if (!regNumRegex.IsMatch(txtRegNum.Text))
            {
                errorProvider1.SetError(txtRegNum, "Registration Number must start with 'xxxx/ICTS/xxx'");
                return;
            }
            else {
                errorProvider1.SetError(txtRegNum,"");
            }
        }

        private void validateFullName(object sender, CancelEventArgs e)
        {
            Regex nameRegex = new Regex(@"^[a-zA-Z\s]+$");
            if (string.IsNullOrWhiteSpace(txtName.Text) || !nameRegex.IsMatch(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Name must contain only letters and spaces.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtName, "");
            }
        }

        private void validateEmail(object sender, EventArgs e)
        {
            Regex emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            if (!emailRegex.IsMatch(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Invalid email format.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }
    }
}
