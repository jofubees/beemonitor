using Beemonitor.Models;

namespace Beemonitor.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Beemonitor.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Beemonitor.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.SensorTypes.AddOrUpdate(
                p => p.SensorTypeId,
                new SensorType {SensorTypeId = 1, TypeDescription = "Hive Temperature"}
                , new SensorType {SensorTypeId = 2, TypeDescription = "Hive Mass"}
                , new SensorType {SensorTypeId = 3, TypeDescription = "Battery Level"}
                , new SensorType {SensorTypeId = 4, TypeDescription = "Ambient Temperature"}
            );
            //
        }
    }
}
