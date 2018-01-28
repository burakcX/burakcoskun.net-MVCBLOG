using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBLOG.ENTITY.Model_Object
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Ad kısmını doldurunuz."), StringLength(25)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadı kısmını doldurunuz."), StringLength(25)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adı kısmını doldurunuz."), StringLength(25)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen E-posta adresi kısmını doldurunuz."), StringLength(25)]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre kısmını doldurunuz."),
        //RegularExpression("(?=.*[a-z])(?=.*[A-Z])", ErrorMessage = "Şifreniz en az 1 küçük ve 1 büyük harf içermelidir."),
        StringLength(25, ErrorMessage = "Girmiş olduğunuz şifre 5 ile 20 karakter arası olmalıdır.", MinimumLength = 5)]
        public string Password { get; set; }

        [DataType(DataType.Password),
        Required(ErrorMessage = "Lütfen Şifre tekrar kısmını doldurunuz."),
        Compare("Password", ErrorMessage = "Girmiş olduğunuz şifreler eşleşmemektedir.")]
        public string RePassword { get; set; }

        public bool isActive { get; set; }

    }
}