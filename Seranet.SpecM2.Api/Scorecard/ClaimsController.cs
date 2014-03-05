﻿using Seranet.SpecM2.Data;
using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Seranet.SpecM2.Api.Scorecard
{
    public class ClaimsController : BaseApiController
    {
        // GET api/claims
        public IEnumerable<Claim> Get()
        {
            return context.Claims;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
    }
}
