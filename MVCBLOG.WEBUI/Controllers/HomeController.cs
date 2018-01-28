using MVCBLOG.BLL.UIServices.Class;
using MVCBLOG.BLL.UIServices.Interface;
using MVCBLOG.ENTITY.Model_DTO;
using MVCBLOG.ENTITY.Model_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MVCBLOG.BLL;
using MVCBLOG.ENTITY.Model_Object;
using MVCBLOG.WEBUI.Filters;
using MVCBLOG.WEBUI.Models;
using MVCBLOG.WEBUI.ViewModel;
using Newtonsoft.Json;
using Image = System.Drawing.Image;
using PagedList;
using PagedList.Mvc;

namespace MVCBLOG.WEBUI.Controllers
{
    
    public class HomeController : Controller
    {
        #region Değişkenler

        private readonly PostUIService PostUIService;
        private readonly CategoryUIService CategoryUIService;
        private readonly AdminUIService AdminUIService;
        private readonly UserUIService UserUIService;
        private readonly ContactUIService ContactUIService;
        private readonly FileUIService FileUIService;

        #endregion

        #region ctor
        public HomeController()
        {
            PostUIService = new PostUIService();
            CategoryUIService = new CategoryUIService();
            AdminUIService = new AdminUIService();
            UserUIService = new UserUIService();
            ContactUIService = new ContactUIService();
            FileUIService = new FileUIService();

        }

        #endregion

        #region Metodlar

        [HandleError()]
        public ActionResult Index(int? SayfaNo)
        {
            try
            {
                int _sayfaNo = SayfaNo ?? 1;
                var PostDTOList = PostUIService.TumListe().OrderByDescending(x => x.CreatedDateDto).ToPagedList<PostDTO>(_sayfaNo, 10);

                return View(PostDTOList);
            }
            catch (Exception ex)
            {

                throw new Exception("Hata!");
            }

        }

        public ActionResult PostDetail(string seolink)
        {
            PostDTO PostDto = PostUIService.PostDetayGetirSeoLinkIle(seolink);
            bool OkunmaSayiArttir = PostUIService.OkunmaSayisiArttir(PostDto);
            PostDTO PostDtoYeni = PostUIService.PostDetayGetirSeoLinkIle(seolink);

            return View(PostDto);
        }

        public ActionResult PostDetails(int Id)
        {
            PostDTO PostDto = PostUIService.PostDetayGetirIdIle(Id);
            bool OkunmaSayiArttir = PostUIService.OkunmaSayisiArttir(PostDto);
            PostDTO PostDtoYeni = PostUIService.PostDetayGetirIdIle(Id);

            return View(PostDtoYeni);
        }

