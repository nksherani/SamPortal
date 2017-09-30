using CMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers.MVCControllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        private readonly IUserSession _userSession;

        public HomeController(IUserSession userSession)
        {
            try {
                _userSession = userSession;
            }
            catch (Exception ex) { } 
        }

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Username = _userSession.Username;
            ViewBag.AccessToken = _userSession.BearerToken;

            return View();
        }
    }


    public interface IUserSession
    {
        string Username { get; }
        string BearerToken { get; }
    }

    public class UserSession : IUserSession
    {

        public string Username
        {
            get { return ((ClaimsPrincipal)HttpContext.Current.User).FindFirst(ClaimTypes.Name)==null?null:((ClaimsPrincipal)HttpContext.Current.User).FindFirst(ClaimTypes.Name).Value; }
        }

        public string BearerToken
        {
            get { return ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("AcessToken")==null?null: ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("AcessToken").Value; }
        }

    }
}