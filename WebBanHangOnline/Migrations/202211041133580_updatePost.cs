namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePost : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.tb_Post", new[] { "Category_Id" });
            DropColumn("dbo.tb_Post", "CategoryId");
            RenameColumn(table: "dbo.tb_Post", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.tb_Post", "CategoryId", c => c.Int());
            CreateIndex("dbo.tb_Post", "CategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.tb_Post", new[] { "CategoryId" });
            AlterColumn("dbo.tb_Post", "CategoryId", c => c.String());
            RenameColumn(table: "dbo.tb_Post", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.tb_Post", "CategoryId", c => c.String());
            CreateIndex("dbo.tb_Post", "Category_Id");
        }
    }
}
