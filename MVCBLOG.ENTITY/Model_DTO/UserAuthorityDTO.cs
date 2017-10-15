using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBLOG.ENTITY.Model_Entity;

namespace MVCBLOG.ENTITY.Model_DTO
{
    public class UserAuthorityDTO
    {
        #region Fields
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDto { get; set; }
        [Key, Column(Order = 1)]
        public int UserIdDto { get; set; }
        [Key, Column(Order = 2)]
        public int AuthorityIdDto { get; set; }
        #endregion

        #region Relations

        public UserDTO User { get; set; }
        public AuthorityDTO Authority { get; set; }

        #endregion  

    }
}
