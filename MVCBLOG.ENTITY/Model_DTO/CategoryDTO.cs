using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCBLOG.ENTITY.Model_DTO
{
    public class CategoryDTO : BaseDTO
    {
        #region Fields
        public int CategoryDtoId { get; set; }
        public string NameCategoryDto { get; set; }
        public string DescriptionCategoryDto { get; set; }

        #endregion

        #region Relations
        public virtual List<PostDTO> PostDtoList { get; set; }
        #endregion



    }
}
