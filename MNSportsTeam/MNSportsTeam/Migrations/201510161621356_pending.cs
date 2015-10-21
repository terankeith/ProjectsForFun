namespace MNSportsTeam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pending : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Championships", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.Teams", "YearId", "dbo.Years");
            DropIndex("dbo.Championships", new[] { "TeamId" });
            DropIndex("dbo.Teams", new[] { "VenueId" });
            DropIndex("dbo.Teams", new[] { "YearId" });
            AlterColumn("dbo.Championships", "TeamId", c => c.Int());
            AlterColumn("dbo.Teams", "VenueId", c => c.Int());
            AlterColumn("dbo.Teams", "YearId", c => c.Int());
            CreateIndex("dbo.Championships", "TeamId");
            CreateIndex("dbo.Teams", "VenueId");
            CreateIndex("dbo.Teams", "YearId");
            AddForeignKey("dbo.Championships", "TeamId", "dbo.Teams", "TeamId");
            AddForeignKey("dbo.Teams", "VenueId", "dbo.Venues", "VenueId");
            AddForeignKey("dbo.Teams", "YearId", "dbo.Years", "YearId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "YearId", "dbo.Years");
            DropForeignKey("dbo.Teams", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.Championships", "TeamId", "dbo.Teams");
            DropIndex("dbo.Teams", new[] { "YearId" });
            DropIndex("dbo.Teams", new[] { "VenueId" });
            DropIndex("dbo.Championships", new[] { "TeamId" });
            AlterColumn("dbo.Teams", "YearId", c => c.Int(nullable: false));
            AlterColumn("dbo.Teams", "VenueId", c => c.Int(nullable: false));
            AlterColumn("dbo.Championships", "TeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teams", "YearId");
            CreateIndex("dbo.Teams", "VenueId");
            CreateIndex("dbo.Championships", "TeamId");
            AddForeignKey("dbo.Teams", "YearId", "dbo.Years", "YearId", cascadeDelete: true);
            AddForeignKey("dbo.Teams", "VenueId", "dbo.Venues", "VenueId", cascadeDelete: true);
            AddForeignKey("dbo.Championships", "TeamId", "dbo.Teams", "TeamId", cascadeDelete: true);
        }
    }
}
