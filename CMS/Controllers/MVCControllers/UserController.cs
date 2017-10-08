using ApiLayer.Controllers;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
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
        public JsonResult GetUsers([DataSourceRequest] DataSourceRequest request)
        {
            var controller = new UserApiController();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            DataSourceResult users = controller.GetAllUsers(request);
            //var json = (System.Web.Http.Results.OkNegotiatedContentResult<System.Collections.Generic.List<AddUserViewModel>>)Json(users).Data;
            //var json = Json(users,"application/json");
            var json = JsonConvert.SerializeObject(users, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            //return json.Content;

            return Json(users);
        }
    }
}