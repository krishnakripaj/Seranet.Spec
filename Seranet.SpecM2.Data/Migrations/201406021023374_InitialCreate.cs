namespace Seranet.SpecM2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Area",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        GUID = c.Guid(nullable: false),
                        RowVersion = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubArea",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        GUID = c.Guid(nullable: false),
                        RowVersion = c.Binary(),
                        Area_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Area", t => t.Area_Id)
                .Index(t => t.Area_Id);
            
            CreateTable(
                "dbo.Practice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                        Obsolete = c.Boolean(nullable: false),
                        GUID = c.Guid(nullable: false),
                        RowVersion = c.Binary(),
                        Level_Id = c.Int(),
                        SubArea_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Level", t => t.Level_Id)
                .ForeignKey("dbo.SubArea", t => t.SubArea_Id)
                .Index(t => t.Level_Id)
                .Index(t => t.SubArea_Id);
            
            CreateTable(
                "dbo.Level",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        GUID = c.Guid(nullable: false),
                        RowVersion = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Claim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamComment = c.String(),
                        AuditorComment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        GUID = c.Guid(nullable: false),
                        RowVersion = c.Binary(),
                        Practice_Id = c.Int(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Practice", t => t.Practice_Id)
                .ForeignKey("dbo.Project", t => t.Project_Id)
                .Index(t => t.Practice_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProjetId = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        GUID = c.Guid(nullable: false),
                        RowVersion = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserRoleType = c.Int(nullable: false),
                        UserName = c.String(),
                        GUID = c.Guid(nullable: false),
                        RowVersion = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Claim", "Project_Id", "dbo.Project");
            DropForeignKey("dbo.Claim", "Practice_Id", "dbo.Practice");
            DropForeignKey("dbo.SubArea", "Area_Id", "dbo.Area");
            DropForeignKey("dbo.Practice", "SubArea_Id", "dbo.SubArea");
            DropForeignKey("dbo.Practice", "Level_Id", "dbo.Level");
            DropIndex("dbo.Claim", new[] { "Project_Id" });
            DropIndex("dbo.Claim", new[] { "Practice_Id" });
            DropIndex("dbo.SubArea", new[] { "Area_Id" });
            DropIndex("dbo.Practice", new[] { "SubArea_Id" });
            DropIndex("dbo.Practice", new[] { "Level_Id" });
            DropTable("dbo.UserRole");
            DropTable("dbo.Project");
            DropTable("dbo.Claim");
            DropTable("dbo.Level");
            DropTable("dbo.Practice");
            DropTable("dbo.SubArea");
            DropTable("dbo.Area");
        }
    }
}
