namespace Template.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Template.Data;

    public sealed class Configuration : DbMigrationsConfiguration<TemplateDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(TemplateDbContext context)
        {            
        }
    }
}