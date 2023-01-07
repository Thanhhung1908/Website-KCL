namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtablebannercategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_BannerCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(maxLength: 150),
                        CreatedBy = c.String(),
                        ModifierBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedrDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Banner",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        LinkLienKet = c.String(),
                        BanerTypeID = c.String(),
                        CreatedBy = c.String(),
                        ModifierBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedrDate = c.DateTime(nullable: false),
                        bannerCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_BannerCategory", t => t.bannerCategory_Id)
                .Index(t => t.bannerCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Banner", "bannerCategory_Id", "dbo.tb_BannerCategory");
            DropIndex("dbo.tb_Banner", new[] { "bannerCategory_Id" });
            DropTable("dbo.tb_Banner");
            DropTable("dbo.tb_BannerCategory");
        }
    }
}
