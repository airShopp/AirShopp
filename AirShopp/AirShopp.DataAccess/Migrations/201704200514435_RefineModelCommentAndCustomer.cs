namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefineModelCommentAndCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "CommentDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customer", "CustomerCode");
            DropColumn("dbo.Customer", "CustomerLevel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "CustomerLevel", c => c.String());
            AddColumn("dbo.Customer", "CustomerCode", c => c.String());
            DropColumn("dbo.Comment", "CommentDate");
        }
    }
}
