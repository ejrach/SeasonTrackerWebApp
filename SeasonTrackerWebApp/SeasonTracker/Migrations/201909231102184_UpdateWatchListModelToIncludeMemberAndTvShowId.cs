namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWatchListModelToIncludeMemberAndTvShowId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TvShows", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.WatchLists", "MemberId", "dbo.Members");
            DropForeignKey("dbo.WatchLists", "TvShowId", "dbo.TvShows");
            DropIndex("dbo.TvShows", new[] { "Member_Id" });
            DropIndex("dbo.WatchLists", new[] { "MemberId" });
            DropIndex("dbo.WatchLists", new[] { "TvShowId" });
            RenameColumn(table: "dbo.WatchLists", name: "MemberId", newName: "Member_Id");
            RenameColumn(table: "dbo.WatchLists", name: "TvShowId", newName: "TvShow_Id");
            AlterColumn("dbo.WatchLists", "Member_Id", c => c.Int());
            AlterColumn("dbo.WatchLists", "TvShow_Id", c => c.Int());
            CreateIndex("dbo.WatchLists", "Member_Id");
            CreateIndex("dbo.WatchLists", "TvShow_Id");
            AddForeignKey("dbo.WatchLists", "Member_Id", "dbo.Members", "Id");
            AddForeignKey("dbo.WatchLists", "TvShow_Id", "dbo.TvShows", "Id");
            DropColumn("dbo.TvShows", "Member_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TvShows", "Member_Id", c => c.Int());
            DropForeignKey("dbo.WatchLists", "TvShow_Id", "dbo.TvShows");
            DropForeignKey("dbo.WatchLists", "Member_Id", "dbo.Members");
            DropIndex("dbo.WatchLists", new[] { "TvShow_Id" });
            DropIndex("dbo.WatchLists", new[] { "Member_Id" });
            AlterColumn("dbo.WatchLists", "TvShow_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.WatchLists", "Member_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.WatchLists", name: "TvShow_Id", newName: "TvShowId");
            RenameColumn(table: "dbo.WatchLists", name: "Member_Id", newName: "MemberId");
            CreateIndex("dbo.WatchLists", "TvShowId");
            CreateIndex("dbo.WatchLists", "MemberId");
            CreateIndex("dbo.TvShows", "Member_Id");
            AddForeignKey("dbo.WatchLists", "TvShowId", "dbo.TvShows", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WatchLists", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TvShows", "Member_Id", "dbo.Members", "Id");
        }
    }
}
