using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seranet.Spec.Models
{
    public class User : IIdentifier
    {
        public string UserName { get; set; }

        public int Id { get; set; }

        public Guid GUID { get; set; }

        public byte[] RowVersion { get; set; }

    }
}