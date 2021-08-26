namespace MyTunesList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumRating",
                c => new
                    {
                        AlbumRatingId = c.Int(nullable: false, identity: true),
                        AuthorId = c.Guid(nullable: false),
                        Rating = c.Double(nullable: false),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        ReviewComment = c.String(),
                    })
                .PrimaryKey(t => t.AlbumRatingId);
            
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        AlbumTitle = c.String(nullable: false),
                        Length = c.Double(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        AverageRating = c.Double(nullable: false),
                        AuthorizedAlbumCreator = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            CreateTable(
                "dbo.Artist_Band",
                c => new
                    {
                        Artist_BandId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FormationYear = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Genre = c.Int(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Artist_BandId);
            
            CreateTable(
                "dbo.SingleRating",
                c => new
                    {
                        SingleRatingId = c.Int(nullable: false, identity: true),
                        SingleId = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        ReviewComment = c.String(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SingleRatingId)
                .ForeignKey("dbo.SingleTrack", t => t.SingleId, cascadeDelete: true)
                .Index(t => t.SingleId);
            
            CreateTable(
                "dbo.SingleTrack",
                c => new
                    {
                        SingleId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Title = c.String(),
                        Genre = c.String(),
                        Length = c.Double(nullable: false),
                        Artist_Band = c.String(),
                        ReleaseDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        AverageRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SingleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SingleRating", "SingleId", "dbo.SingleTrack");
            DropIndex("dbo.SingleRating", new[] { "SingleId" });
            DropTable("dbo.SingleTrack");
            DropTable("dbo.SingleRating");
            DropTable("dbo.Artist_Band");
            DropTable("dbo.Album");
            DropTable("dbo.AlbumRating");
        }
    }
}
