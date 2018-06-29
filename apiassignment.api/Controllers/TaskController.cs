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
            }
              
            if ((dt == null) || (msg != "") || (dt.Count() == 0))
            {
                if (msg == "")
                {
                    msg = "No tasks found";
                }
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
            }

            if ((dt == null) || (msg != "") || (dt.Count() == 0))
            {
                if (msg == "")
                {
                    msg = "No tasks found by Id " + id;
                }
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

            }
            if ((key == null) || (msg != "") || (key.Count() == 0))
            {
                if (msg == "")
                {
                    msg = "Error in posting task";
                }                  
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent(string.Format(msg)),
                    ReasonPhrase = "Error"
                };
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.OK, key);
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
            }
            if ((key == null) || (msg != "") || (key.Count() == 0))
            {
                if (msg == "")
                {
                    msg = "Error in updating task";
                }
                response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent(string.Format(msg)),
                    ReasonPhrase = "Error"
                };
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.OK, key);

        }

        // DELETE: api/Task/5
        public HttpResponseMessage Delete(int id)
        {
            string msg = "";
            int key = id;
            HttpResponseMessage response;           
            try
            {
                key = new TaskBusiness().DeleteTaskById(id);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            if (key != 0)
            {
                if (msg == "")
                {
                    msg = "Error in deleting task";
                }
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
