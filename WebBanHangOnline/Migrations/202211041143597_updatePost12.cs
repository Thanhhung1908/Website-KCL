namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePost12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Post", "Alias", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Post", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.tb_Post", "Image", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.tb_Post", "SeoTitle", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.tb_Post", "SeoDescription", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.tb_Post", "SeoKeywords", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Post", "SeoKeywords", c => c.String());
            AlterColumn("dbo.tb_Post", "SeoDescription", c => c.String());
            AlterColumn("dbo.tb_Post", "SeoTitle", c => c.String());
            AlterColumn("dbo.tb_Post", "Image", c => c.String());
            AlterColumn("dbo.tb_Post", "Description", c => c.String());
            AlterColumn("dbo.tb_Post", "Alias", c => c.String());
        }
    }
}