        public ActionResult PostByCategoryUrl(string SeoLinkUrl)
        {
            if (SeoLinkUrl == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<PostDTO> PostDtoList = PostUIService.PostListeleCatSeoLinkIle(SeoLinkUrl);
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            Session["UserName"] = null;

            var response = Request["g-recaptcha-response"];
            const string secret = "6LcnKzYUAAAAANk0wuVl-2l1eA9OEPAPMEbzXp-u";
            //Kendi Secret keyinizle değiştirin.

            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            if (ModelState.IsValid)
            {
                if (!captchaResponse.Success)
                    TempData["Message"] = "Lütfen güvenliği doğrulayınız.";
                else
                    TempData["Message"] = "Güvenlik başarıyla doğrulanmıştır.";

                BusinessLayerResult<User> ResLogin = UserUIService.LoginUser(model, GetIp());

                UserDTO UserDto = AdminUIService.AdGetirKullaniciAdiIle(model);

                if (ResLogin.Errors.Count > 0)
                {
                    foreach (string item in ResLogin.Errors)
                    {
                        ModelState.AddModelError("", item);
                    }

                    return View(model);
                }

                Session["UserName"] = model.UserName;
                Session["User"] = UserDto;
                //Session["AdSoyad"] = UserDto.NameDTO + " " + UserDto.SurnameDTO;

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
                BusinessLayerResult<User> res = UserUIService.RegisterUser(model, GetIp());

                if (res.Errors.Count > 0)
                {
                    foreach (string item in res.Errors)
                    {
                        ModelState.AddModelError("", item);
                    }

                    return View(model);
                }

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

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public class Mesaj
        {
            public string param1 { get; set; }
            public string param2 { get; set; }
        }

        [HttpPost]
        public ActionResult Contact(ContactDTO model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    model.CreatedUserNameDto = "Misafir Kullanıcı";
                    model.ModifiedUserNameDto = "Misafir Kullanıcı";
                    model.CreatedDateDto = DateTime.Now;
                    model.ModifiedDateDto = DateTime.Now;

                    bool insertok = ContactUIService.Insert(model);

                    if (insertok)
                    {
                        Mesaj msj = new Mesaj()
                        {
                            param1 = "200",
                            param2 = "You have enter correct date !!!"
                        };

                        ModelState.Clear();

                        //return View(new ContactDTO());
                        return Json(msj, JsonRequestBehavior.AllowGet);
                    }
                }
            }

            else
            {
                Mesaj msj = new Mesaj()
                {

                    param1 = "404",
                    param2 = "Exception occured while converting user date"
                };

                return Json(msj, JsonRequestBehavior.DenyGet);
            }

            return View();
        }

        [HttpPost]
        public ActionResult SearchPost(string deger)
        {
            List<PostDTO> PostDTOList = PostUIService.TumListe().ToList();

            var sonuc = (from r in PostDTOList
                         where r.TitleDto.ToLower().Contains(deger.ToLower())
                         select new { r.TitleDto }).Distinct();
            return this.Json(sonuc,
                         JsonRequestBehavior.AllowGet);

        }


        public ActionResult AramaSonucu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AramaSonucu(string aranankelime)
        {
            List<PostDTO> PostDtoList = PostUIService.PostGetirBaslikIle(aranankelime);

            ViewBag.aranankelime = aranankelime;
            return View(PostDtoList);
        }

        public ActionResult FaydaliBilgiler()
        {
            return View();
        }
        public ActionResult Calismalarim()
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

        public void SendEmail(ContactDTO model)
        {
            MailMessage msz = new MailMessage();
            msz.From = new MailAddress("burakc34@gmail.com");

            msz.To.Add("burakc34@gmail.com");
            msz.Subject = model.SubjectDTO;
            msz.Body = model.MessageDTO;
            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";

            smtp.Port = 587;

            smtp.Credentials = new System.Net.NetworkCredential
            ("burakc34@gmail.com", "82burak82");

            smtp.EnableSsl = true;

            smtp.Send(msz);

        }

        #endregion

        #region Site İçi Örnekler

        public ActionResult getDataIndex()
        {
            return View();
        }

        public PartialViewResult getData()
        {
            List<string> Malzeme = new List<string>()
            {
                "Cekmece","Kalem","Dolap","Pencere"
            };

            System.Threading.Thread.Sleep(1000);

            return PartialView("_veriGetirPartialView", Malzeme);
        }

        //[HttpPost]
        //public ActionResult Dropzone(FileDTO model)
        //{

        //    if (Request.Files.Count > 0)
        //    {
        //        var Durum = true;
        //        foreach (string file in Request.Files)
        //        {
        //            HttpPostedFileBase HttpPostedFileBase = Request.Files[file];
        //            string DosyaDizini = "/Uploads/" + HttpPostedFileBase.FileName;
        //            try
        //            {
        //                String mime = "application/unknown";
        //                String extension = Path.GetExtension(DosyaDizini).ToLower();
        //                RegistryKey key = Registry.ClassesRoot.OpenSubKey(extension);
        //                if (key != null && key.GetValue("Content Type") != null)
        //                    mime = key.GetValue("Content Type").ToString();

        //                Request.Files[file].SaveAs(Server.MapPath(DosyaDizini));
        //                model.FileNameDto = HttpPostedFileBase.FileName;
        //                model.FileSizeDto = HttpPostedFileBase.ContentLength;
        //                model.FileTypeDto = HttpPostedFileBase.ContentType;
        //                model.FileExtensionDto = extension;
        //                model.FileUrlDto = DosyaDizini;

        //                Durum = true;
        //                model.CreatedUserNameDto = "system";
        //                model.CreatedDateDto = DateTime.Now;
        //                model.ModifiedUserNameDto = "system";
        //                model.ModifiedDateDto = DateTime.Now;
        //                FileUIService.Insert(model);
        //            }
        //            catch (Exception)
        //            {
        //                Durum = false;
        //            }
        //        }

        //        return (Durum == true
        //            ? Json(new { Message = "Dosya kaydedildi." }, JsonRequestBehavior.AllowGet)
        //            : Json(new { Message = "Hata... Tekrar dene." }, JsonRequestBehavior.AllowGet));
        //    }
        //    return View();
        //}

        public ActionResult Jquery()
        {
            return View();
        }

        #endregion


    }
}