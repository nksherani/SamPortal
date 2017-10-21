using AutoMapper;
using DataLayer;
using DataLayer.Repository;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
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
        //UnitOfWork uow = new UnitOfWork();
        // GET: UserApi
        public DataSourceResult GetAllUsers([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<USER> users = (IEnumerable<USER>)uow.Repository<USER>().GetAll().ToDataSourceResult(request).Data;
            List<AddUserViewModel> list = new List<AddUserViewModel>();
            foreach(var usr in users)
            {
                list.Add(ModelMapper<USER, AddUserViewModel>.ToModelView(usr));
            }
            return list.ToDataSourceResult(request);
        }
        public IHttpActionResult AddUser(AddUserViewModel model)
        {
            model.CreatedDate = DateTime.Now;
            model.CreatedBy = HttpContext.Current.User.Identity.Name;
            USER user = new USER();
            //Mapper.Equals(model, user);
            user = ModelMapper<USER, AddUserViewModel>.ToEntity(model);
            uow.Repository<USER>().Insert(user);
            CreateUserBindingModel AuthUser = new CreateUserBindingModel()
            {
                Username = model.Username,
                Email = model.Email,
                FirstName=model.FirstName,
                LastName=model.LastName,
                MiddleName=model.MiddleName,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                RoleName = Roles.Editor
            };
            var BaseUrl = string.Format(ConfigurationManager.AppSettings["AuthBaseUri"].ToString() + "/api/Accounts/CreateUser");
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage result = httpClient.PostAsJsonAsync(BaseUrl, AuthUser).Result;
                if (result.IsSuccessStatusCode)
                    return Ok(user.User_Id);
            }
            return Ok(user.User_Id);
        }
    }
}