using DataLayer;
using DataLayer.Repository;
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
    public class PostsApiController : BaseApiController
    {
        //UnitOfWork uow = new UnitOfWork();
        public IHttpActionResult NewPost(AddPostViewModel model)
        {
            model.CreatedDate = DateTime.Now;
            model.CreatedBy = HttpContext.Current.User.Identity.Name;
            POST post = new POST();
            //Mapper.Equals(model, user);
            post = ModelMapper<POST, AddPostViewModel>.ToEntity(model);
            uow.Repository<POST>().Insert(post);
            
            return Ok(post.Post_Id);
        }
    }
}
