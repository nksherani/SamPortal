using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ApiLayer.Controllers
{
    public class TestController : BaseApiController 
    {
        // GET: api/Test
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "naveed" };
        }

        // GET: api/Test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
        [HttpGet]
        public void Test()
        {
            TestService a = new TestService();
            a.TestMethod();
        }
    }
}
