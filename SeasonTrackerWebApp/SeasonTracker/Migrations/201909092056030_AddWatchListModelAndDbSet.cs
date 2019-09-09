namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWatchListModelAndDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WatchLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        TvShowId = c.Int(nullable: false),
                        ViewingList = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.TvShows", t => t.TvShowId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.TvShowId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WatchLists", "TvShowId", "dbo.TvShows");
            DropForeignKey("dbo.WatchLists", "MemberId", "dbo.Members");
            DropIndex("dbo.WatchLists", new[] { "TvShowId" });
            DropIndex("dbo.WatchLists", new[] { "MemberId" });
            DropTable("dbo.WatchLists");
        }
    }
}
