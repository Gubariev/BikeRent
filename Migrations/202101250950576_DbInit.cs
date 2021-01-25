namespace BikeRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BikeTypeId = c.Byte(nullable: false),
                        RentCost = c.Int(nullable: false),
                        RentStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BikeTypes", t => t.BikeTypeId, cascadeDelete: true)
                .Index(t => t.BikeTypeId);
            
            CreateTable(
                "dbo.BikeTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bikes", "BikeTypeId", "dbo.BikeTypes");
            DropIndex("dbo.Bikes", new[] { "BikeTypeId" });
            DropTable("dbo.BikeTypes");
            DropTable("dbo.Bikes");
        }
    }
}
