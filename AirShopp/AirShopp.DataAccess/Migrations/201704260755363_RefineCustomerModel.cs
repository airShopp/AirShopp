namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefineCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "QuestionA", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.Customer", "AnswerA", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.Customer", "QuestionB", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.Customer", "AnswerB", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.Customer", "LastSignInIpAddr", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.Customer", "LastSignInTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customer", "CustomerName", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Customer", "TelephoneNo", c => c.String(nullable: false, maxLength: 11));
            DropColumn("dbo.Customer", "ZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "ZipCode", c => c.String(maxLength: 6));
            AlterColumn("dbo.Customer", "TelephoneNo", c => c.String(maxLength: 11));
            AlterColumn("dbo.Customer", "CustomerName", c => c.String(maxLength: 32));
            DropColumn("dbo.Customer", "LastSignInTime");
            DropColumn("dbo.Customer", "LastSignInIpAddr");
            DropColumn("dbo.Customer", "AnswerB");
            DropColumn("dbo.Customer", "QuestionB");
            DropColumn("dbo.Customer", "AnswerA");
            DropColumn("dbo.Customer", "QuestionA");
        }
    }
}
