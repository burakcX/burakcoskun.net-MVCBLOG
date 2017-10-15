using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_Entity
{
    [Table("Authority")]
    public class Authority
    {
        #region Fields
        public int Id { get; set; }
        
        public string Name { get; set; }

        #endregion

        #region Relations
        public List<UserAuthority> UserAuthority { get; set; } 
        #endregion
    }
}
