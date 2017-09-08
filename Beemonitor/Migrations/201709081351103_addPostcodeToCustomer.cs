namespace Beemonitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPostcodeToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apiaries", "Postcode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Apiaries", "Postcode");
        }
    }
}
