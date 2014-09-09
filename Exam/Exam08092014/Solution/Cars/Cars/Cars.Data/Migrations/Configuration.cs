namespace Cars.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Cars.Data;

    public sealed class Configuration : DbMigrationsConfiguration<CarsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(CarsDbContext context)
        {
            
        }
    }
}