namespace ToysStore.DataGenerator
{
    using System;
    using System.Collections.Generic;

    using ToysStore.Data;

    internal class AgeRangeDataGenerator: DataGenerator, IDataGenerator
    {        
        public AgeRangeDataGenerator(IRandomDataGenerator randomGenerator, ToyStoreEntities1 dbContext, int countOfObjects)
            : base(randomGenerator, dbContext, countOfObjects)
        {
        }

        public override void Generate()
        {
            int count = 0;

            Console.WriteLine("Adding age ranges...");
            for (int i = 0; i < this.Count/5; i++)
            {
                for (int j = i+1; j <= i+5; j++)
                {
                    var ageRange = new AgeRanx
                    {
                        MinAge = i,
                        MaxAge = j
                    };

                    this.Database.AgeRanges.Add(ageRange);

                    count++;
                    if (count % 100 == 0)
                    {
                        Console.Write(".");
                        this.Database.SaveChanges();
                    }

                    if (count == this.Count)
                    {
                        return;
                    }                    
                }
            }

            Console.WriteLine("\nAge ranges added.");
        }
    }
}