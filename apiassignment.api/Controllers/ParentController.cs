﻿using apiassignment.business;
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
            }
            if ((dt == null) || (msg != "") || (dt.Count() == 0))
            {
                if (msg == "")
                {
                    msg = "No tasks found";
                    return Request.CreateResponse(HttpStatusCode.OK, dt);
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
            }
            if ((dt == null) || (msg != "") || (dt.Count() == 0))
            {
                if (msg == "")
                {
                    msg = "No tasks found by Id " + id;
                    return Request.CreateResponse(HttpStatusCode.OK, dt);
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
            return Request.CreateResponse(HttpStatusCode.Created, key);
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
