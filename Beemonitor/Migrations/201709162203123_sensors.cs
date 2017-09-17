namespace Beemonitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sensors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sensors",
                c => new
                    {
                        SensorName = c.String(nullable: false, maxLength: 128),
                        SensorTypeId = c.Int(nullable: false),
                        BeehiveId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SensorName)
                .ForeignKey("dbo.Beehives", t => t.BeehiveId, cascadeDelete: true)
                .ForeignKey("dbo.SensorTypes", t => t.SensorTypeId, cascadeDelete: true)
                .Index(t => t.SensorTypeId)
                .Index(t => t.BeehiveId);
            
            CreateTable(
                "dbo.SensorTypes",
                c => new
                    {
                        SensorTypeId = c.Int(nullable: false),
                        TypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.SensorTypeId);
            Sql("Insert into SensorTypes (SensorTypeId, TypeDescription) values (1, 'Hive Temperature')");
            Sql("Insert into SensorTypes (SensorTypeId, TypeDescription) values (2, 'Hive Mass')");
            Sql("Insert into SensorTypes (SensorTypeId, TypeDescription) values (3, 'Battery Level')");
            Sql("Insert into SensorTypes (SensorTypeId, TypeDescription) values (4, 'Ambient Temperature')");

            Sql("Insert into Sensors (SensorName, SensorTypeId, BeehiveId) values ('TestSensor', 1, 2)");

            AddColumn("dbo.Observations", "SensorName", c => c.String(maxLength: 128));
            CreateIndex("dbo.Observations", "SensorName");
            AddForeignKey("dbo.Observations", "SensorName", "dbo.Sensors", "SensorName");
            DropColumn("dbo.Observations", "BeehiveId");
            DropColumn("dbo.Observations", "ObsType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Observations", "ObsType", c => c.String());
            AddColumn("dbo.Observations", "BeehiveId", c => c.String());
            DropForeignKey("dbo.Sensors", "SensorTypeId", "dbo.SensorTypes");
            DropForeignKey("dbo.Sensors", "BeehiveId", "dbo.Beehives");
            DropForeignKey("dbo.Observations", "SensorName", "dbo.Sensors");
            DropIndex("dbo.Observations", new[] { "SensorName" });
            DropIndex("dbo.Sensors", new[] { "BeehiveId" });
            DropIndex("dbo.Sensors", new[] { "SensorTypeId" });
            DropColumn("dbo.Observations", "SensorName");
            DropTable("dbo.SensorTypes");
            DropTable("dbo.Sensors");
        }
    }
}
