namespace Company.DataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using Company.Data;

    public class ReportsGenerator : DataGenerator, IDataGenerator
    {
        public ReportsGenerator(IRandomDataGenerator randomGenerator, CompanyEntities dbContext, int countOfObjects)
            : base(randomGenerator, dbContext, countOfObjects)
        {
        }

        public override void Generate()
        {
            // var reportIds = this.Database.Reports.Select(r => r.ReportId).ToList();

            Console.WriteLine("Adding reports...");
            // var colectionOfReports = new ICollection<EmployeeReport>();
            DateTime StartDate = new DateTime(this.Random.GetRandomNumber(1920, 2014),this.Random.GetRandomNumber(1, 12), this.Random.GetRandomNumber(1, 31));
            DateTime EndDate = new DateTime(this.Random.GetRandomNumber(2014, 2015), this.Random.GetRandomNumber(1, 12), this.Random.GetRandomNumber(1, 31));

            for (int i = 0; i < this.Count; i++)
            {
                //var report = new Report
                //{
                //    TimeOfReport = DateTime.Now.AddHours(i),
                //    EmployeeReports = 

                //};

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                // this.Database.Reports.Add(report);
            }

            Console.WriteLine("\nReports added.");
        }
    }
}