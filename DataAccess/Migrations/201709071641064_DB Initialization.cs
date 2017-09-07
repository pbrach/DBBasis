namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DBInitialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppInfoes",
                c => new
                {
                    AppVersion = c.String(nullable: false, maxLength: 128),
                    AppInfoText = c.String(maxLength: 2147483647),
                })
                .PrimaryKey(t => t.AppVersion);

        }

        public override void Down()
        {
            DropTable("dbo.AppInfoes");
        }
    }
}
