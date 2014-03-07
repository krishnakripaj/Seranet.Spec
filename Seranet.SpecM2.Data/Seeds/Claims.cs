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

        public Claims(Project[] projects, List<Practice> practices, SpecDbContext context)
        {

            int id_count = 0;
            int[] map = new int[28] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 3, 0, 2, 1, 1, 1, 0, 1, 1, 2, 3, 3, 1 }; // 1 -> aproved, 2-> reject, 3 -> pending
           // int[] map = new int[28] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            claims = new Claim[map.Length-3+3]; //reduce 3 for number of 0 s add 3 for extra 3 at the end
           
            for (int i = 0; i < map.Length; i++)
            {                
                Status s=Status.PENDING;
                    switch (map[i])
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

                    if (map[i] != 0)
                    {
                        claims[id_count] = new Claim
                        {
                            Id = id_count + 1,
                            GUID = Guid.NewGuid(),
                            Status = s,
                            AuditorComment = "Seed Auto generated ",
                            CreatedTime = new DateTime(2014, 2, 1),
                            Practice = context.Practices.FirstOrDefault(t => t.Id == i + 1),
                            Project = context.Projects.FirstOrDefault(t => t.Id == 1),
                            TeamComment = "Seed Auto generated"
                        };
                        id_count++;
                    }
            }

            claims[id_count++] = new Claim
            {
                //Id = id_count + 1,
                GUID = Guid.NewGuid(),
                Status = Status.REJECTED,
                AuditorComment = "rejected due to abc ",
                CreatedTime = new DateTime(2014, 1, 1),
                Practice = context.Practices.FirstOrDefault(t => t.Id == 1),
                Project = context.Projects.FirstOrDefault(t => t.Id == 1),
                TeamComment = "Seed Auto generated"
            };
            claims[id_count++] = new Claim
            {
                // Id = id_count + 1,
                GUID = Guid.NewGuid(),
                Status = Status.REJECTED,
                AuditorComment = "rejected due to abc ",
                CreatedTime = new DateTime(2013, 11, 1),
                Practice = context.Practices.FirstOrDefault(t => t.Id == 5),
                Project = context.Projects.FirstOrDefault(t => t.Id == 1),
                TeamComment = "Seed Auto generated"
            };
            claims[id_count++] = new Claim
            {
                // Id = id_count + 1,
                GUID = Guid.NewGuid(),
                Status = Status.REJECTED,
                AuditorComment = "rejected due to abc ",
                CreatedTime = new DateTime(2013, 11, 13),
                Practice = context.Practices.FirstOrDefault(t => t.Id == 9),
                Project = context.Projects.FirstOrDefault(t => t.Id == 1),
                TeamComment = "Seed Auto generated"
            };
      

          
        }
    }
}
