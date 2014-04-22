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
        public int Get(String id)
        {
            UserRoleType userroletype = context.Database.SqlQuery<UserRoleType>("Select UserRoleType from dbo.UserRole where UserName=@p0", id).First();
            List<UserRoleType> roles = (from b in context.UserRoles where b.UserName == id select b.UserRoleType).ToList();
            var x = roles;
            if (roles == null)
            {
                return -1;
            }
            else if (roles.Count == 1)
            {
                if (roles[0] == UserRoleType.ADMIN)
                    return 0;
                else if (roles[0] == UserRoleType.AUDITOR)
                    return 1;
            }
            else
            {
                return 3;
            }
            return -1;
        }

    }
}
