namespace MyTunesList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PendingModelChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SingleRating", "DateModified", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.SingleTrack", "DateModified", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.SingleTrack", "ModifiedUtc");
            DropColumn("dbo.SingleTrack", "AverageRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SingleTrack", "AverageRating", c => c.Double(nullable: false));
            AddColumn("dbo.SingleTrack", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.SingleTrack", "DateModified");
            DropColumn("dbo.SingleRating", "DateModified");
        }
    }
}
