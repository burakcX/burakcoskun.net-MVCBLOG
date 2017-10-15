using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBLOG.ENTITY.Model_Object
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı kısmını doldurunuz."), StringLength(25)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre kısmını doldurunuz.")]
        public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }


    }
}