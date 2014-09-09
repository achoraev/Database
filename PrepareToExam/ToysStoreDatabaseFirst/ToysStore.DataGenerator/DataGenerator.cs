namespace ToysStore.DataGenerator
{
    using ToysStore.Data;

    internal abstract class DataGenerator: IDataGenerator
    {
        private IRandomDataGenerator random;

        private ToyStoreEntities1 db;

        private int count;

        public DataGenerator(IRandomDataGenerator randomGenerator, ToyStoreEntities1 dbContext, int countOfObjects)
        {
            this.random = randomGenerator;
            this.db = dbContext;
            this.count = countOfObjects;
        }

        protected IRandomDataGenerator Random
        {
            get { return this.random; }
        }

        protected ToyStoreEntities1 Database
        {
            get { return this.db; }
        }

        protected int Count
        {
            get { return this.count; }
        }

        public abstract void Generate();        
    }
}