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
    public partial class UserForm: Form
    {

        public UserForm()
        {
            InitializeComponent();

            loaddata();
        }

        public void loaddata()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM users", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                userGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Show User's details ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnUpdateUserOnAction(object sender, EventArgs e)
        {
            if (userGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = userGridView.SelectedRows[0];
                string id = row.Cells["userId"].Value.ToString();
                string fullName = row.Cells["fullName"].Value.ToString();
                string username = row.Cells["username"].Value.ToString();
                string password = row.Cells["password"].Value.ToString(); 

                new UpdateUserForm(fullName, username, password,id, this).Show();
            }
            else
            {
                MessageBox.Show("Please select a user to update!", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnDeleteUserOnAction(object sender, EventArgs e)
        {
            if (userGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = userGridView.SelectedRows[0];
                string id = row.Cells["userId"].Value.ToString(); 

                DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True");

                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE userId=@id", conn);
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User deleted successfully!", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loaddata(); 
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete user. Try again!", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete!", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddNewUserOnAction(object sender, EventArgs e)
        {
            new AddNewUser(this).Show();
        }

        private void searchUserOnAction(object sender, KeyEventArgs e)
        {
            string searchText = txtSearchUser.Text.Trim();

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE fullName LIKE @searchText", conn);
                cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                userGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Search User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
