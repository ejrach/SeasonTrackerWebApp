namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredToMemberAndTvShowInWatchListModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WatchLists", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.WatchLists", "TvShow_Id", "dbo.TvShows");
            DropIndex("dbo.WatchLists", new[] { "Member_Id" });
            DropIndex("dbo.WatchLists", new[] { "TvShow_Id" });
            AlterColumn("dbo.WatchLists", "Member_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.WatchLists", "TvShow_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.WatchLists", "Member_Id");
            CreateIndex("dbo.WatchLists", "TvShow_Id");
            AddForeignKey("dbo.WatchLists", "Member_Id", "dbo.Members", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WatchLists", "TvShow_Id", "dbo.TvShows", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WatchLists", "TvShow_Id", "dbo.TvShows");
            DropForeignKey("dbo.WatchLists", "Member_Id", "dbo.Members");
            DropIndex("dbo.WatchLists", new[] { "TvShow_Id" });
            DropIndex("dbo.WatchLists", new[] { "Member_Id" });
            AlterColumn("dbo.WatchLists", "TvShow_Id", c => c.Int());
            AlterColumn("dbo.WatchLists", "Member_Id", c => c.Int());
            CreateIndex("dbo.WatchLists", "TvShow_Id");
            CreateIndex("dbo.WatchLists", "Member_Id");
            AddForeignKey("dbo.WatchLists", "TvShow_Id", "dbo.TvShows", "Id");
            AddForeignKey("dbo.WatchLists", "Member_Id", "dbo.Members", "Id");
        }
    }
}
