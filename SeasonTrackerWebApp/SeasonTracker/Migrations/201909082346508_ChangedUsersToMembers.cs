namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUsersToMembers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "AccountTypeId", "dbo.AccountTypes");
            DropIndex("dbo.Users", new[] { "AccountTypeId" });
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberName = c.String(nullable: false, maxLength: 255),
                        IsSubscribedToNewsLetter = c.Boolean(nullable: false),
                        AccountTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTypes", t => t.AccountTypeId, cascadeDelete: true)
                .Index(t => t.AccountTypeId);
            
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 255),
                        IsSubscribedToNewsLetter = c.Boolean(nullable: false),
                        AccountTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Members", "AccountTypeId", "dbo.AccountTypes");
            DropIndex("dbo.Members", new[] { "AccountTypeId" });
            DropTable("dbo.Members");
            CreateIndex("dbo.Users", "AccountTypeId");
            AddForeignKey("dbo.Users", "AccountTypeId", "dbo.AccountTypes", "Id", cascadeDelete: true);
        }
    }
}
