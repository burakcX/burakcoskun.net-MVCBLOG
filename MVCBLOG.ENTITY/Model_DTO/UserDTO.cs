using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_DTO
{
    public class UserDTO : BaseDTO
    {
        #region Fields

        public int IdDTO { get; set; }

        [Required(ErrorMessage = "Lütfen Ad kısmını doldurunuz."), StringLength(25)]
        public string NameDTO { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadı kısmını doldurunuz."), StringLength(25)]
        public string SurnameDTO { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adı kısmını doldurunuz."), StringLength(25)]
        public string UserNameDTO { get; set; }

        [Required(ErrorMessage = "Lütfen E-posta adresi kısmını doldurunuz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string EMailDTO { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre kısmını doldurunuz.")]
        public string PasswordDTO { get; set; }

        [Compare("PasswordDTO", ErrorMessage = "Girmiş olduğunuz şifreler eşleşmemektedir. Lütfen kontrol ediniz.")]
        public string RePasswordDTO { get; set; }

        [StringLength(30)]
        public string ProfileImageFilenameDto { get; set; }

        public bool IsActiveDto { get; set; }

        public Guid ActivateGuidDto { get; set; }

        public int TypeDTO { get; set; }

        public string IpDTO { get; set; }

        #endregion

        #region Relations
        public virtual List<PostDTO> UserPostDtoList { get; set; }
        public virtual List<UserRoleDTO> UserRoleDtoList { get; set; }
        public virtual List<LikeDTO> UserlikeDtoList { get; set; }
        public virtual List<CommentDTO> CommentsDtoList { get; set; }
        #endregion
    }
}
