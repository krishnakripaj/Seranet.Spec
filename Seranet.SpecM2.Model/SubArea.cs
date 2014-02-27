using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seranet.SpecM2.Model
{
    public class SubArea : IIdentifier
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Practice> Practices { get; set; }

        public int Id { get; set; }

        public Guid GUID { get; set; }

        public byte[] RowVersion { get; set; }
    }
}