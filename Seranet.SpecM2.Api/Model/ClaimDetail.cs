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

        public Status Status { get; set; }

        public int Id { get; set; }

    }

    public enum Status
    {
        PENDING,
        APPROVED,
        REJECTED
    }
}