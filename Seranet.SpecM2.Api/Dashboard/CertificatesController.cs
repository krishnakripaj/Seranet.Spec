using Seranet.SpecM2.Data;
using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Seranet.SpecM2.Api.Model;

namespace Seranet.SpecM2.Api.Dashboard
{
    public class CertificatesController : BaseApiController
    {
        private SpecDbContext context = new SpecDbContext();
        
        // GET api/values/5
        public int Get(int id)
        {
            int result = context.Database.SqlQuery<int>("Select Count(*) from dbo.ClaimDetails where Project_Id=@p0 AND Status= @p1", id, 1).First();
            return result;
        }
    }
}
