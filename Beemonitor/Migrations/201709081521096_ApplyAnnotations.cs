namespace Beemonitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Apiaries", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Apiaries", "Postcode", c => c.String(maxLength: 10));
            AlterColumn("dbo.Beehives", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Beehives", "Name", c => c.String());
            AlterColumn("dbo.Apiaries", "Postcode", c => c.String());
            AlterColumn("dbo.Apiaries", "Name", c => c.String());
        }
    }
}
