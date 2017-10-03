using System.Data.Entity.Infrastructure;
using System.Data.SQLite.EF6.Migrations;

namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.DataContext>
    {
        /*
         * Please READ THIS:
         * 
         * after calling "update-database" the update will be found in the compile dir /bin/debug
         */
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());

            // ugly hard coded local sting that i can not get rid of
            const string connectionString = @"data source=d:\haphi\DBBasis\Resources\SQLiteDatabase.db";

            this.TargetDatabase = new DbConnectionInfo(connectionString, "System.Data.SQLite.EF6");
        }

        protected override void Seed(DataAccess.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
