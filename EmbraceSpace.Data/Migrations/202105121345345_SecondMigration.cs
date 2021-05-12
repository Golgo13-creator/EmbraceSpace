namespace EmbraceSpace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpaceShip", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SpaceStation", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.LaunchSite", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.LaunchSite", "Location", c => c.String(nullable: false));
            DropColumn("dbo.SpaceShip", "CreateUtc");
            DropColumn("dbo.SpaceStation", "CreateUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SpaceStation", "CreateUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SpaceShip", "CreateUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.LaunchSite", "Location", c => c.String());
            AlterColumn("dbo.LaunchSite", "Name", c => c.String());
            DropColumn("dbo.SpaceStation", "CreatedUtc");
            DropColumn("dbo.SpaceShip", "CreatedUtc");
        }
    }
}
