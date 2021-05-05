namespace RejestrOsobProjekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedRolesData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Roles(Title) VALUES('Administrator')");
            Sql("INSERT INTO Roles(Title) VALUES('User')");
            Sql("INSERT INTO Roles(Title) VALUES('NotRegister')");
        }
        
        public override void Down()
        {
        }
    }
}
