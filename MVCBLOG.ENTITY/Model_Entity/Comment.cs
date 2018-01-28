using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_Entity
{
    [Table("Comment")]
    public class Comment : Base
    {
        #region Fields
        public int Id { get; set; }

        
        public string Content { get; set; }

        #endregion

        #region Relations
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        #endregion

    }
}
