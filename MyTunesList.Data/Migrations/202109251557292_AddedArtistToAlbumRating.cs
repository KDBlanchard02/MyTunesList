namespace MyTunesList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedArtistToAlbumRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlbumRating", "Artist_BandId", c => c.Int(nullable: false));
            CreateIndex("dbo.AlbumRating", "Artist_BandId");
            AddForeignKey("dbo.AlbumRating", "Artist_BandId", "dbo.Artist_Band", "Artist_BandId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlbumRating", "Artist_BandId", "dbo.Artist_Band");
            DropIndex("dbo.AlbumRating", new[] { "Artist_BandId" });
            DropColumn("dbo.AlbumRating", "Artist_BandId");
        }
    }
}
