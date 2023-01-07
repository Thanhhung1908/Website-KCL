namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_New", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_New", "ModifierBy", c => c.String());
            AddColumn("dbo.tb_New", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_New", "ModifiedrDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_New", "ModifiedrDate");
            DropColumn("dbo.tb_New", "CreatedDate");
            DropColumn("dbo.tb_New", "ModifierBy");
            DropColumn("dbo.tb_New", "CreatedBy");
        }
    }
}
