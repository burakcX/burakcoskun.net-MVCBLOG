using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MVCBLOG.BLL.UIServices.Class;
using MVCBLOG.ENTITY.Model_DTO;

namespace MVCBLOG.WEBUI.Areas.Admin.Services
{
    public class DrpServices
    {
        #region Değişkenler
        private readonly CategoryUIService CategoryUIService;
        #endregion

        #region ctor
        public DrpServices()
        {
            CategoryUIService = new CategoryUIService();
        }
        #endregion

        #region Metodlar
        public IEnumerable<SelectListItem> getDrpCategories()
        {
            IEnumerable<SelectListItem> DrpCategories = CategoryUIService.TumListe().Select(x => new SelectListItem()
            {
                Text = x.NameCategoryDto,
                Value = x.CategoryDtoId.ToString()
            }).ToList();

            return DrpCategories;
        }
        #endregion


    }
}