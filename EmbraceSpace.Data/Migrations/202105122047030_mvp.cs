namespace EmbraceSpace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mvp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SpaceStation", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SpaceStation", "Name", c => c.String());
        }
    }
}
