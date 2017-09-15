namespace Beemonitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class apihive : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Beehives", "ApiaryId", "dbo.Apiaries");
            DropIndex("dbo.Beehives", new[] { "ApiaryId" });
            RenameColumn(table: "dbo.Beehives", name: "ApiaryId", newName: "Apiary_Id");
            AlterColumn("dbo.Beehives", "Apiary_Id", c => c.Int());
            CreateIndex("dbo.Beehives", "Apiary_Id");
            AddForeignKey("dbo.Beehives", "Apiary_Id", "dbo.Apiaries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Beehives", "Apiary_Id", "dbo.Apiaries");
            DropIndex("dbo.Beehives", new[] { "Apiary_Id" });
            AlterColumn("dbo.Beehives", "Apiary_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Beehives", name: "Apiary_Id", newName: "ApiaryId");
            CreateIndex("dbo.Beehives", "ApiaryId");
            AddForeignKey("dbo.Beehives", "ApiaryId", "dbo.Apiaries", "Id", cascadeDelete: true);
        }
    }
}
