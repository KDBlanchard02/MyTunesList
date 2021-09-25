namespace MyTunesList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SingleTrack", "ReleaseDate", c => c.Int(nullable: false));
            DropColumn("dbo.SingleTrack", "Length");
            //DropColumn("dbo.SingleTrack", "DateModified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SingleTrack", "DateModified", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.SingleTrack", "Length", c => c.Double(nullable: false));
            AlterColumn("dbo.SingleTrack", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
