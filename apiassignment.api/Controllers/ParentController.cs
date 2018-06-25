using apiassignment.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiassignment.api.Controllers
{
    public class ParentController : ApiController
    {
        // GET: api/Parent
        public IEnumerable<Parent> Get()
        {
            return (new ParentBusiness().GetParentTasks());
        }

        // GET: api/Parent/5
        public IEnumerable<Parent> Get(int id)
        {
            return (new ParentBusiness().GetParentTasksById(id));
        }

        // POST: api/Parent
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Parent/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Parent/5
        public void Delete(int id)
        {
        }
    }
}
