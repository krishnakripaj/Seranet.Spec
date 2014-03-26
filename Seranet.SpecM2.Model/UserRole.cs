using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seranet.SpecM2.Model
{
    public class UserRole : IIdentifier
    {
        public string UserRoleType { get; set; }
        
        public int Id { get; set; }

        public String UserName { get; set; }

        public Guid GUID { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
