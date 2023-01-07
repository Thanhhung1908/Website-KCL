using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Banner")]
    public class Banner: CommonAbstract
    {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            [Required(ErrorMessage = "Tiêu Đề không được để trống")]
            [StringLength(150)]
       

        public string Title { get; set; }
            public string Alias { get; set; }
            public string Description { get; set; }
        [Required(ErrorMessage = "Hình ảnh không được để trống")]

        public string Image { get; set; }
            public bool IsActive { get; set; }
            public string LinkLienKet { get; set; }
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        public string BanerTypeID { get; set; }
        public virtual BannerCategory bannerCategory { get; set; }

    }
}