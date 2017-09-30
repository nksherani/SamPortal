using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers.MVCControllers
{
    public class UserController : ParentMVCController
    {
        public UserController(IUserSession userSession):base(userSession){ }
        // GET: User
        public ActionResult AddUser()
        {
            return View();
        }
        public ActionResult AddUser(AddUserViewModel model)
        {
            return View();
        }
        public ActionResult Users()
        {
            //ViewBag.Token = _userSession.BearerToken;
            //ViewBag.Username = _userSession.Username;
            return View();
        }
    }
}