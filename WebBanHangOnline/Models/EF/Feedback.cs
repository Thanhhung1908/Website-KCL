using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{

    [Table("tb_Feedback")]
    public class Feedback:CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tiêu Đề không được để trống")]
        [StringLength(150)]


        public string CusName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContentFeedback { get; set; }
        public bool IsRespond { get; set; }

    }
}