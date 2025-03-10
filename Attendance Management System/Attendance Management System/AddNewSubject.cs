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
    public partial class AddNewSubject: Form
    {
        public AddNewSubject()
        {
            InitializeComponent();
        }

        private void addNewSubjectBtnOnAction(object sender, EventArgs e)
        {

            string subId = txtSubId.Text.Trim();
            string title = txtTitle.Text.Trim();
            string lecinCharge = txtLecInCharge.Text.Trim();

      
            if (string.IsNullOrEmpty(subId) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(lecinCharge))
            {
                MessageBox.Show("Please fill in all fields!", "Add Subject", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO subject (subId, title, lecHours, lecInCharge) VALUES (@subId, @title, @lecHours, @lecInCharge)", conn);

             
                cmd.Parameters.AddWithValue("@subId", subId);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@lecHours", 0);
                cmd.Parameters.AddWithValue("@lecInCharge", lecinCharge);

               
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Subject added successfully!", "Add Subject", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtSubId.Clear();
                    txtTitle.Clear();
                    txtLecInCharge.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to add subject. Try again!", "Add Subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Add Subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
