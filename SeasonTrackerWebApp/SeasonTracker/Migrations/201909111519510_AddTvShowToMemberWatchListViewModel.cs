namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTvShowToMemberWatchListViewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TvShows", "Member_Id", c => c.Int());
            CreateIndex("dbo.TvShows", "Member_Id");
            CreateIndex("dbo.WatchLists", "TvShowId");
            AddForeignKey("dbo.TvShows", "Member_Id", "dbo.Members", "Id");
            AddForeignKey("dbo.WatchLists", "TvShowId", "dbo.TvShows", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WatchLists", "TvShowId", "dbo.TvShows");
            DropForeignKey("dbo.TvShows", "Member_Id", "dbo.Members");
            DropIndex("dbo.WatchLists", new[] { "TvShowId" });
            DropIndex("dbo.TvShows", new[] { "Member_Id" });
            DropColumn("dbo.TvShows", "Member_Id");
        }
    }
}
