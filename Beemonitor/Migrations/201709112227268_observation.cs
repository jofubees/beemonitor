namespace Beemonitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class observation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Observations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeehiveId = c.String(),
                        ObsType = c.String(),
                        ObsValue = c.Single(nullable: false),
                        ObsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Observations");
        }
    }
}
