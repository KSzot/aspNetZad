namespace RejestrOsobProjekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Humen", "whichUser", c => c.String());
            DropColumn("dbo.Humen", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Humen", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Humen", "whichUser");
        }
    }
}
