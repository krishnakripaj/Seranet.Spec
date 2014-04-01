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
    public class ProjectController : BaseApiController
    {
        // GET api/project
        public IEnumerable<Project> Get()
        {
            return context.Projects;
        }

        // GET api/values/5
        public Project Get(int id)
        {
            return context.Projects.Where(p => p.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public void post(dynamic project)
        {

            var projectToAdd = new Project();
            projectToAdd.GUID = Guid.NewGuid();

            projectToAdd.Enabled = true;
           projectToAdd.Name = project.name;
           projectToAdd.ProjetId = project.assignment;
            context.Projects.Add(projectToAdd);
            context.SaveChanges();

        }

    }
}

