namespace ToysStore.DataGenerator
{
    using System;
    using System.Collections.Generic;
    using ToysStore.Data;

    internal class ManufacturerGenerator : DataGenerator, IDataGenerator
    {
        public ManufacturerGenerator(IRandomDataGenerator randomGenerator, ToyStoreEntities1 dbContext, int countOfObjects)
            : base(randomGenerator, dbContext, countOfObjects)
        {
        }

        public override void Generate()
        {
            var manufacturerToBeAdded = new HashSet<string>();

            Console.WriteLine("Adding manufactory...");
            while (manufacturerToBeAdded.Count != this.Count)
            {
                manufacturerToBeAdded.Add(this.Random.GetRandomStringRandomLength(5, 20));
            }

            int index = 0;
            foreach (var manufacturName in manufacturerToBeAdded)
            {
                var manufacturer = new Manufactory
                {
                    Name = manufacturName,
                    Country = this.Random.GetRandomStringRandomLength(3, 100)
                };

                // important for big entries
                if (index % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.Manufactories.Add(manufacturer);
                index++;                
            }

            Console.WriteLine("\nManufactory added.");
        }
    }
}