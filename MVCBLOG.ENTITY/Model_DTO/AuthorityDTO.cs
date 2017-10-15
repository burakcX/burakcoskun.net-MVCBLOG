using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_DTO
{
    public class AuthorityDTO
    {
        #region Fields
        public int IdDTO { get; set; }
        public string NameDTO { get; set; }
        #endregion

        #region Relations
        public virtual List<UserAuthorityDTO> UserAuthorityDTO { get; set; }
        #endregion

    }
}
