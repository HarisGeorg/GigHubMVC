namespace GigHubMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewConventionsInGigsAndGenres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Gigs", "Application_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Application_Id" });
            DropIndex("dbo.Gigs", new[] { "Genre_Id" });
            RenameColumn(table: "dbo.Gigs", name: "Application_Id", newName: "Artist_Id");
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Gigs", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Gigs", "Artist_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Gigs", "Genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Gigs", "Artist_Id");
            CreateIndex("dbo.Gigs", "Genre_Id");
            AddForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "Genre_Id" });
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            AlterColumn("dbo.Gigs", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Gigs", "Artist_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Gigs", "Venue", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            RenameColumn(table: "dbo.Gigs", name: "Artist_Id", newName: "Application_Id");
            CreateIndex("dbo.Gigs", "Genre_Id");
            CreateIndex("dbo.Gigs", "Application_Id");
            AddForeignKey("dbo.Gigs", "Application_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
