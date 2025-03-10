using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance_Management_System
{
    public partial class Home: Form
    {
        public Home()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick;
            timer.Start();
            LoadFormIntoPanel(new StudentsForm());
        }


        private Form activeForm = null;  

        private void LoadFormIntoPanel(Form form)
        {



        Console.WriteLine("Loading form: " + form.GetType().Name);

            if (activeForm != null)
            {
                Console.WriteLine("Hiding previous form: " + activeForm.GetType().Name);
                activeForm.Hide();  
            }

            activeForm = form;  
            Console.WriteLine("Assigned activeForm: " + activeForm.GetType().Name);

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(form);
            form.Show();
        }



        private void Timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void navigateToStudentForm(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new StudentsForm());
           
        }

        private void navigateToSubjectForm(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new SubjectForm());
        }

        private void navigateMarkAttendanceForm(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new MarkAttendance());
        }

        private void btnViewAttendance(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new ViewAttendance());
        }

        private void logOutBtnOnAction(object sender, EventArgs e)
        {
            this.Hide();
            new SignIn().Show();
        }
    }
}
