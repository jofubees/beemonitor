namespace Beemonitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateApiaryBeehives1 : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Apiaries ( Name) VALUES ('Garden')");
            Sql("insert into Apiaries ( Name) VALUES ('Appletree')");
 

        }

        public override void Down()
        {
        }
    }
}
