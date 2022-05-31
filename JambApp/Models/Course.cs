using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JambApp.Models
{
    public class Course
    {
        
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string CreditsRequired { get; set; }

        public Course(string courseName, string courseCode, string creditsRequired)
        {
            CourseName = courseName;
            CourseCode = courseCode;
            CreditsRequired = creditsRequired;
        }
    }
}
