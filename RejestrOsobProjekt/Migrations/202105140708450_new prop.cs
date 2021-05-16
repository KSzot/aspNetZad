namespace RejestrOsobProjekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Humen", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Humen", "UserId");
        }
    }
}
