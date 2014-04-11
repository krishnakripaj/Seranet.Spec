using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seranet.SpecM2.Data.Seeds
{
    class UserRoles
    {
        public UserRole[] userRoles;

        public UserRoles() {

            userRoles = new UserRole[4];

            userRoles[0] = new UserRole { Id = 1, UserRoleType = UserRoleType.ADMIN, GUID = Guid.NewGuid() , UserName = "krishnakripaj"};
            userRoles[1] = new UserRole { Id = 2, UserRoleType = UserRoleType.AUDITOR, GUID = Guid.NewGuid(), UserName = "hashinis" };
            userRoles[2] = new UserRole { Id = 3, UserRoleType = UserRoleType.AUDITOR, GUID = Guid.NewGuid(), UserName = "nirangad" };
            userRoles[3] = new UserRole { Id = 4, UserRoleType = UserRoleType.AUDITOR, GUID = Guid.NewGuid(), UserName = "madushib" };

        }
    }

}
