namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccSystemDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KnowledgeForm",
                c => new
                    {
                        KnowledgeFormId = c.Int(nullable: false, identity: true),
                        ProfPerformance = c.String(),
                        WebGrade = c.Int(nullable: false),
                        MobDevGrade = c.Int(nullable: false),
                        DataScienceGrade = c.Int(nullable: false),
                        WebDesc = c.String(),
                        MobDevDesc = c.String(),
                        DataScienceDesc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KnowledgeFormId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        KnowledgeFormId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        Login = c.String(nullable: false, maxLength: 100),
                        Pass = c.String(nullable: false, maxLength: 100),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.KnowledgeFormId, t.ProjectId })
                .ForeignKey("dbo.KnowledgeForm", t => t.KnowledgeFormId, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.KnowledgeFormId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReportId, t.ProjectId })
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Report", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.User", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.User", "KnowledgeFormId", "dbo.KnowledgeForm");
            DropIndex("dbo.Report", new[] { "ProjectId" });
            DropIndex("dbo.User", new[] { "ProjectId" });
            DropIndex("dbo.User", new[] { "KnowledgeFormId" });
            DropTable("dbo.Report");
            DropTable("dbo.User");
            DropTable("dbo.Project");
            DropTable("dbo.KnowledgeForm");
        }
    }
}
