using System.Data.Entity.Migrations;

namespace Nuevo.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Nuevo.Data.NuevoDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Nuevo.Data.NuevoDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
