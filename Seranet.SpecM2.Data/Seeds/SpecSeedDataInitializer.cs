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
            context.Database.ExecuteSqlCommand("CREATE VIEW dbo.ClaimDetails AS SELECT t1.id,t1.Project_Id,t1.Practice_Id,t1.Status from dbo.Claim t1 WHERE t1.CreatedTime = (SELECT max(CreatedTime) FROM dbo.Claim t2 WHERE t2.Practice_Id = t1.Practice_Id AND t2.Project_Id=t1.Project_Id)");    

            /* insert the project base data */
            Project[] projects = new Projects().projects;
            for (int i = 0; i < projects.Length; i++)
            {
                context.Projects.Add(projects[i]);
            }
            context.SaveChanges(); 
            

            /* insert the level base data */
            Level[] levels = new Levels().levels;
            for (int i = 0; i < levels.Length; i++)
            {
                context.Levels.Add(levels[i]);
            }             
            context.SaveChanges();            

            /* insert specm2 model data */
            context.Areas.Add(new EngineeringDiscipline(levels).Area);
            context.Areas.Add(new BusinessFocus(levels).Area);
            context.Areas.Add(new TeamBuilding(levels).Area);
            context.Areas.Add(new StakeholderEngagement(levels).Area);
            context.SaveChanges();

            context.SaveChanges();


        }
    }
}