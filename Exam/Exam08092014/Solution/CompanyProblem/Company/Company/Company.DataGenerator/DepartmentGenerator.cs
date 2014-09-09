namespace Company.DataGenerator
{
    using System;
    using System.Collections.Generic;

    using Company.Data;
    using Company.DataGenerator;
   
    public class DepartmentGenerator: DataGenerator, IDataGenerator
    {
        public DepartmentGenerator(IRandomDataGenerator randomGenerator, CompanyEntities dbContext, int countOfObjects)
            : base(randomGenerator, dbContext, countOfObjects)
        {
        }

        public override void Generate()
        {
            var departmentToBeAdded = new HashSet<string>();

            Console.WriteLine("Adding departments...");
            while (departmentToBeAdded.Count != this.Count)
            {
                departmentToBeAdded.Add(this.Random.GetRandomStringRandomLength(10, 50));
            }

            int index = 0;
            foreach (var departmentName in departmentToBeAdded)
            {
                var department = new Department
                {
                    Name = departmentName                    
                };

                // important for big entries
                if (index % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.Departments.Add(department);
                index++;                
            }

            Console.WriteLine("\nDepartments added.");
        }
    }
}