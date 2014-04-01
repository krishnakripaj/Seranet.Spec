using Seranet.SpecM2.Data;
using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Seranet.SpecM2.Api.Scorecard
{
    public class AuditorController : BaseApiController
    {
        [HttpPost]
        public void post([FromBody] practiseStatus[] practiceslist)
        {
            for (int i = 0; i < practiceslist.Length; i++)
            {
                var temp_claim = practiceslist[i];
                var theClaim = context.Claims.FirstOrDefault(t => t.Id == temp_claim.practice_id);
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
    }
}
