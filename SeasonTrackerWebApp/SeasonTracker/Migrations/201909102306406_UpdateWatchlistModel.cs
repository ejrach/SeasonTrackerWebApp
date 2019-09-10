namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWatchlistModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "WatchList_Id", "dbo.WatchLists");
            DropIndex("dbo.Members", new[] { "WatchList_Id" });
            CreateIndex("dbo.WatchLists", "MemberId");
            AddForeignKey("dbo.WatchLists", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
            DropColumn("dbo.Members", "WatchList_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "WatchList_Id", c => c.Int());
            DropForeignKey("dbo.WatchLists", "MemberId", "dbo.Members");
            DropIndex("dbo.WatchLists", new[] { "MemberId" });
            CreateIndex("dbo.Members", "WatchList_Id");
            AddForeignKey("dbo.Members", "WatchList_Id", "dbo.WatchLists", "Id");
        }
    }
}
