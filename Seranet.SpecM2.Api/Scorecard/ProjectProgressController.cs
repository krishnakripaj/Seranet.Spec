using Seranet.SpecM2.Data;
using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Seranet.SpecM2.Api.Model;

namespace Seranet.SpecM2.Api.Scorecard
{
    public class ProjectProgressController : BaseApiController
    {

        private SpecDbContext context = new SpecDbContext();

        // GET api/scorecard
        public IEnumerable<ClaimDetail> Get()
        {
            var result = context.Database.SqlQuery<ClaimDetail>("Select * from dbo.ClaimDetails");

            return result;
        }

        // GET api/values/5
        public IEnumerable<ClaimDetail> Get(int id)
        {
            var result = context.Database.SqlQuery<ClaimDetail>("Select * from dbo.ClaimDetails where Project_Id=@p0", id);
            return result;
        }

    }
}
