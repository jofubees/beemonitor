namespace Beemonitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBeehive : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beehives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ApiaryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apiaries", t => t.ApiaryId, cascadeDelete: true)
                .Index(t => t.ApiaryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Beehives", "ApiaryId", "dbo.Apiaries");
            DropIndex("dbo.Beehives", new[] { "ApiaryId" });
            DropTable("dbo.Beehives");
        }
    }
}
