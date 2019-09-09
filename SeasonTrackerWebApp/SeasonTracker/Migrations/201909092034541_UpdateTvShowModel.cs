namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTvShowModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TvShows", "SeasonNumber", c => c.Int(nullable: false));
            AddColumn("dbo.TvShows", "NumberOfEpisodes", c => c.Int(nullable: false));
            DropColumn("dbo.TvShows", "Season");
            DropColumn("dbo.TvShows", "Episodes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TvShows", "Episodes", c => c.Int(nullable: false));
            AddColumn("dbo.TvShows", "Season", c => c.Int(nullable: false));
            DropColumn("dbo.TvShows", "NumberOfEpisodes");
            DropColumn("dbo.TvShows", "SeasonNumber");
        }
    }
}
