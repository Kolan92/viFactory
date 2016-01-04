namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        News_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.News", t => t.News_Id)
                .Index(t => t.News_Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 300),
                        Content = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        EditDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Avatar_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Avatar_Id");
            AddForeignKey("dbo.AspNetUsers", "Avatar_Id", "dbo.UserImages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Avatar_Id", "dbo.UserImages");
            DropForeignKey("dbo.UserImages", "News_Id", "dbo.News");
            DropIndex("dbo.AspNetUsers", new[] { "Avatar_Id" });
            DropIndex("dbo.News", new[] { "User_Id" });
            DropIndex("dbo.UserImages", new[] { "News_Id" });
            DropColumn("dbo.AspNetUsers", "Avatar_Id");
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.News");
            DropTable("dbo.UserImages");
        }
    }
}
