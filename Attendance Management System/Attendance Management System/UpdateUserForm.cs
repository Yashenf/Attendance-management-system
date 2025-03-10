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
    public partial class UpdateUserForm : Form
    {
        private string userId;
        private UserForm userForm;

        public UpdateUserForm(string fullName, string username, string password, string userId, UserForm userForm)
        {
            InitializeComponent();

            txtName.Text = fullName;
            txtUsername.Text = username;
            txtPassword.Text = password;
            this.userId = userId;  
            this.userForm = userForm;
        }

        private void btnUpdateUserOnAction(object sender, EventArgs e)
        {
            string fullName = txtName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please fill in all fields!", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True"))
            {
                try
                {
                    conn.Open();

                   
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM users WHERE username = @username AND userId != @id", conn);
                    checkCmd.Parameters.AddWithValue("@username", username);
                    checkCmd.Parameters.AddWithValue("@id", userId); 
                    int userCount = (int)checkCmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Username already exists! Please choose a different one.", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    
                    string query = string.IsNullOrEmpty(password)
                        ? @"UPDATE users SET fullName=@fullName, username=@username WHERE userId=@id"
                        : @"UPDATE users SET fullName=@fullName, username=@username, password=@password WHERE userId=@id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", userId);  
                    cmd.Parameters.AddWithValue("@fullName", fullName);
                    cmd.Parameters.AddWithValue("@username", username);

                    if (!string.IsNullOrEmpty(password))
                    {
                        cmd.Parameters.AddWithValue("@password", password);
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User updated successfully!", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        userForm.loaddata(); 
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Please try again!", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Update User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}