using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ViewModels;
using ViewModels.Models;

namespace ApiLayer.Controllers
{
    public class HomeApiController : BaseApiController
    {
        public List<AddPostViewModel> GetPosts()
        {
            List<POST> Posts = uow.Repository<POST>().GetAll()
                .OrderByDescending(x => x.Created_Date).Skip(0).Take(10).ToList();
            List<AddPostViewModel> postModels = new List<AddPostViewModel>();
            foreach(var post in Posts)
            {
                postModels.Add(ModelMapper<POST, AddPostViewModel>.ToModelView(post));
            }
            
            return postModels;
        }
    }
}
