using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAS.Backoffice.Shared;

namespace DAS.Backoffice.Filters
{
    public class DASBuilderAuthorizeAttribute : AuthorizeAttribute
    {

        public DASBuilderAuthorizeAttribute() { 
        
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
           DASUser user = (DASUser) HttpContext.Current.Session["DASUser"];

           if (user == null) return false;
           else return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { action = "Login", controller = "Login" }));
        }
    }

  
}