namespace Company.DataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;    

    public class ProjectsGenerator: DataGenerator, IDataGenerator
    {
        public ProjectsGenerator(IRandomDataGenerator randomGenerator, CompanyEntities dbContext, int countOfObjects)
            : base(randomGenerator, dbContext, countOfObjects)
        {
        }

        public override void Generate()
        {
            var employeeIds = this.Database.Employees.Select(e => e.EmployeeId).ToList();
            // var projectIds = this.Database.Projects.Select(p => p.ProjectId).ToList();

            Console.WriteLine("Adding projects...");
            List<int> employeeForProjects = new List<int>();

            for (int i = 0; i < this.Count; i++)
            {
                int countEmployees = this.Random.GetRandomNumber(2, 20);
                for (int j = 0; j < countEmployees; j++)
                {
                    employeeForProjects.Add(employeeIds[this.Random.GetRandomNumber(0, employeeIds.Count - 1)]);
                }                
                
                var project = new Project
                {
                    Name = this.Random.GetRandomStringRandomLength(5, 50),                    
                    EmployeeId = employeeIds[this.Random.GetRandomNumber(2, employeeIds.Count - 1)],                    
                    // ProjectId = projectIds[this.Random.GetRandomNumber(0, projectIds.Count-1)]                   
                };

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.Projects.Add(project);
            }

            Console.WriteLine("\nProjects added.");
        }
    }
}