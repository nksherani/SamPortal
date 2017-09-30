using ApiLayer.Controllers;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels.Models;

namespace CMS.Controllers.MVCControllers
{
    [Authorize]
    public class UserController : ParentMVCController
    {
        public UserController(IUserSession userSession):base(userSession){ }
        // GET: User
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(AddUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var users = new UserApiController().AddUser(model);
            return View();
        }
        public ActionResult Users()
        {
            //ViewBag.Token = _userSession.BearerToken;
            //ViewBag.Username = _userSession.Username;
            return View();
        }
        [HttpPost]
        public ActionResult GetUsers([DataSourceRequest] DataSourceRequest request)
        {
            //ViewBag.Token = _userSession.BearerToken;
            //ViewBag.Username = _userSession.Username;
            var users = new UserApiController().GetAllUsers(request);
            //var user = (AddUserViewModel)users;
            //mapping needs to be corrected
            return View(users);
        }
    }
}