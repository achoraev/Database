namespace Template.Data
{
    using System.Data.Entity;

    using Template.Models;

    public class TemplateDbContext: DbContext
    {
        public TemplateDbContext()
            : base("TemlateSystem")
        {
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }
    }
}