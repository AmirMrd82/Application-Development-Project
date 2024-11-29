using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentProject
{
    internal class RegistrationLogic
    {
        public static bool CanRegister(Student student, Course course, List<Registration> registrations)
        {
            if (registrations.Any(r => r.StudentId == student.Id && r.CourseId == course.Id))
                return false;

            foreach (var prereqId in course.Prerequisites)
            {
                if (!registrations.Any(r => r.StudentId == student.Id && r.CourseId == prereqId))
                    return false;
            }

            return true;
        }
    }
}
