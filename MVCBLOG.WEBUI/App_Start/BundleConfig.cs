using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI.WebControls;

namespace MVCBLOG.WEBUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css/genel").Include(
                "~/Content/css/jquery-ui.css",
                "~/Content/css/bootstrap-social.css",
                "~/Content/css/profilecard.css",
                "~/Content/css/sweetalert2.min.css",
                "~/Content/css/blog.css",
                "~/Content/css/PagedList.css"
                ));

           

            bundles.Add(new ScriptBundle("~/bundles/js/genel").Include(
                "~/Content/js/jquery-3.2.1.min.js",
                "~/Content/js/popper.min.js",
                "~/Content/js/bootstrap.min.js"
                
                ));

            bundles.Add(new ScriptBundle("~/bundles/js/validation").Include(
                "~/Content/js/jquery.validate.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/js/ajaxvalidation").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                       "~/Content/js/jquery-ui-1.8.11.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/highlight").Include(
                       "~/Content/js/Highlight/highlight.pack.js"));




        }
    }
}

//bundles.Add(new ScriptBundle("~/bundles/jqueryValidation").Include(
//            "~/Content/js/jqueryui/jquery-1.6.2.js",
//            "~/Content/js/jqueryui/jquery.validate.js"));

//bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
//            "~/Content/js/jqueryui/jquery-1.*"));

//bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
//            "~/Content/js/jqueryui/jquery-ui*"));

//bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
//            "~/Content/js/jqueryui/jquery.unobtrusive*",
//            "~/Content/js/jqueryui/jquery.validate*"));

//bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
//            "~/Scripts/modernizr-*"));

//bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/css/site.css"));

//bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
//            "~/Content/css/jqueryui/jquery.ui.core.css",
//            "~/Content/css/jqueryui/jquery.ui.resizable.css",
//            "~/Content/css/jqueryui/jquery.ui.selectable.css",
//            "~/Content/css/jqueryui/jquery.ui.accordion.css",
//            "~/Content/css/jqueryui/jquery.ui.autocomplete.css",
//            "~/Content/css/jqueryui/jquery.ui.button.css",
//            "~/Content/css/jqueryui/jquery.ui.dialog.css",
//            "~/Content/css/jqueryui/jquery.ui.slider.css",
//            "~/Content/css/jqueryui/jquery.ui.tabs.css",
//            "~/Content/css/jqueryui/jquery.ui.datepicker.css",
//            "~/Content/css/jqueryui/jquery.ui.progressbar.css",
//            "~/Content/css/jqueryui/jquery.ui.theme.css"));
//}

