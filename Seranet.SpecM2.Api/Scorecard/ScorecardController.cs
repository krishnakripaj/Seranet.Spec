using Seranet.SpecM2.Data;
using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Seranet.SpecM2.Api
{
    public class ScorecardController : ApiController
    {
        private SpecDbContext context = new SpecDbContext();

        // GET api/scorecard
        public IEnumerable<Project> Get()
        {
            return context.Projects;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

    }
}
