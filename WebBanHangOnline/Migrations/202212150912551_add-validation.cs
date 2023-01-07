namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Banner", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.tb_Banner", "BanerTypeID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Banner", "BanerTypeID", c => c.String());
            AlterColumn("dbo.tb_Banner", "Image", c => c.String());
        }
    }
}
