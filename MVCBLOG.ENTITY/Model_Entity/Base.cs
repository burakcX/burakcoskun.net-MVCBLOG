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
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]
        public string CreatedUserName { get; set; }

        [Required, StringLength(30)]
        public string ModifiedUserName { get; set; } 
        #endregion
    }
}
