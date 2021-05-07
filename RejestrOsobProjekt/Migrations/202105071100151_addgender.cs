namespace RejestrOsobProjekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgender : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO Genders(Name) VALUES('Mezczyzna')");
            Sql("INSERT INTO Genders(Name) VALUES('Kobieta')");
            AddColumn("dbo.Humen", "GenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Humen", "GenderId");
            AddForeignKey("dbo.Humen", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Humen", "GenderId", "dbo.Genders");
            DropIndex("dbo.Humen", new[] { "GenderId" });
            DropColumn("dbo.Humen", "GenderId");
            DropTable("dbo.Genders");
        }
    }
}
