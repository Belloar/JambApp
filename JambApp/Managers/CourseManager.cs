using System;
using System.Collections.Generic;
using System.Text;
using JambApp.Models;
using JambApp.Managers.Interfaces;


namespace JambApp.Managers
{
    public class CourseManager : ICourseManager

    {
        public static Dictionary<string, string> institutionCourses ;
        public static List<Course>courses = new();

        public CourseManager()
        {
            courses = new();
            {
                new Course("Electrical Electronics Engineereing)", "EEG", "5 Cs");
                new Course("Urban and regional Planning", "URP", "5 Cs");
                new Course("Architecture", "ARC", "5 Cs");
                new Course("Medicine", "MED", "5 Cs");
                new Course("Accounting", "ACC", "5 Cs");
                new Course("Law", "Law", "5 Cs");
            }
        }
        public void GetAllCourses()
        {
            foreach(var course in courses)
            {
                Console.WriteLine($"Name: {course.CourseName}, Credits required: {course.CreditsRequired}");
            }
        }
        public void InstitutionOfferdCourses()
        {          
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.CourseCode}, {course.CourseName}");
            }


        }
        public  void RegisterCourse()
        {
            Console.Write("input the course name : ");
            string courseName = Console.ReadLine();

            Console.Write("input the course code : ");
            string courseCode = Console.ReadLine();

            Console.Write("Input the credits required to study the course : ");
            string creditsRequired = Console.ReadLine();

            var Course = new Course(courseName, courseCode, creditsRequired);
                courses.Add(Course);

        }
        public void RemoveCourse(string  courseName)
        {
            foreach(Course course in courses)
            {
                if (courseName == course.CourseName)
                {
                    courses.Remove(course);
                }
                   
            }
          
        }
    }
}
