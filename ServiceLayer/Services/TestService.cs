using DataLayer;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceLayer.Services
{
    public class TestService
    {
        UnitOfWork uow = new UnitOfWork();
        public void TestMethod()
        {
            USER user = new USER();
            user.Active = 1;
            user.Username = "naveed";
            user.Created_Date = DateTime.Now;
            user.Created_By = "naveed";
            user.First_Name = "Naveed";
            uow.Repository<USER>().Insert(user);
        }
    }
}