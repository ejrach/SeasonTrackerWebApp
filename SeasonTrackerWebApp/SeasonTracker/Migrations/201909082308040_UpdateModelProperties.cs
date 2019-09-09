namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountTypes", "AccountName", c => c.String());
            AddColumn("dbo.TvShows", "TvShowName", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.AccountTypes", "Name");
            DropColumn("dbo.TvShows", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TvShows", "Name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AccountTypes", "Name", c => c.String());
            DropColumn("dbo.TvShows", "TvShowName");
            DropColumn("dbo.AccountTypes", "AccountName");
        }
    }
}
