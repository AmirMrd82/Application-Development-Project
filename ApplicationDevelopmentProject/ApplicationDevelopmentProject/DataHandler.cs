using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentProject
{
    internal static class DataHandler
    {
        public static void SaveRegistrationsToFile(List<Registration> registrations, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var reg in registrations)
                {
                    writer.WriteLine($"{reg.StudentId},{reg.CourseId}");
                }
            }
        }

        public static List<Registration> LoadRegistrationsFromFile(string filePath)
        {
            var registrations = new List<Registration>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    registrations.Add(new Registration
                    {
                        StudentId = int.Parse(parts[0]),
                        CourseId = int.Parse(parts[1])
                    });
                }
            }

            return registrations;
        }
    }
}
