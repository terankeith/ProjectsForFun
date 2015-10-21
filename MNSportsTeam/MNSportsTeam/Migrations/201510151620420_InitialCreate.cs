namespace MNSportsTeam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Championships",
                c => new
                    {
                        ChampionshipId = c.Int(nullable: false, identity: true),
                        ChampYear = c.String(),
                        Title = c.String(),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChampionshipId)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sport = c.String(),
                        Mascot = c.String(),
                        Coach = c.String(),
                        Owner = c.String(),
                        AvgSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                        Convictions = c.Int(nullable: false),
                        VenueId = c.Int(nullable: false),
                        YearId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .ForeignKey("dbo.Years", t => t.YearId, cascadeDelete: true)
                .Index(t => t.VenueId)
                .Index(t => t.YearId);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        VenueId = c.Int(nullable: false, identity: true),
                        Building = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.VenueId);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        YearId = c.Int(nullable: false, identity: true),
                        YearFounded = c.String(),
                        YearDisbanded = c.String(),
                    })
                .PrimaryKey(t => t.YearId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "YearId", "dbo.Years");
            DropForeignKey("dbo.Teams", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.Championships", "TeamId", "dbo.Teams");
            DropIndex("dbo.Teams", new[] { "YearId" });
            DropIndex("dbo.Teams", new[] { "VenueId" });
            DropIndex("dbo.Championships", new[] { "TeamId" });
            DropTable("dbo.Years");
            DropTable("dbo.Venues");
            DropTable("dbo.Teams");
            DropTable("dbo.Championships");
        }
    }
}
