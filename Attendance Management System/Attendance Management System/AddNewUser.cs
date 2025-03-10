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
    public partial class AddNewUser: Form
    {
        UserForm userForm;
        public AddNewUser(UserForm userForm)
        {
            InitializeComponent();
            this.userForm = userForm;
        }

        private void btnSubmitOnAction(object sender, EventArgs e)
        {
            string fullname = txtName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True"))
            {
                try
                {
                    conn.Open();

                 
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM users WHERE username = @username", conn);
                    checkCmd.Parameters.AddWithValue("@username", username);
                    int userCount = (int)checkCmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Username already exists! Please choose a different one.", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO users (fullName, username, password) VALUES (@fullName, @username, @password)", conn);
                    cmd.Parameters.AddWithValue("@fullName", fullname);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User added successfully!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtName.Clear();
                        txtUsername.Clear();
                        txtPassword.Clear();

                        userForm.loaddata(); 
                    }
                    else
                    {
                        MessageBox.Show("Failed to add User. Try again!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}

