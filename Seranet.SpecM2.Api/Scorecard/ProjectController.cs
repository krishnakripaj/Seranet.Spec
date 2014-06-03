using Seranet.SpecM2.Data;
using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Seranet.SpecM2.Api.Authorization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Seranet.SpecM2.Api.Scorecard
{
    public class ProjectController : BaseApiController
    {
        //WindowsIdentity identity = System.Web.HttpContext.Current.Request.LogonUserIdentity;
        // GET api/project
        public IEnumerable<Project> Get()
        {
            return context.Projects;
        }

        // GET api/values/5

        public Project Get(int id)
        {
            Project project = context.Projects.Where(p => p.Id == id).FirstOrDefault();
            return project;
        }

        [HttpPost]
        [AuthorizeRoles(role = "ADMIN")]
        public Boolean post(dynamic project)
        {

            String ProjectID = project.assignment;
            Boolean isExisting = true; 

            var projectToCheck = context.Projects.Where(a => a.ProjetId == ProjectID).FirstOrDefault();

            if (projectToCheck == null)
            {
                var projectToAdd = new Project();
                projectToAdd.GUID = Guid.NewGuid();

                projectToAdd.Enabled = true;
                projectToAdd.Name = project.name;
                projectToAdd.ProjetId = project.assignment;

                if (project.membersfrommanual != null)
                {
                    List<string> membersArr = new List<string>();
                    foreach (var mem in project.membersfrommanual)
                    {
                        membersArr.Add(mem.Value.ToString());
                    }
                    projectToAdd.TeamMembers = string.Join(",", membersArr.ToArray());
                    projectToAdd.ProjectMemberRep = project.rep;
                }
               
                context.Projects.Add(projectToAdd);
                context.SaveChanges();
                isExisting = false; 
            }

            return isExisting;
        }

        [HttpPut]
        [AuthorizeRoles(role = "ADMIN")]
        public Project put(Project project)
        {

            //      var projectToAdd = project;

            if (project.Enabled == false)
                project.Enabled = true;
            else
                project.Enabled = false;

            var projectToAdd = context.Projects.Where(p => p.ProjetId == project.ProjetId).FirstOrDefault();
            //context.Projects.Attach(projectToAdd);
            //   context.Entry(projectToAdd).State = System.Data.Entity.EntityState.Modified;
            // context.SaveChanges();

            context.Entry(projectToAdd).CurrentValues.SetValues(project);
            context.SaveChanges();
            return projectToAdd;

        }


    }
}

