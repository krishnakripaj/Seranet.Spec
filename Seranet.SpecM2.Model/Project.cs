using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seranet.SpecM2.Model
{
    public class Project : IIdentifier
    {
        public string Name { get; set; }

        public string ProjetId { get; set; }

        public bool Enabled { get; set; }

        public int Id { get; set; }

        public Guid GUID { get; set; }

        public byte[] RowVersion { get; set; }

        public string TeamMembers { get; set; }

        public string ProjectMemberRep { get; set; }
    }
}