using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_Entity
{
    [Table("Like")]
    public class Like : Base

    {
        #region Fields
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #endregion

        #region Relations

        public virtual Post Post { get; set; }
        public virtual User LikedUser { get; set; }


        #endregion



    }
}
