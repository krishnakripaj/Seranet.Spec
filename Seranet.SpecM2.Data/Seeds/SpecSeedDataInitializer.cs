using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seranet.SpecM2.Data.Seeds
{
    public class SpecSeedDataInitializer: System.Data.Entity. DropCreateDatabaseAlways<SpecDbContext>
    {
        protected override void Seed(SpecDbContext context)
        {
            var projects = new List<Project>
            {
                new Project{Id = 1, GUID = Guid.NewGuid(), Enabled=true, Name="Tempus", ProjetId="TEMP1"},
                new Project{Id = 2, GUID = Guid.NewGuid(), Enabled=true, Name="TrioLink", ProjetId="TRI1"}
            };
            projects.ForEach(p => context.Projects.Add(p));

            /* insert the level base data */
            var levels = new List<Level>
            {
                new Level{Id=1, GUID=Guid.NewGuid(), Name="Explorer"},
                new Level{Id=2, GUID=Guid.NewGuid(), Name="Veteran"},
                new Level{Id=3, GUID=Guid.NewGuid(), Name="Optimizer"}
            };
            levels.ForEach(l => context.Levels.Add(l));
            context.SaveChanges();
            var level1 = context.Levels.FirstOrDefault(l => l.Id == 1);
            var level2 = context.Levels.FirstOrDefault(l => l.Id == 2);
            var level3 = context.Levels.FirstOrDefault(l => l.Id == 3);

            /* insert Engineering Discipline data */

            context.Areas.Add(new EngineeringDiscipline(level1, level2, level3).Area);
            context.Areas.Add(new BusinessFocus(level1, level2, level3).Area);
            context.Areas.Add(new TeamBuilding(level1, level2, level3).Area);
            context.Areas.Add(new StakeholderEngagement(level1, level2, level3).Area);
            context.SaveChanges();

            context.SaveChanges();


        }
    }
}