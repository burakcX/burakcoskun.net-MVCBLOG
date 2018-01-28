using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_Entity
{
    [Table("Role")]
    public class Role
    {
        #region Fields
        public int Id { get; set; }

       
        public string Name { get; set; }

        #endregion

        #region Relations
        public List<UserRole> UserRole { get; set; } 
        #endregion
    }
}
