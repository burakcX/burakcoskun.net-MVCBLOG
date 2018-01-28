using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MVCBLOG.BLL.UIServices.Class;
using MVCBLOG.ENTITY.Model_DTO;
using MVCBLOG.ENTITY.Model_Object;
using MVCBLOG.WEBUI.Areas.Admin.Services;
using MVCBLOG.WEBUI.Filters;

namespace MVCBLOG.WEBUI.Areas.Admin.Controllers
{
    [ValidateInput(false)]
    public class PostController : Controller
    {
        #region Değişkenler
        private readonly PostUIService PostUIService;
        private readonly AdminUIService AdminUIService;
        private readonly CategoryUIService CategoryUIService;
        
        #endregion

        #region ctor
        public PostController()
        {
            PostUIService = new PostUIService();
            AdminUIService = new AdminUIService();
            CategoryUIService = new CategoryUIService();
        }
        #endregion
        
        #region Select
        [AuthFilter]
        public ActionResult Index()
        {
            List<PostDTO> PostDtoList = PostUIService.TumListe().OrderByDescending(x => x.CreatedDateDto).ToList();

            return View(PostDtoList);
        } 
        #endregion

        #region Insert
        [AuthFilter]
        public ActionResult AddPost()
        {
            //ViewBag.ListmodelCtg = new SelectList(ListmodelCtg, "CategoryDtoId", "NameCategoryDto");

            return View();
        }

        [AuthFilter]
        [HttpPost]
        public ActionResult AddPost(PostViewModel model)
        {

            if (ModelState.IsValid)
            {
                model.UserId = ((UserDTO)Session["User"]).IdDTO;
                model.CreatedUserName = ((UserDTO)Session["User"]).UserNameDTO;
                model.ModifiedUserName = ((UserDTO)Session["User"]).UserNameDTO;
                PostUIService.AddPost(model);

                ViewBag.IslemDurum = "1";
            }

            else
            {
                ViewBag.IslemDurum = "2";
            }

            return View();
        } 
        #endregion

        #region Update
        public ActionResult Update(int Id)
        {
            PostDTO PostDto = PostUIService.PostGetirIdIle(Id);

            PostViewModel pvm = new PostViewModel()
            {
                PostId = PostDto.PostDtoId,
                Title = PostDto.TitleDto,
                CategoryId = PostDto.CategoryDtoId,
                Seolink = PostDto.SeolinkDto,
                Content = PostDto.ContentDto
            };

            return View(pvm);
        }
        
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                PostDTO PostDto= PostUIService.PostGetirIdIle(model.PostId);

                model.CreatedUserName = PostDto.CreatedUserNameDto;
                model.ModifiedUserName= ((UserDTO)Session["User"]).UserNameDTO;

                bool UpdateOk = PostUIService.UpdatePost(model);

                if (UpdateOk)
                {
                    ViewBag.IslemDurum = "3";
                }
                else
                {
                    ViewBag.IslemDurum = "4";
                }

            }

            return View();
        }
        #endregion

        #region Delete

        [AuthFilter]
        public ActionResult Delete(int Id)
        {
            PostDTO PostDto = PostUIService.PostGetirIdIle(Id);

            PostViewModel pvm = new PostViewModel()
            {
                PostId = PostDto.PostDtoId,
                Title = PostDto.TitleDto,
                Content = PostDto.ContentDto
            };
            
            return View(pvm);
        }
        
        [HttpPost]
        [AuthFilter]
        public ActionResult Delete(PostViewModel model)
        {
            bool deleteisOk = PostUIService.SilDb(model.PostId);

            if (deleteisOk)
            {
               
                ViewBag.islemDurum = "9";
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}