using ApiLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels.Models;

namespace CMS.Controllers.MVCControllers
{
    public class PostsController : ParentMVCController
    {
        public PostsController(IUserSession userSession):base(userSession){ }
        // GET: Posts
        public ActionResult NewPost()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewPost(AddPostViewModel post)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var PostId = new PostsApiController().NewPost(post);
            return View();
        }
    }
}