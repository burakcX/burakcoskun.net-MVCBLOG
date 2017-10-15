using MVCBLOG.BLL.UIServices.Class;
using MVCBLOG.BLL.UIServices.Interface;
using MVCBLOG.ENTITY.Model_DTO;
using MVCBLOG.ENTITY.Model_Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using MVCBLOG.BLL.Managers;
using MVCBLOG.ENTITY.Model_Object;
using MVCBLOG.WEBUI.ViewModel;
using Image = System.Drawing.Image;

namespace MVCBLOG.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        #region Değişkenler
        private readonly PostUIService PostUIService;
        private readonly CategoryUIService CategoryUIService;
        private readonly AdminUIService AdminUIService;
        UserManager um = new UserManager();
        #endregion

        #region ctor
        public HomeController()
        {
            PostUIService = new PostUIService();
            CategoryUIService = new CategoryUIService();
            AdminUIService = new AdminUIService();
        }
        #endregion

        #region Metodlar

        public ActionResult Index()
        {
            List<PostDTO> PostDTOList = PostUIService.TumListe().ToList();

            return View(PostDTOList);
        }

        public ActionResult PostByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<PostDTO> PostDtoList = PostUIService.PostListeleCatIdIle(id.Value);
            ViewBag.CategoryName = "";
            if (PostDtoList.Count > 0)
            {
                ViewBag.CategoryName = PostDtoList.FirstOrDefault().CategoryDTO.NameCategoryDto;
            }

            if (PostDtoList == null)
            {
                return HttpNotFound();
            }

            return View(PostDtoList);
        }

        public ActionResult CaptchaImage(string prefix, bool noisy = true)
        {
            int i, r, x, y;
            var rand = new Random((int)DateTime.Now.Ticks);
            int a = rand.Next(10, 99);
            int b = rand.Next(0, 9);
            var captcha = string.Format("{0} + {1} = ?", a, b);
            Session["Captcha"] = a + b;
            FileContentResult img = null;
            using (var mem = new MemoryStream())
            using (var bmp = new Bitmap(130, 30))
            using (var gfx = Graphics.FromImage((Image)bmp))
            {
                gfx.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.FillRectangle(Brushes.White, new Rectangle(0, 0, bmp.Width, bmp.Height));
                if (noisy)
                {
                    var pen = new Pen(Color.Yellow);
                    for (i = 1; i < 10; i++)
                    {
                        pen.Color = Color.FromArgb((rand.Next(0, 255)), (rand.Next(0, 255)), (rand.Next(0, 255)));
                        r = rand.Next(0, (130 / 3));
                        x = rand.Next(0, 130);
                        y = rand.Next(0, 30);
                    }
                }
                gfx.DrawString(captcha, new Font("Tahoma", 15), Brushes.Gray, 2, 3);
                bmp.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                img = this.File(mem.GetBuffer(), "image/Jpeg");
            }
            return img;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            Session["UserName"] = null;

            if (ModelState.IsValid)
            {
                um.LoginUser(model, GetIp());

                UserDTO UserDto = AdminUIService.AdGetirKullaniciAdiIle(model);

                Session["UserName"] = model.UserName;
                Session["User"] = UserDto;
                //Session["AdSoyad"] = UserDto.NameDTO + " " + UserDto.SurnameDTO;


                //if (
                //    AdminUIService.TumListe()
                //        .Any(x => x.UserNameDTO == model.UserName && x.PasswordDTO == model.Password))
                //    //Bu kısıma login kontrolü eklenecek.. https://www.youtube.com/watch?v=rbpxtfBIKgw&t=1s 1:32:00
                //{
                //    FormsAuthentication.SetAuthCookie(model.UserName, true);
                //        //Login olduktan sonra kullanıcı bilgisini cookie de saklayarak başka sayfalarda kullanacağız.
                //    return RedirectToAction("Index", "Panel", new {area = "Admin"});
                //        //Login olduktan sonra yönlendirme işlemi yapıyoruz.
                //}

                if (Session["User"] != null)
                {
                    return RedirectToAction("Index", "Panel", new { area = "Admin" });
                }

            }

            return View(model);

        }


        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Logoffok", "Home");
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                um.RegisterUser(model, GetIp());

                //if (model.UserName=="a@a.com")
                //{
                //    ModelState.AddModelError("", "Kullanıcı adı kullanılıyor.");
                //}

                return RedirectToAction("Registerok");
            }

            return View(model);
        }

        public ActionResult Registerok()
        {
            return View();
        }

        public ActionResult Logoffok()
        {
            return View();
        }
        #endregion

        #region YardımcıMetodlar

        private string GetIp()
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }

        #endregion
    }
}