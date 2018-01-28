using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBLOG.WEBUI.Filters
{
    public class ExcFilter:FilterAttribute,IExceptionFilter
    {
        //Hata olduğunda çalışacak olan metod budur.
        public void OnException(ExceptionContext filterContext) //Bir hata olduğunda
        {
          throw new Exception();
        }
    }
}