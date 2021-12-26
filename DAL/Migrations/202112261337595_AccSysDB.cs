namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccSysDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KnowledgeForms",
                c => new
                    {
                        KnowledgeFormId = c.Int(nullable: false, identity: true),
                        ProfPerformance = c.String(),
                        WebGrade = c.Int(nullable: false),
                        MobDevGrade = c.Int(nullable: false),
                        DataScienceGrade = c.Int(nullable: false),
                        WebDesc = c.String(),
                        MobDevDesc = c.String(),
                        DataScienceDesc = c.String(),
                    })
                .PrimaryKey(t => t.KnowledgeFormId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        Login = c.String(nullable: false, maxLength: 100),
                        Pass = c.String(nullable: false, maxLength: 100),
                        DateOfBirth = c.DateTime(),
                        KnowledgeFormId = c.Int(),
                        ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.KnowledgeForms", t => t.KnowledgeFormId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.KnowledgeFormId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReportId, t.ProjectId })
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Users", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Users", "KnowledgeFormId", "dbo.KnowledgeForms");
            DropIndex("dbo.Reports", new[] { "ProjectId" });
            DropIndex("dbo.Users", new[] { "ProjectId" });
            DropIndex("dbo.Users", new[] { "KnowledgeFormId" });
            DropTable("dbo.Reports");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
            DropTable("dbo.KnowledgeForms");
        }
    }
}
