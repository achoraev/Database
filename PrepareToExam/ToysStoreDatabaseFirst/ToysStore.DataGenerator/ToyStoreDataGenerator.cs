namespace ToysStore.DataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ToysStore.Data;

    internal class ToyStoreDataGenerator : DataGenerator, IDataGenerator
    {
        public ToyStoreDataGenerator(IRandomDataGenerator randomGenerator, ToyStoreEntities1 dbContext, int countOfObjects)
            : base(randomGenerator, dbContext, countOfObjects)
        {
        }
        public override void Generate()
        {
            var ageRangesIds = this.Database.AgeRanges.Select(a => a.ID).ToList();
            var manufacturerIds = this.Database.Manufactories.Select(m => m.ID).ToList();
            var categoriesIds = this.Database.Categories.Select(c => c.ID).ToList();

            Console.WriteLine("Adding toys....");
            for (int i = 1; i < this.Count; i++)
            {
                var toy = new Toy
                {
                    Name = this.Random.GetRandomStringRandomLength(5, 20),
                    Type = this.Random.GetRandomStringRandomLength(5, 20),
                    Price = this.Random.GetRandomNumber(10, 500),
                    Color = this.Random.GetRandomNumber(1, 5) == 5 ? null : this.Random.GetRandomStringRandomLength(5, 20),
                    ManufactureID = manufacturerIds[this.Random.GetRandomNumber(0, manufacturerIds.Count - 1)],
                    AgeRangeId = ageRangesIds[this.Random.GetRandomNumber(0, ageRangesIds.Count - 1)]
                };

                if (categoriesIds.Count > 0)
                {
                    var unigueCategoryIds = new HashSet<int>();

                    var categoriesInToy = this.Random.GetRandomNumber(1, Math.Min(10, categoriesIds.Count));

                    while (unigueCategoryIds.Count != categoriesInToy)
                    {
                        unigueCategoryIds.Add(categoriesIds[this.Random.GetRandomNumber(0, categoriesIds.Count - 1)]);
                    }

                    foreach (var unigueCategoryId in unigueCategoryIds)
                    {
                        toy.Categories.Add(this.Database.Categories.Find(unigueCategoryIds));
                    }
                }

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.Toys.Add(toy);                
            }

            Console.WriteLine("\nToys added.");
        }
    }
}