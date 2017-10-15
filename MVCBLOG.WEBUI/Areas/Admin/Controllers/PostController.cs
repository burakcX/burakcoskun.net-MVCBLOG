using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBLOG.BLL.UIServices.Class;
using MVCBLOG.ENTITY.Model_DTO;
using MVCBLOG.WEBUI.Areas.Admin.Services;

namespace MVCBLOG.WEBUI.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        #region Değişkenler
        private readonly PostUIService PostUIService;
        #endregion

        #region ctor
        public PostController()
        {
            PostUIService = new PostUIService();
        }
        #endregion


        // GET: Admin/Post
        public ActionResult Index()
        {
            List<PostDTO> PostDtoList = PostUIService.TumListe().OrderByDescending(x => x.CreatedDateDto).ToList();

            return View(PostDtoList);
        }

        public ActionResult AddPost()
        {
            PostDTO model = new PostDTO();
            //model.drpCategories = DrpServices.getDrpCategories();

            return View(model);

        }
    }
}