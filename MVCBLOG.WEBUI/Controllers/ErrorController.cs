using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBLOG.WEBUI.Controllers
{

    public class ErrorController : Controller
    {
        //Hata olduğunda çalışacak olan metod budur.
        //public void OnException(ExceptionContext filterContext) //Bir hata olduğunda
        //{

        //    filtercontext.exceptionhandled = true; //hatayı bizim tarafımızdan yönetileceğini belirtiyoruz.
        //    filtercontext.controller.tempdata["error"] = filtercontext.exception; //oluşan hata nesnesini tempdata daki error nesnesine aktarıyoruz.
        //    filtercontext.result = new redirectresult("~/error/pagenotfound"); //bu durumda istemciyi yandaki sayfaya yönlendiriyoruz.
        //}

        // GET: /Error/PageNotFound
        public ActionResult PageNotFound()
        {
            if (TempData["error"] == null)
                return RedirectToAction("Index", "Home");
            Exception exModel = TempData["error"] as Exception;
            return View(exModel);
        }

    }
}