using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBLOG.WEBUI.Areas.Admin.Controllers
{
    public class PanelController : Controller
    {
        // GET: Admin/Panel
        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                
            }

            else if(Session["User"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }


            return View();
        }
    }
}