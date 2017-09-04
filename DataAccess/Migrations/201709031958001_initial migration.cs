namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        StandardID = c.Int(nullable: false, identity: true),
                        StandardName = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.StandardID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(maxLength: 2147483647),
                        DataOfBirth = c.DateTime(),
                        Photo = c.Binary(),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Double(nullable: false, storeType: "real"),
                        Standard_StandardID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Standards", t => t.Standard_StandardID)
                .Index(t => t.Standard_StandardID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Standard_StandardID", "dbo.Standards");
            DropIndex("dbo.Students", new[] { "Standard_StandardID" });
            DropTable("dbo.Students");
            DropTable("dbo.Standards");
        }
    }
}
