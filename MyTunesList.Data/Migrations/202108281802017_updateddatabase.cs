namespace MyTunesList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddatabase : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SingleTrack", "AverageRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SingleTrack", "AverageRating", c => c.Double(nullable: false));
        }
    }
}
