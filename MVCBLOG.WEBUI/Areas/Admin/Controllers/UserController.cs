using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBLOG.BLL.UIServices.Class;
using MVCBLOG.ENTITY.Model_DTO;
using MVCBLOG.ENTITY.Model_Entity;
using MVCBLOG.ENTITY.Model_Object;

namespace MVCBLOG.WEBUI.Areas.Admin.Controllers
{
    public class UserController : Controller
    {

        #region Değişkenler

        private readonly UserUIService UserUIService;

        #endregion

        public UserController()
        {
            UserUIService=new UserUIService();
        }

        // GET: Admin/User
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserDTO Model)
        {
            string IP = "127.0.0.1";

            RegisterViewModel UserViewModel = new RegisterViewModel()
            {
                Name = Model.NameDTO,
                Surname = Model.SurnameDTO,
                EMail = Model.EMailDTO,
                UserName = Model.UserNameDTO,
                Password = Model.PasswordDTO,
                RePassword = Model.RePasswordDTO,
                isActive = Model.IsActiveDto
            };

            UserUIService.RegisterUser(UserViewModel, IP);
            
            return View();
        }
    }
}