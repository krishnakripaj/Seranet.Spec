using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seranet.SpecM2.Data.Seeds
{
    class Claims
    {
       public Claim[] claims;

        public Claims(Project[] projects, List<Practice> practices)
        {
            claims = new Claim[6];

            claims[0] = new Claim { Id = 1, GUID = Guid.NewGuid(), Status = Status.APPROVED, AuditorComment = "Project Audited successfully", CreatedTime = DateTime.Now, Practice = practices.ElementAt(0), Project = projects[0], TeamComment = "Practise claimed" };
            claims[1] = new Claim { Id = 2, GUID = Guid.NewGuid(), Status = Status.PENDING, AuditorComment = "Project Audited successfully", CreatedTime = new DateTime(2011, 1, 1), Practice = practices.ElementAt(0), Project = projects[0], TeamComment = "Practise claimed" };
            claims[2] = new Claim { Id = 3, GUID = Guid.NewGuid(), Status = Status.REJECTED, AuditorComment = "Project claim request rejected", CreatedTime = new DateTime(2011, 2, 1), Practice = practices.ElementAt(1), Project = projects[1], TeamComment = "Practiseclaimed" };
            claims[3] = new Claim { Id = 4, GUID = Guid.NewGuid(), Status = Status.PENDING, AuditorComment = "Project Audited successfully", CreatedTime = new DateTime(2011, 3, 1), Practice = practices.ElementAt(2), Project = projects[1], TeamComment = "Practise claimed" };
            claims[4] = new Claim { Id = 5, GUID = Guid.NewGuid(), Status = Status.APPROVED, AuditorComment = "Project Audited successfully", CreatedTime = new DateTime(2011, 4, 1), Practice = practices.ElementAt(2), Project = projects[1], TeamComment = "Practise claimed" };
            claims[5] = new Claim { Id = 6, GUID = Guid.NewGuid(), Status = Status.PENDING, AuditorComment = "Project claim request rejected", CreatedTime = new DateTime(2012, 1, 1), Practice = practices.ElementAt(3), Project = projects[1], TeamComment = "Practise claimed" };
        }
    }
}
