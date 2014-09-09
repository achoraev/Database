namespace ATM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CardAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(nullable: false, maxLength: 10),
                        CardPIN = c.String(nullable: false, maxLength: 4),
                        CardCash = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransactionLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TransactionLogs");
            DropTable("dbo.CardAccounts");
        }
    }
}
