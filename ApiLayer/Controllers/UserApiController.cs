using AutoMapper;
using DataLayer;
using DataLayer.Repository;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ViewModels;
using ViewModels.Models;

namespace ApiLayer.Controllers
{
    public class UserApiController : BaseApiController
    {
        UnitOfWork uow = new UnitOfWork();
        // GET: UserApi
        public IHttpActionResult GetAllUsers([DataSourceRequest] DataSourceRequest request)
        {
            var users = uow.Repository<USER>().GetAll().ToDataSourceResult(request);
            return Ok(users);
        }
        public IHttpActionResult AddUser(AddUserViewModel model)
        {
            model.CreatedDate = DateTime.Now;
            model.CreatedBy = HttpContext.Current.User.Identity.Name;
            USER user = new USER();
            //Mapper.Equals(model, user);
            user = ModelMapper<USER, AddUserViewModel>.ToEntity(model);
            uow.Repository<USER>().Insert(user);
            return Ok(user);
        }
    }
}