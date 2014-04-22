using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;


namespace Seranet.SpecM2.Api.Scorecard
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public string role { get; set; }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
             bool isInRole = false;   
             WindowsIdentity identity = System.Web.HttpContext.Current.Request.LogonUserIdentity;
             String username = (identity.Name).Split('\\')[1];
             int userrole = (new UserRoleController()).Get(username);
             if (userrole == 1)    // both auditor and admin
             {
                 isInRole = true;
             }          
             else if ((role == "ADMIN" && userrole == 0) || (role == "AUDITOR" && userrole == 1)) {
                 isInRole = true;
             }
             return isInRole;           
        }

    }
}
