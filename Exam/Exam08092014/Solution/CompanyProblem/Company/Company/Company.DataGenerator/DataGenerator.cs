namespace Company.DataGenerator
{
    using Company.Data;

    public abstract class DataGenerator: IDataGenerator
    {
        private IRandomDataGenerator random;

        private CompanyEntities db;

        private int count;

        public DataGenerator(IRandomDataGenerator randomGenerator, CompanyEntities dbContext, int countOfObjects)
        {
            this.random = randomGenerator;
            this.db = dbContext;
            this.count = countOfObjects;
        }

        protected IRandomDataGenerator Random
        {
            get { return this.random; }
        }

        protected CompanyEntities Database
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