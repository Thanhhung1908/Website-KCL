namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableFeedback1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Feedback", "IsRespond", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Feedback", "IsRespond");
        }
    }
}
