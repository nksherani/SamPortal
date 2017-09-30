using Kendo.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers.MVCControllers
{
    public class SharedController : ParentMVCController
    {
        public SharedController(IUserSession userSession):base(userSession){ }
        // GET: Shared
        public ActionResult Index()
        {
            return View();
        }
        public void SetMenu()
        {
            if (!SiteMapManager.SiteMaps.ContainsKey("SamMap"))
            {
                SiteMapManager.SiteMaps.Register<XmlSiteMap>("SamMap", sitmap => sitmap.LoadFrom("~/Content/SamMap.sitemap"));
            }
        }
    }
    public interface IUserSession
    {
        string Username { get; }
        string identifier { get; }
        string BearerToken { get; }
    }

    public class UserSession : IUserSession
    {

        public string Username
        {
            get { return ((ClaimsPrincipal)HttpContext.Current.User).FindFirst(ClaimTypes.Name) == null ? null : ((ClaimsPrincipal)HttpContext.Current.User).FindFirst(ClaimTypes.Name).Value; }
        }
        public string identifier
        {
            get { return ((ClaimsPrincipal)HttpContext.Current.User).FindFirst(ClaimTypes.NameIdentifier) == null ? null : ((ClaimsPrincipal)HttpContext.Current.User).FindFirst(ClaimTypes.Name).Value; }
        }

        public string BearerToken
        {
            get { return ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("AcessToken") == null ? null : ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("AcessToken").Value; }
        }

    }
}