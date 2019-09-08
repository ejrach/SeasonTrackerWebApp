namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTvShowSeasonAndEpisodes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TvShows", "Season", c => c.Int(nullable: false));
            AddColumn("dbo.TvShows", "Episodes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TvShows", "Episodes");
            DropColumn("dbo.TvShows", "Season");
        }
    }
}
