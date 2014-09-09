namespace Template.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Template.Data;
    using Template.Data.Migrations;
    using Template.Models;

    public class TemplateClient
    {
        public static void Main()
        {
            // use migrations
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TemplateDbContext, Configuration>());

            var db = new TemplateDbContext();

            var student = new Student
            {
                Age = 30,
                Name = "Pesho",
                StudentStatus = StudentStatus.Online
            };

            db.Students.Add(student);
            db.SaveChanges();

            var savedStudent = db.Students.First();

            Console.WriteLine(savedStudent.Id + ": " + savedStudent.Name);
        }
    }
}