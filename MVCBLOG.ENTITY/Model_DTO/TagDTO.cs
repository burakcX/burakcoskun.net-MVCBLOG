using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_DTO
{
    public class TagDTO
    {
        #region Fields
        public int IdDto { get; set; }
        public string NameDto { get; set; }

        #endregion

        #region Relations
        public virtual PostDTO PostDto { get; set; }
        public int PostIdDto { get; set; }

        #endregion


    }
}
