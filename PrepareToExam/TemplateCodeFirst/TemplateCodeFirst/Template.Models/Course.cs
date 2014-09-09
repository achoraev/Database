namespace Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        // for many to many with Students
        private ICollection<Student> students;
        private ICollection<Homework> homeworks;

        // this must for Guid works
        public Course() 
        {
            this.Id = Guid.NewGuid();
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
        }  
     
        [Required]
        public Guid Id { get; set; }

        [StringLength(50)]
        [MaxLength(100)]
        public string Name { get; set; }

        // + this for many to many with students
        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }

        // relations one to many with homeworks
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