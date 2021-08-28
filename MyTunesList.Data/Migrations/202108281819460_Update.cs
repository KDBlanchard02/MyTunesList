namespace MyTunesList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SingleTrack", "AverageRating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SingleTrack", "AverageRating");
        }
    }
}
