using Seranet.SpecM2.Data;
using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Seranet.SpecM2.Api
{
    public class BaseApiController : ApiController
    {
        protected SpecDbContext context = new SpecDbContext();
    }
}
