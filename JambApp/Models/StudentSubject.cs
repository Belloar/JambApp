using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JambApp.Models
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Grade { get; set; }
        public string ExamNumber { get; set; }

        public StudentSubject(int id, string subject, string grade, string examNumber)
        {
            Id = id;
            Subject = subject;
            Grade = grade;
            ExamNumber = examNumber;
        }
        public StudentSubject( string subject, string grade, string examNumber)
        {
            
            Subject = subject;
            Grade = grade;
            ExamNumber = examNumber;
        }
    }
}
