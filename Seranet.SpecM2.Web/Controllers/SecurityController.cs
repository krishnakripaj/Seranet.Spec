using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seranet.SpecM2.Web.Controllers
{
    public class SecurityController : Controller
    {
       
        public string UserName()
        {
            return HttpContext.User.Identity.Name;
        } 
    }
}
