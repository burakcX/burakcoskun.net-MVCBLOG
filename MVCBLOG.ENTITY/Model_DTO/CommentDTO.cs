using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_DTO
{

    public class CommentDTO : BaseDTO
    {
        #region Fields
        public int IdDto { get; set; }
        public string ContentDto { get; set; }

        #endregion

        #region Relations
        public virtual PostDTO PostDto { get; set; }
        public virtual UserDTO UserDto { get; set; }

        #endregion
    }
}
