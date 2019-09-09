namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWatchListModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WatchLists", "MemberId", "dbo.Members");
            DropForeignKey("dbo.WatchLists", "TvShowId", "dbo.TvShows");
            DropIndex("dbo.WatchLists", new[] { "MemberId" });
            DropIndex("dbo.WatchLists", new[] { "TvShowId" });
            AddColumn("dbo.Members", "WatchList_Id", c => c.Int());
            AlterColumn("dbo.WatchLists", "ViewingList", c => c.String());
            CreateIndex("dbo.Members", "WatchList_Id");
            AddForeignKey("dbo.Members", "WatchList_Id", "dbo.WatchLists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "WatchList_Id", "dbo.WatchLists");
            DropIndex("dbo.Members", new[] { "WatchList_Id" });
            AlterColumn("dbo.WatchLists", "ViewingList", c => c.String(nullable: false));
            DropColumn("dbo.Members", "WatchList_Id");
            CreateIndex("dbo.WatchLists", "TvShowId");
            CreateIndex("dbo.WatchLists", "MemberId");
            AddForeignKey("dbo.WatchLists", "TvShowId", "dbo.TvShows", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WatchLists", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
        }
    }
}
