namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTvShowPropertySize1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TvShows", "SeasonNumber", c => c.Byte(nullable: false));
            AlterColumn("dbo.TvShows", "NumberOfEpisodes", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TvShows", "NumberOfEpisodes", c => c.Int(nullable: false));
            AlterColumn("dbo.TvShows", "SeasonNumber", c => c.Int(nullable: false));
        }
    }
}
