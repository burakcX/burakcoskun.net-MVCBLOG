using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.ENTITY.Model_Entity
{
    [Table("Category")]
    public class Category : Base
    {
        #region Fields
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Kategori Başlığı kısmını doldurunuz."), StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Açıklama kısmını doldurunuz."), StringLength(200)]
        public string Description { get; set; }
        #endregion

        #region Relations
        public virtual List<Post> Posts { get; set; }
        #endregion
    }
}
