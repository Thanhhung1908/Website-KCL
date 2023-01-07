namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNews1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_New", "Category_Id", "dbo.tb_Category");
            DropIndex("dbo.tb_New", new[] { "Category_Id" });
            DropColumn("dbo.tb_New", "CategoryId");
            RenameColumn(table: "dbo.tb_New", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.tb_New", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_New", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_New", "CategoryId");
            AddForeignKey("dbo.tb_New", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_New", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_New", new[] { "CategoryId" });
            AlterColumn("dbo.tb_New", "CategoryId", c => c.Int());
            AlterColumn("dbo.tb_New", "CategoryId", c => c.String());
            RenameColumn(table: "dbo.tb_New", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.tb_New", "CategoryId", c => c.String());
            CreateIndex("dbo.tb_New", "Category_Id");
            AddForeignKey("dbo.tb_New", "Category_Id", "dbo.tb_Category", "Id");
        }
    }
}
