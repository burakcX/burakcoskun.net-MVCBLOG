using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCBLOG.ENTITY.Model_DTO
{
    public class PostDTO : BaseDTO
    {
        #region Fields
        public int PostDtoId { get; set; }

        [Required(ErrorMessage = "Lütfen Başlık kısmını doldurunuz."), StringLength(100)]
        public string TitleDto { get; set; }
        
        public string SeolinkDto { get; set; }

        [Required(ErrorMessage = "Lütfen İçerik kısmını doldurunuz.")]
        public string ContentDto { get; set; }

        public int ViewCountDto { get; set; }
        public int LikeCountDto { get; set; }

        public int CategoryDtoId { get; set; }
        public int UserDtoId { get; set; }

        #endregion

        #region Relations
        public virtual CategoryDTO CategoryDTO { get; set; }
        public virtual UserDTO UserDTO { get; set; }
        public virtual List<TagDTO> TagDtoList { get; set; }
        public virtual List<CommentDTO> CommentDtoList { get; set; }
        public virtual List<LikeDTO> PostLikeDtoList { get; set; }
        #endregion


    }
}
