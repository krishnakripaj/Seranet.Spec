using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seranet.SpecM2.Model
{
    public class Assessment : IIdentifier
    {
        public Claim Claim { get; set; }

        public string Auditor { get; set; }

        public DateTime CreatedTime { get; set; }

        public int Id { get; set; }

        public Guid GUID { get; set; }

        public byte[] RowVersion { get; set; }
    }
}