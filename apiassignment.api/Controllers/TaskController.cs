using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apiassignment.business;

namespace apiassignment.api.Controllers
{
    public class TaskController : ApiController
    {
        // GET: api/Task
        public HttpResponseMessage Get()
        {
            IEnumerable<Task> dt = new TaskBusiness().GetTasks();
            if ((dt == null) || (dt.Count() == 0))
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No tasks found")),  
                        ReasonPhrase = "No task found"
                };
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);

        }

        // GET: api/Task/5
        //public IEnumerable<Task> Get(int id)
        public HttpResponseMessage Get(int id)
        {
            IEnumerable<Task> dt = new TaskBusiness().GetTasksById(id);
            if ((dt == null) || (dt.Count() == 0))
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No tasks found by Id " + id)),
                    ReasonPhrase = "No task found"
                };                
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);
            
        }

        // POST: api/Task
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Task/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Task/5
        public void Delete(int id)
        {
        }
    }
}
