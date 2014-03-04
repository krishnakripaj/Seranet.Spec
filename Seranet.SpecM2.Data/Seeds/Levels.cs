using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seranet.SpecM2.Data.Seeds
{
    class Levels
    {
        public Level[] levels;

        public Levels()
        {
            levels = new Level[3];

            levels[0] = new Level { Id = 1, GUID = Guid.NewGuid(), Name = "Explorer" };
            levels[1] = new Level { Id = 2, GUID = Guid.NewGuid(), Name = "Veteran" };
            levels[2] = new Level { Id = 3, GUID = Guid.NewGuid(), Name = "Optimizer" };
        }
    }
}
