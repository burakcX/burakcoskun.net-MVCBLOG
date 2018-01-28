using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_Entity
{
    [Table("Tag")]
    public class Tag
    {
        #region Fields
        public int Id { get; set; }

       
        public string Name { get; set; }
        
        #endregion

        #region Relations
        public virtual Post Post { get; set; }
        public int PostId { get; set; }

        #endregion

    }
}
