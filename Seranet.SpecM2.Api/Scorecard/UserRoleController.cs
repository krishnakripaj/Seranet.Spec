using Seranet.SpecM2.Data;
using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Seranet.SpecM2.Api.Scorecard
{
    public class UserRoleController : BaseApiController
    {

        // GET api/userrole
        public IEnumerable<UserRole> Get()
        {
            return context.UserRoles;
        }

        // GET api/values/5
        public UserRoleType Get(String id)
        {
            UserRoleType userRoleType = context.Database.SqlQuery<UserRoleType>("Select UserRoleType from dbo.UserRole where UserName=@p0", id).First();
            return userRoleType;
        }

    }
}
