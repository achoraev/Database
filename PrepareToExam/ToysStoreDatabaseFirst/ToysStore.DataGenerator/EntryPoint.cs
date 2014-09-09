namespace ToysStore.DataGenerator
{    
    using System.Collections.Generic;

    using ToysStore.Data;

    internal class EntryPoint
    {
        public static void Main()
        {            
            var random = RandomGenerator.Instance;
            var db = new ToyStoreEntities1();
            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>
            {
                new CategoryGenerator(random, db, 100),
                new ManufacturerGenerator(random, db, 50),
                new AgeRangeDataGenerator(random, db, 100),   
                new ToyStoreDataGenerator(random, db, 20000)
            };

            foreach (var generator in listOfGenerators)
            {                
                generator.Generate();
                db.SaveChanges();
            }            
        }
    }
}