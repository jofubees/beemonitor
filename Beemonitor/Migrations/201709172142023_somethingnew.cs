namespace Beemonitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somethingnew : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sensors", "BeehiveId", "dbo.Beehives");
            DropIndex("dbo.Sensors", new[] { "BeehiveId" });
            RenameColumn(table: "dbo.Sensors", name: "BeehiveId", newName: "Beehive_Id");
            AddColumn("dbo.Sensors", "SiteId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sensors", "Beehive_Id", c => c.Int());
            CreateIndex("dbo.Sensors", "Beehive_Id");
            AddForeignKey("dbo.Sensors", "Beehive_Id", "dbo.Beehives", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sensors", "Beehive_Id", "dbo.Beehives");
            DropIndex("dbo.Sensors", new[] { "Beehive_Id" });
            AlterColumn("dbo.Sensors", "Beehive_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Sensors", "SiteId");
            RenameColumn(table: "dbo.Sensors", name: "Beehive_Id", newName: "BeehiveId");
            CreateIndex("dbo.Sensors", "BeehiveId");
            AddForeignKey("dbo.Sensors", "BeehiveId", "dbo.Beehives", "Id", cascadeDelete: true);
        }
    }
}
