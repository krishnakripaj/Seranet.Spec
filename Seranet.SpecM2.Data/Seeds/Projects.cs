using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seranet.SpecM2.Data.Seeds
{
    class Projects
    {
        public Project[] projects;

        public Projects()
        {
            projects = new Project[2];
            
            projects[0] = new Project { Id = 1, GUID = Guid.NewGuid(), Enabled = true, Name = "Tempus", ProjetId = "temp1" };
            projects[1] = new Project { Id = 2, GUID = Guid.NewGuid(), Enabled = true, Name = "Trio Link", ProjetId = "trio1" };
        }
    }
}
