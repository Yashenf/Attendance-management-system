using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_Management_System
{
    public class AttendanceInfo
    {
        public string SubId { get; set; }
        public int TotalHours { get; set; }
        public int AttendedHours { get; set; }
        public double AttendancePercentage { get; set; }
    }
}
