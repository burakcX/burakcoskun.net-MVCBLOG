using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBLOG.BLL.UIServices.Class;
using MVCBLOG.ENTITY.Model_DTO;

namespace MVCBLOG.WEBUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        #region Değişkenler
        private readonly CategoryUIService CategoryUIService;
        #endregion

        #region ctor
        public CategoryController()
        {
            CategoryUIService = new CategoryUIService();
        }
        #endregion

        // GET: Admin/Category
        public ActionResult Index()
        {
            List<CategoryDTO> CategoryDtoList = CategoryUIService.TumListe().OrderByDescending(c => c.CategoryDtoId).ToList();

            return View(CategoryDtoList);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            CategoryDTO CategoryDTO = CategoryUIService.IdIleGetir(id);
            
            return View(CategoryDTO);
        }

        [HttpPost]
        public ActionResult UpdateCategory()
        {
            return View();
        }
    }
}