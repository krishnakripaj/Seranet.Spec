using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seranet.SpecM2.Data.Seeds
{
    public class SpecSeedDataInitializer: System.Data.Entity.CreateDatabaseIfNotExists<SpecDbContext>
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

            EngineeringDiscipline ed= new EngineeringDiscipline(levels);
            BusinessFocus bf = new BusinessFocus(levels);
            TeamBuilding tb= new TeamBuilding(levels);
            StakeholderEngagement se= new StakeholderEngagement(levels);

            context.Areas.Add(ed.Area);
            context.Areas.Add(bf.Area);
            context.Areas.Add(tb.Area);
            context.Areas.Add(se.Area);
            context.SaveChanges();


                        
            List <Practice> practices = new List <Practice>();
            foreach (SubArea s in ed.Area.SubAreas) { 
                foreach (Practice p in s.Practices) {
                    practices.Add(p);
                }
            }
            /* insert claims data */
            Claim[] claims = new Claims(projects, practices, context).claims;
            for (int i = 0; i < claims.Length; i++)
            {
                context.Claims.Add(claims[i]);
            }
            context.SaveChanges();


        }
    }
}