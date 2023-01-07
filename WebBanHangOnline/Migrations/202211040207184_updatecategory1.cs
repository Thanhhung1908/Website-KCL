namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecategory1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Category", "Position", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Category", "Position", c => c.Int(nullable: false));
        }
    }
}
