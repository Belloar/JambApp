using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JambApp.Managers.Interfaces
{
    internal interface ICourseManager
    {
        public void GetAllCourses();
        public void InstitutionOfferdCourses();
        public void RegisterCourse();
    }
}
