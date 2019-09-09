namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAccountNameFromAccountTypeModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AccountTypes", "AccountName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AccountTypes", "AccountName", c => c.String());
        }
    }
}
