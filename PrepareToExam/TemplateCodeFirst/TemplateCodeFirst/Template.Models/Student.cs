namespace Template.Models
{
    using System.Collections.Generic;

    public class Student
    {
        // + constructor for many to many
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        // enumeration
        public StudentStatus StudentStatus { get; set; }

        // relations many to many
        public virtual ICollection<Course> Courses 
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }
            set
            {
                this.homeworks = value;
            }
        }
    }
}