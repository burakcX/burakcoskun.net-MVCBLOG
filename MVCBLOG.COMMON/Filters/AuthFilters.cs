using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace MVCBLOG.COMMON.Filters
{
    public class AuthFilters : FilterAttribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //if (CurrentSession.User == null)
            //{
            //    filterContext.Result = new RedirectResult("/Home/Login");
            //}
        }

    }
}
