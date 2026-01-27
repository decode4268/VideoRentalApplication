namespace VideoRentalApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemebershiptTblAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershiptTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        SignUpFee = c.Int(nullable: false),
                        DurationInMonth = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MembershiptTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershiptTypeId");
            AddForeignKey("dbo.Customers", "MembershiptTypeId", "dbo.MembershiptTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershiptTypeId", "dbo.MembershiptTypes");
            DropIndex("dbo.Customers", new[] { "MembershiptTypeId" });
            DropColumn("dbo.Customers", "MembershiptTypeId");
            DropTable("dbo.MembershiptTypes");
        }
    }
}
