using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seranet.SpecM2.Model
{
    public class Practice : IIdentifier
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public Level Level { get; set;}

        public bool Obsolete { get; set; }

        public int Id { get; set; }

        public Guid GUID { get; set; }

        public byte[] RowVersion { get; set; }
    }
}