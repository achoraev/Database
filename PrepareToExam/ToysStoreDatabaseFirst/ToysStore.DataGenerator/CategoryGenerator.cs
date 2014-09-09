namespace ToysStore.DataGenerator
{
    using System;
    using ToysStore.Data;

    internal class CategoryGenerator: DataGenerator, IDataGenerator
    {
        public CategoryGenerator(IRandomDataGenerator randomGenerator, ToyStoreEntities1 dbContext, int countOfObjects) :
            base(randomGenerator, dbContext, countOfObjects)
        {            
        }

        public override void Generate()
        {
            Console.WriteLine("Adding categories...");
            for (int i = 0; i < this.Count; i++)
            {                
                var category = new Category
                {
                    Name = this.Random.GetRandomStringRandomLength(5, 20)
                };

                this.Database.Categories.Add(category);

                // important for big entries
                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }                
            }

            Console.WriteLine("\nCategory added.");
        }
    }
}