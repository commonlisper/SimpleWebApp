using System.Data.Entity.Migrations;

namespace SimpleWebApp.DAL.Migrations
{
    public partial class AddAttributeToDto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Title", c => c.String());
            AlterColumn("dbo.Articles", "Url", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Url", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "Title", c => c.String(nullable: false));
        }
    }
}
