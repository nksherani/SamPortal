using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers.MVCControllers
{
    public class ParentMVCController : Controller
    {
        protected readonly IUserSession _userSession;

        public ParentMVCController(IUserSession userSession)
        {
            try
            {
                _userSession = userSession;
            }
            catch (Exception ex) { }
        }
        
    }
}