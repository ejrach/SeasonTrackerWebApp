namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5a4a3715-01a2-4639-8024-1c03abee0ecd', N'admin@seasontracker.com', 0, N'AJsEmJvMkXClC6UkcDByNIwzfOt6qNOQ/d43Cx//JfV0LPmrGqCKP39fPzRKTU7rrQ==', N'025e1340-94c1-47f3-b247-074b53d4ed3d', NULL, 0, 0, NULL, 1, 0, N'admin@seasontracker.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a3d5f417-91fe-4d46-b881-a7c2af281fa5', N'guest@seasontracker.com', 0, N'AGrBEdsm/a1srGRwBwsb2GwWJ1syNigBVBIOnGOPAiAjktNzUjx4y2ol+Ly4RFi6wA==', N'e1a267bf-59f6-4d11-b7bb-b890838825f5', NULL, 0, 0, NULL, 1, 0, N'guest@seasontracker.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'49e41ac1-f3a0-41e4-9d55-b3ac393c4eb1', N'CanManageMembers')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c7c61c28-3a3a-416a-9331-412954b666c6', N'CanManageTvShows')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f46ac9cf-e4a8-460a-bf30-e58817167745', N'CanManageWatchLists')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5a4a3715-01a2-4639-8024-1c03abee0ecd', N'49e41ac1-f3a0-41e4-9d55-b3ac393c4eb1')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5a4a3715-01a2-4639-8024-1c03abee0ecd', N'c7c61c28-3a3a-416a-9331-412954b666c6')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5a4a3715-01a2-4639-8024-1c03abee0ecd', N'f46ac9cf-e4a8-460a-bf30-e58817167745')


");
        }
        
        public override void Down()
        {
        }
    }
}
