using System.Web.Mvc;

namespace DrawNet.Lib.Core.Common.DataAnnotation
{
    public class AnonymousOnly : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/");
            }


        }
    }
}