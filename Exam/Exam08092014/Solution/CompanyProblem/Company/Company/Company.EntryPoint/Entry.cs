namespace Company.EntryPoint
{
    using System.Collections.Generic;

    using Company.Data;
    using Company.DataGenerator;

    public class Entry
    {
        public static void Main()
        {
            var random = RandomGenerator.Instance;               
            var db = new CompanyEntities();
            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>
            {
                // new DepartmentGenerator(random, db, 100),
                // new EmployeesGenerator(random, db, 5000),
                // new ProjectsGenerator(random, db, 1000),
                // new ReportsGenerator(random, db, 250000)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }

            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}