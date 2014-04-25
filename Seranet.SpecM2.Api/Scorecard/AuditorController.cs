using Seranet.SpecM2.Data;
using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Seranet.SpecM2.Api.Authorization;

namespace Seranet.SpecM2.Api.Scorecard
{
    public class AuditorController : BaseApiController
    {
        [HttpPost]
        [AuthorizeRoles(role="AUDITOR")]
        public void post([FromBody] practiseStatus[] practiceslist)
        {
            for (int i = 0; i < practiceslist.Length; i++)
            {
                var temp_claim = practiceslist[i];
                //var theClaim = context.Claims.Where(t => t.Practice.Id == temp_claim.practice_id AND t.project.Id=temp_claim.project_id).OrderByDescending(t=>t.CreatedTime).FirstOrDefault();
                var theClaim = (from t in context.Claims where t.Practice.Id == temp_claim.practice_id && t.Project.Id == temp_claim.project_id select t).OrderByDescending(t => t.CreatedTime).FirstOrDefault();
                theClaim.Status = getStatus(temp_claim.status);
                context.SaveChanges();
            }            
        }

        private Status getStatus(int k)
        {

            Status s = Status.PENDING;
            switch (k)
            {
                case 1:
                    s = Status.APPROVED;
                    break;
                case 2:
                    s = Status.REJECTED;
                    break;
                case 3:
                    s = Status.PENDING;
                    break;

            }

            return s;
        }
    }
    public class practiseStatus {
        public int practice_id;
        public int status;
        public int project_id;
    }
}
