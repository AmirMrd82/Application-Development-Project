using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationDevelopmentProject
{
    public partial class Form1 : Form
    {
        private List<Student> students;
        private List<Course> courses;
        private List<Registration> registrations;

        public Form1()
        {
            InitializeComponent();

           
            students = new List<Student>
        {
            new Student { Id = 1, Name = "John Doe", Email = "john@example.com", Password = "1234" },
            new Student { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Password = "5678" }
        };

            courses = new List<Course>
        {
            new Course { Id = 1, Name = "Math 101", Description = "Basic Math", Prerequisites = new List<int>() },
            new Course { Id = 2, Name = "Physics 101", Description = "Basic Physics", Prerequisites = new List<int> { 1 } }
        };

            registrations = new List<Registration>();

            
            foreach (var course in courses)
            {
                listBoxCourses.Items.Add(course.Name);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var selectedCourse = courses[listBoxCourses.SelectedIndex];
            var currentStudent = students[0]; 

            if (RegistrationLogic.CanRegister(currentStudent, selectedCourse, registrations))
            {
                registrations.Add(new Registration
                {
                    StudentId = currentStudent.Id,
                    CourseId = selectedCourse.Id
                });

                MessageBox.Show("Registration successful!");
            }
            else
            {
                MessageBox.Show("You do not meet the prerequisites or are already registered.");
            }
        }

    }
}
