using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("WebBanHangOnline", throwIfV1Schema: false)
        {
        }
        public DbSet<Category> Categories{get;set;}
        public DbSet<Feedback> feedbacks{get;set;}
        public DbSet<Adv> Advs{get;set;}
        public DbSet<Post> Posts{get;set;}
        public DbSet<New> News{get;set;}
        public DbSet<SystemSetting> SystemSettings{get;set;}
        public DbSet<ProductCategory> ProductCategories{get;set;}
        public DbSet<BannerCategory> bannerCategories{get;set;}
        public DbSet<Banner> banners{get;set;}
        public DbSet<Product> Products{get;set;}
        public DbSet<Contact> Contacts{get;set;}
        public DbSet<Order> Orders{get;set;}
        public DbSet<ProductImage> productImages{get;set;}
        public DbSet<OrderDetail> OrderDetails{get;set;}
        public DbSet<Subscribe> Subscribes{get;set;}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}