using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_DTO
{
    public class ContactDTO : BaseDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactIdDTO { get; set; }
        [Required(ErrorMessage = "Lütfen ad kısmını doldurunuz.")]
        [StringLength(20)]
        public string NameDTO { get; set; }
        [Required(ErrorMessage = "Lütfen soyad kısmını doldurunuz.")]
        [StringLength(20)]
        public string SurnameDTO { get; set; }
        [Required(ErrorMessage = "Lütfen eposta kısmını doldurunuz.")]
        [EmailAddress]
        public string EmailDTO { get; set; }
        [Required(ErrorMessage = "Lütfen içerik kısmını doldurunuz.")]
        public string SubjectDTO { get; set; }
        [Required(ErrorMessage = "Lütfen mesaj kısmını doldurunuz.")]
        public string MessageDTO { get; set; }


    }
}
