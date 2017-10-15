using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBLOG.BLL.UIServices.Class;
using MVCBLOG.ENTITY.Model_DTO;
using MVCBLOG.WEBUI.ViewModel;

namespace MVCBLOG.WEBUI.Controllers
{
    public class PartialsController : Controller
    {
        #region Değişkenler
        private readonly CategoryUIService CategoryUIService;
        private readonly PostUIService PostUIService;
        #endregion

        #region ctor
        public PartialsController()
        {
            CategoryUIService = new CategoryUIService();
            PostUIService = new PostUIService();
        }
        #endregion

        #region Metodlar

        public PartialViewResult AllCategories()
        {
            List<CounterViewModel> CmList = new List<CounterViewModel>();

            List<CategoryDTO> catList = CategoryUIService.TumListe();

            foreach (CategoryDTO item in catList)
            {
                CounterViewModel cm = new CounterViewModel()
                {
                    KategoriAdi = item.NameCategoryDto,
                    KategoridekiPostSayisi = item.PostDtoList.Count(),
                    CatId = item.CategoryDtoId,
                    CatDesc = item.DescriptionCategoryDto
                };
                CmList.Add(cm);
            }
            return PartialView(CmList);
        }

        public PartialViewResult RecentPosts()
        {
            List<PostDTO> PostDtoList = PostUIService.TumListe().OrderByDescending(c => c.PostDtoId).ToList();

            return PartialView(PostDtoList);
        }
        #endregion
    }
}