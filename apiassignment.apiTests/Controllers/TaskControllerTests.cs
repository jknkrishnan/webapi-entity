using apiassignment.api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http.Hosting;
using System.Web.Http;
using System.Net;
using NUnit.Framework;
using System.Collections;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace apiassignment.api.Controllers.Tests
{
    [TestFixture]
    public class TaskControllerTests
    {
        public static IEnumerable GetTestDataTask
        {
            get
            {
                string FileLoc = @"TestData\TaskContoller.json";
                string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

                var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
                var task = JsonConvert.DeserializeObject<Task>(jsonText);
                yield return task;
            }
        }

        public static IEnumerable GetTestTaskControllerByID
        {
            get
            {
                string FileLoc = @"TestData\TaskControllerByID.json";
                string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

                var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
                var task = JsonConvert.DeserializeObject<Task>(jsonText);
                yield return task;
            }
        }

        [Test]
        public void GetPost()
        {
            //test get
            TaskController tc = new TaskController();
            tc.Request = new HttpRequestMessage();
            tc.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            tc.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage _http;
            _http = tc.Get();
            Assert.AreEqual(HttpStatusCode.OK, _http.StatusCode);
        }

        [Test, TestCaseSource("GetTestTaskControllerByID")]
        public void GetPostById(Task ts)
        {
            //test get by id
            TaskController tc = new TaskController();
            tc.Request = new HttpRequestMessage();
            tc.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            tc.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage _http;
            _http = tc.Get(ts.Task_Id);
            Assert.AreEqual(HttpStatusCode.OK, _http.StatusCode);
        }

        [Test, TestCaseSource("GetTestDataTask")]
        public void PostPost(Task _task)
        {
            //test post
            _task.Task_Id = 0;
            TaskController p = new TaskController();
            p.Request = new HttpRequestMessage();
            p.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            p.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage _http;
            _http = p.Post(_task);

            //test get by id
            Assert.AreEqual(HttpStatusCode.Created, _http.StatusCode);
            Assert.GreaterOrEqual(_task.Task_Id, 0);
            _http = p.Get(_task.Task_Id);
            Assert.AreEqual(HttpStatusCode.OK, _http.StatusCode);
            Assert.GreaterOrEqual(_task.Task_Id, 0);

            //test put
            _task.TaskDesc = "xyz";
            _http = p.Put(_task);
            Assert.AreEqual(HttpStatusCode.Created, _http.StatusCode);
            Assert.AreEqual(_task.TaskDesc, "xyz");
            //test delete
            _http = p.Delete(_task);
            Assert.AreEqual(HttpStatusCode.OK, _http.StatusCode);
        }       
    }
}