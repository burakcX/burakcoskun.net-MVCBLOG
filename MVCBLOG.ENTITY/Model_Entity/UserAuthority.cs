using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_Entity
{
    [Table("UserAuthority")]
    public class UserAuthority
    {
        #region Fields
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        public int UserId { get; set; }

        [Key, Column(Order = 2)]
        public int AuthorityId { get; set; }
        #endregion

        #region Relations

        public User User { get; set; }
        public Authority Authority { get; set; }

        #endregion

    }
}
