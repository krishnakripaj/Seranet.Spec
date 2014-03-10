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

        public static Status getStatus(int k)
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

        public Claims(Project[] projects, List<Practice> practices, SpecDbContext context)
        {
            //KEY for project status map
            // 0 -> not claimed
            // 1 -> accepted
            // 2 -> rejected
            // 3 -> pending
            int id_count = 0;
            int[] map1 = new int[28] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 3, 0, 1, 1, 1, 1, 0, 1, 1, 2, 3, 3, 1 }; // 1 -> aproved, 2-> reject, 3 -> pending



            int[] map_tempus = new int[61];
            int[] map_TrioLink = new int[61];
            for (int i = 0; i < 28; i++)
            {
                map_tempus[i] = map1[i];
                map_TrioLink[i] = 1;

            }
            for (int i = 28; i < 61; i++)
            {
                map_tempus[i] = 1;
                map_TrioLink[i] = 1;
                if (i == 32)
                {
                    map_tempus[i] = 2;
                }
                if (i >= 43 && i < 47)
                {
                    map_tempus[i] = 0;
                }
            }




            claims = new Claim[map_tempus.Length + map_TrioLink.Length - 7 + 3]; //reduce 3 for number of 0 s add 3 for extra 3 at the end

            //tempus project claim seeds        
            for (int i = 0; i < map_tempus.Length; i++)
            {
                if (map_tempus[i] != 0)
                {
                    claims[id_count] = new Claim
                    {
                        Id = id_count + 1,
                        GUID = Guid.NewGuid(),
                        Status = getStatus(map_tempus[i]),
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

            //TrioLink project claim seeds
            for (int i = 0; i < map_TrioLink.Length; i++)
                if (map_TrioLink[i] != 0)
                {
                    claims[id_count] = new Claim
                    {
                        Id = id_count + 1,
                        GUID = Guid.NewGuid(),
                        Status = getStatus(map_TrioLink[i]),
                        AuditorComment = "Seed Auto generated ",
                        CreatedTime = new DateTime(2014, 3, 1),
                        Practice = context.Practices.FirstOrDefault(t => t.Id == i + 1),
                        Project = context.Projects.FirstOrDefault(t => t.Id == 2),
                        TeamComment = "Seed Auto generated"
                    };
                    id_count++;
                }



        }
    }
}
