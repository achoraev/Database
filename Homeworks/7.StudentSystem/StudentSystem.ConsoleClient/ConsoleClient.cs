namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using StudentSystem.Data;
    using StudentSystem.Models;
    using System.Collections.Generic;

    public class ConsoleClient
    {
        public static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student.FirstName);
            }
        }

        public static void Main()
        {
            var data = new StudentsSystemData();

            var courses = data.Courses.All();

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
            }

            data.Courses.Add(new Course
            {
                Name = "Repo Pattern",
                Description = "Cool"
            });

            data.SaveChanges();

            var students = data.Students.All();

            Console.WriteLine(students.Count());
           
        }
    }
}
