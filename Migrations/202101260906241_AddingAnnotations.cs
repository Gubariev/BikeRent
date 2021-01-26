namespace BikeRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bikes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bikes", "Name", c => c.String());
        }
    }
}
