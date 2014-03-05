using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seranet.SpecM2.Api.Model
{
    public class ClaimDetail
    {
        public int Project_Id { get; set; }

        public int Practice_Id { get; set; }

        public bool Pending { get; set; }

        public bool Obsolete { get; set; }

        public bool Approved { get; set; }

        public int Id { get; set; }

    }
}