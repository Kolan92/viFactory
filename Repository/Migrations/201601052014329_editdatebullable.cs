namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editdatebullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "EditDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "EditDate", c => c.DateTime(nullable: false));
        }
    }
}
