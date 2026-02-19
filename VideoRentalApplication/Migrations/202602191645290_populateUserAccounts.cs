namespace VideoRentalApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateUserAccounts : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'50da9861-923b-4be3-a979-e5720da30976', N'rahul@gmail.com', 0, N'AKYH4RAvwGDAroOfy2bKbDBA6ERGq2YQ/MHUstC6uAAJiOU2ZEJJZlyftfXnVYIqgA==', N'70e5e104-98fa-478a-b80c-95b304509fc3', NULL, 0, 0, NULL, 1, 0, N'rahul@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7248e2be-74b7-4854-a695-a9295e0bb1b2', N'deep@gmail.com', 0, N'AIFbUWoTNwn6/fj33XrtENlhA0B756AABf78c8x/GvdkL5Sxygp0O6arl2dMn8WR+Q==', N'91169e30-cc34-4e16-85e5-4ac64f79b105', NULL, 0, 0, NULL, 1, 0, N'deep@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'576c8643-227d-468a-86c3-4fee0bd3d045', N'Admin')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'50da9861-923b-4be3-a979-e5720da30976', N'576c8643-227d-468a-86c3-4fee0bd3d045')
");
        }
        
        public override void Down()
        {
        }
    }
}
