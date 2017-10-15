using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_Entity
{
    [Table("User")]
    public class User : Base
    {
        #region Fields

        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Ad kısmını doldurunuz."), StringLength(25)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadı kısmını doldurunuz."), StringLength(25)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adı kısmını doldurunuz."), StringLength(25)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen E-posta adresi kısmını doldurunuz."), StringLength(25)]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre kısmını doldurunuz.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Girmiş olduğunuz şifreler eşleşmemektedir. Lütfen kontrol ediniz.")]
        public string RePassword { get; set; }

        [StringLength(30)]
        public string ProfileImageFilename { get; set; }

        public bool IsActive { get; set; }

        public Guid ActivateGuid { get; set; }

        public int Type { get; set; }

        public string Ip { get; set; }

        #endregion

        #region Relations
        public virtual List<Post> UserPosts { get; set; }
        public virtual List<UserAuthority> UserAuthority { get; set; }
        public virtual List<Like> Userlike { get; set; }
        public virtual List<Comment> Comments { get; set; }
        #endregion

    }
}
