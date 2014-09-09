namespace Company.DataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Company.DataGenerator;
    using Company.Data;    

    public class EmployeesGenerator : DataGenerator, IDataGenerator
    {
        public EmployeesGenerator(IRandomDataGenerator randomGenerator, CompanyEntities dbContext, int countOfObjects)
            : base(randomGenerator, dbContext, countOfObjects)
        {
        }

        public override void Generate()
        {
            var departmentIds = this.Database.Departments.Select(d => d.DepartmentId).ToList();

            Console.WriteLine("Adding employees...");

            for (int i = 0; i < this.Count; i++)
            {
                var employee = new Employee
                {
                    DepartmentId = departmentIds[this.Random.GetRandomNumber(0, departmentIds.Count - 1)],
                    FirstName = this.Random.GetRandomStringRandomLength(5, 20),
                    LastName = this.Random.GetRandomStringRandomLength(5, 20),
                    YearSalary = this.Random.GetRandomNumber(50000, 200000), 
                    // on every 20 add null this is 95%
                    Manager = this.Random.GetRandomNumber(1, 20) == 20 ? null : this.Random.GetRandomStringRandomLength(5, 20)                                    
                };

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.Employees.Add(employee);
            }

            Console.WriteLine("\nEmployees added.");
        }
    }
}