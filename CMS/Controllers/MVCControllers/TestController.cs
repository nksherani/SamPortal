﻿using AspNetIdentity.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ApiLayer.Controllers;
using Newtonsoft.Json;

namespace CMS.Controllers.MVCControllers
{
    [Authorize]
    public class TestController : Controller
    {
        private readonly IUserSession _userSession;

        public TestController(IUserSession userSession)
        {
            _userSession = userSession;
        }
        // GET: Test
        //[Authorize]
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJuYW1laWQiOiIzYWRiM2Y1MS04ZTE5LTQzZTUtOTk4OS05OTU0Nzg0ZjY0YzAiLCJ1bmlxdWVfbmFtZSI6IlN1cGVyUG93ZXJVc2VyIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS9hY2Nlc3Njb250cm9sc2VydmljZS8yMDEwLzA3L2NsYWltcy9pZGVudGl0eXByb3ZpZGVyIjoiQVNQLk5FVCBJZGVudGl0eSIsIkFzcE5ldC5JZGVudGl0eS5TZWN1cml0eVN0YW1wIjoiNjVlOTUwMjgtZTQxZC00NWIwLWI5ZTMtYWFjMTAwZjJlYWU4Iiwicm9sZSI6WyJTdXBlckFkbWluIiwiQWRtaW4iXSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1OTgyMiIsImF1ZCI6IjQxNGUxOTI3YTM4ODRmNjhhYmM3OWY3MjgzODM3ZmQxIiwiZXhwIjoxNTA2MjAzNTE2LCJuYmYiOjE1MDYxMTcxMTZ9.WoGiiQU59Rc2RRJkEpJ0kQaKdzGnWGPraGwo5RZdfQU");
                client.BaseAddress = new Uri( "http://localhost:55426/api/");
                var response = client.GetAsync("Accounts/Users");
                response.Wait();
                var result = response.Result;
                if(result.IsSuccessStatusCode)
                {

                }
            }
            return View();
        }
        public ActionResult Test()
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJuYW1laWQiOiIzYWRiM2Y1MS04ZTE5LTQzZTUtOTk4OS05OTU0Nzg0ZjY0YzAiLCJ1bmlxdWVfbmFtZSI6IlN1cGVyUG93ZXJVc2VyIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS9hY2Nlc3Njb250cm9sc2VydmljZS8yMDEwLzA3L2NsYWltcy9pZGVudGl0eXByb3ZpZGVyIjoiQVNQLk5FVCBJZGVudGl0eSIsIkFzcE5ldC5JZGVudGl0eS5TZWN1cml0eVN0YW1wIjoiNjVlOTUwMjgtZTQxZC00NWIwLWI5ZTMtYWFjMTAwZjJlYWU4Iiwicm9sZSI6WyJTdXBlckFkbWluIiwiQWRtaW4iXSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1OTgyMiIsImF1ZCI6IjQxNGUxOTI3YTM4ODRmNjhhYmM3OWY3MjgzODM3ZmQxIiwiZXhwIjoxNTA2MjAzNTE2LCJuYmYiOjE1MDYxMTcxMTZ9.WoGiiQU59Rc2RRJkEpJ0kQaKdzGnWGPraGwo5RZdfQU");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", _userSession.BearerToken);
                client.BaseAddress = new Uri("http://localhost:55427/cmsapi/");
                var response = client.GetAsync("Test/Get");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Data = JsonConvert.DeserializeObject < List<string> > (result.Content.ReadAsStringAsync().Result.ToString());
                }
            }
            ApiLayer.Controllers.TestController test = new ApiLayer.Controllers.TestController();
            var list = test.Get();
            return View();
        }
    }
}