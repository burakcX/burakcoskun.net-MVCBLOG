using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_Object
{
    public class PostViewModel
    {
        #region Variables

        public int PostId { get; set; }

        [Required(ErrorMessage = "Lütfen Başlık kısmını doldurunuz."), StringLength(300)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen Kategori seçiniz.")]
        public int CategoryId { get; set; }

        public string Seolink { get; set; }

        [Required(ErrorMessage = "Lütfen İçerik kısmını doldurunuz.")]
        public string Content { get; set; }

        public int ViewCount { get; set; }

        public int UserId { get; set; }
        public string CreatedUserName { get; set; }
        public string ModifiedUserName { get; set; }
        
        #endregion

        #region Relations

        #endregion

    }
}
