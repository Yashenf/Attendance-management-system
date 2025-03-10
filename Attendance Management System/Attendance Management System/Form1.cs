using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance_Management_System
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();

            timerLoader.Interval = 50;
            timerLoader.Tick += TimerLoader_Tick;
            timerLoader.Start();
        }

        private void TimerLoader_Tick(object sender, EventArgs e)
        {
            if (progressBarLoader.Value < 100)
            {
                progressBarLoader.Value += 1; 
            }
            else
            {
                timerLoader.Stop(); 
                this.Hide(); 
                new SignIn().Show(); 
            }
        }
    }
}
