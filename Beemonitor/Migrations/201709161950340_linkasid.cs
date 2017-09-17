namespace Beemonitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linkasid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Beehives", "Apiary_Id", "dbo.Apiaries");
            DropIndex("dbo.Beehives", new[] { "Apiary_Id" });
            RenameColumn(table: "dbo.Beehives", name: "Apiary_Id", newName: "ApiaryId");
            AlterColumn("dbo.Beehives", "ApiaryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Beehives", "ApiaryId");
            AddForeignKey("dbo.Beehives", "ApiaryId", "dbo.Apiaries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Beehives", "ApiaryId", "dbo.Apiaries");
            DropIndex("dbo.Beehives", new[] { "ApiaryId" });
            AlterColumn("dbo.Beehives", "ApiaryId", c => c.Int());
            RenameColumn(table: "dbo.Beehives", name: "ApiaryId", newName: "Apiary_Id");
            CreateIndex("dbo.Beehives", "Apiary_Id");
            AddForeignKey("dbo.Beehives", "Apiary_Id", "dbo.Apiaries", "Id");
        }
    }
}
