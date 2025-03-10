using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Attendance_Management_System
{
    public partial class AddNewSubject : Form
    {
        
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\uov\academic\level 2 semester 1\ACP Group Project\Attendance Management System\Attendance Management System\UniversityDB.mdf"";Integrated Security=True";

        public AddNewSubject()
        {
            InitializeComponent();
        }

        private void addNewSubjectBtnOnAction(object sender, EventArgs e)
        {
  
            string subId = txtSubId.Text.Trim();
            string title = txtTitle.Text.Trim();
            string lecinCharge = txtLecInCharge.Text.Trim();


            errorProvider1.Clear();

            if (string.IsNullOrEmpty(subId) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(lecinCharge))
            {
                MessageBox.Show("Please fill in all fields!", "Add Subject", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


         
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                   
                    string query = @"INSERT INTO subject (subId, title, lecHours, lecInCharge) 
                                     VALUES (@subId, @title, @lecHours, @lecInCharge)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@subId", subId);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@lecHours", 0); 
                        cmd.Parameters.AddWithValue("@lecInCharge", lecinCharge);

                        
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Subject added successfully!", "Add Subject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields(); 
                        }
                        else
                        {
                            MessageBox.Show("Failed to add subject. Try again!", "Add Subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Add Subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void ClearFields()
        {
            txtSubId.Clear();
            txtTitle.Clear();
            txtLecInCharge.Clear();
        }

        private void checkregex(object sender, EventArgs e)
        {
            
        }

        private void validateSubjectId(object sender, EventArgs e)
        {
            string subId = txtSubId.Text.Trim();
            Regex subIdRegex = new Regex(@"^TICT\d{4}$");

            if (!subIdRegex.IsMatch(subId))
            {
                errorProvider1.SetError(txtSubId, "Enter Like TICT xxxx");
                return;
            }
            else
            {
                errorProvider1.SetError(txtSubId, "");
            }
        }

        private void validateTitle(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            Regex lecInChargeRegex = new Regex(@"^[a-zA-Z\s]+$");
            if (!lecInChargeRegex.IsMatch(title))
            {
                errorProvider1.SetError(txtLecInCharge, "Lecturer In Charge must contain only letters and spaces.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtLecInCharge, "");
            }
        }

        private void lecInChargeValidate(object sender, EventArgs e)
        {
            string lecinCharge = txtLecInCharge.Text.Trim();

            Regex lecInChargeRegex = new Regex(@"^[a-zA-Z\s]+$");
            if (!lecInChargeRegex.IsMatch(lecinCharge))
            {
                errorProvider1.SetError(txtLecInCharge, "Lecturer In Charge must contain only letters and spaces.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtLecInCharge, "");
            }
        }
    }
}
