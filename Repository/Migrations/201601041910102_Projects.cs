namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Projects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 300),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectApplicationUsers",
                c => new
                    {
                        Project_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Project_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.UserImages", "Project_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Description", c => c.String());
            AddColumn("dbo.AspNetUsers", "Url", c => c.String(maxLength: 100));
            CreateIndex("dbo.UserImages", "Project_Id");
            AddForeignKey("dbo.UserImages", "Project_Id", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectApplicationUsers", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.UserImages", "Project_Id", "dbo.Projects");
            DropIndex("dbo.ProjectApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ProjectApplicationUsers", new[] { "Project_Id" });
            DropIndex("dbo.UserImages", new[] { "Project_Id" });
            DropColumn("dbo.AspNetUsers", "Url");
            DropColumn("dbo.AspNetUsers", "Description");
            DropColumn("dbo.UserImages", "Project_Id");
            DropTable("dbo.ProjectApplicationUsers");
            DropTable("dbo.Projects");
        }
    }
}
