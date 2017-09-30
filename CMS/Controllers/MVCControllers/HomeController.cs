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
    public class HomeController : ParentMVCController
    {

        public HomeController(IUserSession userSession):base(userSession){}

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Username = _userSession.Username;
            ViewBag.AccessToken = _userSession.BearerToken;

            return View();
        }
    }


    
}