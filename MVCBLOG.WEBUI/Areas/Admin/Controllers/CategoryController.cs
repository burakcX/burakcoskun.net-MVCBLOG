using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBLOG.BLL.UIServices.Class;
using MVCBLOG.ENTITY.Model_DTO;
using MVCBLOG.ENTITY.Model_Entity;
using MVCBLOG.WEBUI.Filters;

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

        #region Select
        // GET: Admin/Category
        [AuthFilter]
        public ActionResult Index()
        {
            List<CategoryDTO> CategoryDtoList = CategoryUIService.TumListe().OrderByDescending(c => c.CategoryDtoId).ToList();

            return View(CategoryDtoList);
        }
        #endregion

        #region Insert
        [AuthFilter]
        public ActionResult AddCategory()
        {
            return View();
        }

        [AuthFilter]
        [HttpPost]
        public ActionResult AddCategory(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                CategoryDTO CategoryDto = new CategoryDTO()
                {
                    CategoryDtoId = model.CategoryDtoId,
                    NameCategoryDto = model.NameCategoryDto,
                    SeoCategoryDTO = model.SeoCategoryDTO,
                    DescriptionCategoryDto = model.DescriptionCategoryDto,
                    CreatedDateDto = DateTime.Now,
                    CreatedUserNameDto = "burak.coskun",
                    ModifiedDateDto = DateTime.Now,
                    ModifiedUserNameDto = "burak.coskun"
                };

                CategoryUIService.Kayit(CategoryDto);
                ViewBag.islemDurum = "5";
            }

            else
            {
                ViewBag.islemDurum = "6";
            }

            return View();
        }
        #endregion

        #region Update
        [AuthFilter]
        public ActionResult UpdateCategory(int id)
        {
            CategoryDTO CategoryDTO = CategoryUIService.IdIleGetir(id);

            return View(CategoryDTO);
        }

        [HttpPost]
        [AuthFilter]
        public ActionResult UpdateCategory(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                CategoryDTO CategoryDTO = CategoryUIService.IdIleGetir(model.CategoryDtoId);

                model.CreatedUserNameDto = CategoryDTO.CreatedUserNameDto;
                model.CreatedDateDto = CategoryDTO.CreatedDateDto;
                model.ModifiedUserNameDto = ((UserDTO)Session["User"]).UserNameDTO;
                model.ModifiedDateDto=DateTime.Now;

                bool UpdateisOk = CategoryUIService.Guncelle(model);

                ViewBag.islemDurum = "7";
            }

            else
            {
                ViewBag.islemDurum = "8";
            }

            return View();
        }
        #endregion

        #region Delete

        [AuthFilter]
        public ActionResult Delete(int Id)
        {
            CategoryDTO CategoryDto = CategoryUIService.IdIleGetir(Id);

            return View(CategoryDto);
        }

        [AuthFilter]
        [HttpPost]
        public ActionResult Delete(CategoryDTO model)
        {
            bool deleteisOk = CategoryUIService.SilDb(model.CategoryDtoId);

            if (deleteisOk)
            {
                ViewBag.islemDurum = "10";
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}