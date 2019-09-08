namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredToNameOfTvShow : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TvShows", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TvShows", "Name", c => c.String());
        }
    }
}
