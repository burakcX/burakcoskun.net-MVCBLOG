using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_DTO
{
    public class LikeDTO : BaseDTO
    {
        #region Fields
        public int IdDto { get; set; }

        [Key, Column(Order = 1)]
        public int PostIdDto { get; set; }

        [Key, Column(Order = 2)]
        public int UserIdDto { get; set; }

        #endregion

        #region Relations

        public virtual PostDTO PostDto { get; set; }

        public virtual UserDTO User { get; set; }

        #endregion


    }
}
