namespace VideoRentalApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMemberShipType : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MembershiptTypes(id, name, signupfee, durationinmonth, discountrate) values(1, 'Pay As You GO', 0, 0, 0)");
            Sql("Insert into MembershiptTypes(id, name, signupfee, durationinmonth, discountrate) values(2, 'Monthly', 15, 1, 10)");
            Sql("Insert into MembershiptTypes(id, name, signupfee, durationinmonth, discountrate) values(3, 'Quaterly', 40, 3, 15)");
            Sql("Insert into MembershiptTypes(id, name, signupfee, durationinmonth, discountrate) values(4, 'Yearly', 160, 12, 25)");
        }
        
        public override void Down()
        {
        }
    }
}
