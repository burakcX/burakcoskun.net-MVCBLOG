using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_DTO
{
    public class BaseDTO
    {
        #region Fields
        public DateTime CreatedDateDto { get; set; }
        public DateTime ModifiedDateDto { get; set; }
        public string CreatedUserNameDto { get; set; }
        public string ModifiedUserNameDto { get; set; } 
        #endregion
    }
}
