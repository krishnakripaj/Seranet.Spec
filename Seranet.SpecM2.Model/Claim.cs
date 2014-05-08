using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seranet.SpecM2.Model
{
    public class Claim : IIdentifier
    {
        public Practice Practice { get; set; }

        public string TeamComment { get; set; }

        public string AuditorComment { get; set; }

        public DateTime CreatedTime { get; set; }

        public Project Project { get; set; }

        
        public Status Status { get; set; }


        public int Id { get; set; }

        public Guid GUID { get; set; }

        public byte[] RowVersion { get; set; }
    }

    public enum Status
    {
        PENDING,
        APPROVED,
        REJECTED,
        NOTAPPLICABLE
    }

}