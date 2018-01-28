using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_Entity
{
    [Table("Contact")]
    public class Contact:Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }
        [Required(ErrorMessage = "Lütfen ad kısmını doldurunuz.")]
        [StringLength(20)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen soyad kısmını doldurunuz.")]
        [StringLength(20)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Lütfen eposta kısmını doldurunuz.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen içerik kısmını doldurunuz.")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Lütfen mesaj kısmını doldurunuz.")]
        public string Message { get; set; }
    }

}
