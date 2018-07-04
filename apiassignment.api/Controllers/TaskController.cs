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
            string msg = "";
            IEnumerable<Task> dt = null;
            try
            {
                dt = new TaskBusiness().GetTasks();

            }
            catch(Exception ex)
            {
                msg = ex.Message;
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format(msg)),
                    ReasonPhrase = "Error"
                };
                return response;
            }             
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // GET: api/Task/5
        //public IEnumerable<Task> Get(int id)
        public HttpResponseMessage Get(int id)
        {
            string msg = "";
            IEnumerable <Task> dt = null;
            try
            {
                dt = new TaskBusiness().GetTasksById(id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format(msg)),
                    ReasonPhrase = "Error"
                };
                return response;
            }           
            return Request.CreateResponse(HttpStatusCode.OK, dt);
            
        }

        // POST: api/Task
        public HttpResponseMessage Post([FromBody]Task ts)
        {
            IEnumerable<Task> key = null;
            string msg = "";           
            try
            {
                key = new TaskBusiness().PostTaskById(ts);
            
            }
            catch(Exception ex)
            {
                msg = ex.Message;
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent(string.Format(msg)),
                    ReasonPhrase = "Error"
                };
                return response;

            }           
            return Request.CreateResponse(HttpStatusCode.Created, key);
        }

        // PUT: api/Task/5
        public HttpResponseMessage Put([FromBody] Task ts)
        {
            string msg = "";
            IEnumerable<Task> key = null;
            HttpResponseMessage response;
            
            try
            {
                key = new TaskBusiness().PutTaskById(ts);

            }
            catch(Exception ex)
            {
                msg = ex.Message;
                response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent(string.Format(msg)),
                    ReasonPhrase = "Error"
                };
                return response;
            }           
            return Request.CreateResponse(HttpStatusCode.Created, key);

        }

        // DELETE: api/Task/5
        public HttpResponseMessage Delete([FromBody]Task ts)
        {
            string msg = "";
            int key = 0;
            HttpResponseMessage response;           
            try
            {
                key = new TaskBusiness().DeleteTaskById(ts);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent(string.Format(msg)),
                    ReasonPhrase = "Error"
                };
                return response;
            }           
            return Request.CreateResponse(HttpStatusCode.OK, key);
        }
    }
}
