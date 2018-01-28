using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_Entity
{
    public class Base
    {
        #region Fields
        
        public DateTime? CreatedDate { get; set; }

        
        public DateTime? ModifiedDate { get; set; }

        [StringLength(30)]
        public string CreatedUserName { get; set; }

        [StringLength(30)]
        public string ModifiedUserName { get; set; } 
        #endregion
    }
}
