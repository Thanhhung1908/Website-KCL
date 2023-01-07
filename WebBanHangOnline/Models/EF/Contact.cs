using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    public class Contact:CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Tên không được để trống ")]
        [StringLength(150,ErrorMessage ="không vượt quá 150 kí tự ")]
        public string Name { get; set; }
        [StringLength(150, ErrorMessage = "không vượt quá 150 kí tự ")]

        public string Email { get; set; }
        public string Website { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}