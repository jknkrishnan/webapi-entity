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
        public HttpResponseMessage Get()
        {
            string msg = "";
            IEnumerable<Parent> dt = null;
            try
            {
                dt  = new ParentBusiness().GetParentTasks();
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

        // GET: api/Parent/5
        public HttpResponseMessage Get(int id)
        {
            string msg = "";
            IEnumerable<Parent> dt = null;
            try
            {
                dt = new ParentBusiness().GetParentTasksById(id);
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

        // POST: api/Parent
        public HttpResponseMessage Post([FromBody]Parent ts)
        {
            IEnumerable<Parent> key = null;
            string msg = "";
            try
            {
                key = new ParentBusiness().PostTaskById(ts);

            }
            catch (Exception ex)
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
        
        public HttpResponseMessage Delete([FromBody]Parent ts)
        {
            string msg = "";
            int key = 0;
            try
            {
                key = new ParentBusiness().Delete(ts);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent(string.Format(msg)),
                    ReasonPhrase = "Error"
                };
                return response;

            }
            return Request.CreateResponse(HttpStatusCode.OK, key); ;
        }
    }
}
