﻿using ApiLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using ViewModels.Models;

namespace CMS.Controllers.MVCControllers
{
    [AllowAnonymous]
    public class HomeController : ParentMVCController
    {
        
        public HomeController(IUserSession userSession):base(userSession){}

        // GET: Home
        public ActionResult Index(int PageNo = 1)
        {
            ViewBag.Username = _userSession.Username;
            ViewBag.AccessToken = _userSession.BearerToken;
            var posts = new HomeApiController().GetPosts(PageNo);
            //(AddPostViewModel)
            return View(posts);
        }
        public int GetPagesCount()
        {
            return new HomeApiController().GetPagesCount();
        }
    }


    
}