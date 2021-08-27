namespace MyTunesList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlbumRating", "AlbumId", c => c.Int(nullable: false));
            AlterColumn("dbo.SingleTrack", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.SingleTrack", "Genre", c => c.Int(nullable: false));
            AlterColumn("dbo.SingleTrack", "Artist_Band", c => c.String(nullable: false));
            AlterColumn("dbo.SingleTrack", "ReleaseDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.AlbumRating", "AlbumId");
            AddForeignKey("dbo.AlbumRating", "AlbumId", "dbo.Album", "AlbumId", cascadeDelete: true);
            DropColumn("dbo.Album", "AverageRating");
            DropColumn("dbo.SingleTrack", "AverageRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SingleTrack", "AverageRating", c => c.Double(nullable: false));
            AddColumn("dbo.Album", "AverageRating", c => c.Double(nullable: false));
            DropForeignKey("dbo.AlbumRating", "AlbumId", "dbo.Album");
            DropIndex("dbo.AlbumRating", new[] { "AlbumId" });
            AlterColumn("dbo.SingleTrack", "ReleaseDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.SingleTrack", "Artist_Band", c => c.String());
            AlterColumn("dbo.SingleTrack", "Genre", c => c.String());
            AlterColumn("dbo.SingleTrack", "Title", c => c.String());
            DropColumn("dbo.AlbumRating", "AlbumId");
        }
    }
}
