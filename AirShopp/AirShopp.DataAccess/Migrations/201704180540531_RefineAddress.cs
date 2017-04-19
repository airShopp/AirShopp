namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefineAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Address", "AreaId", c => c.Long(nullable: false));
            AddColumn("dbo.Address", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Address", "Longitude", c => c.Double(nullable: false));
            CreateIndex("dbo.Address", "AreaId");
            AddForeignKey("dbo.Address", "AreaId", "dbo.Area", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "AreaId", "dbo.Area");
            DropIndex("dbo.Address", new[] { "AreaId" });
            DropColumn("dbo.Address", "Longitude");
            DropColumn("dbo.Address", "Latitude");
            DropColumn("dbo.Address", "AreaId");
        }
    }
}
