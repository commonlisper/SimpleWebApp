namespace SimpleWebApp.CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleAddRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "Url", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Url", c => c.String());
            AlterColumn("dbo.Articles", "Title", c => c.String());
        }
    }
}
