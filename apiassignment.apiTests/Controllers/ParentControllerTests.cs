using apiassignment.api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System.Web.Http.Hosting;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using System.Collections;
using Newtonsoft.Json;

namespace apiassignment.api.Controllers.Tests
{
    [TestFixture]
    public class ParentControllerTests
    {
        public static IEnumerable GetTestDataParent
        {
            get
            {
                string FileLoc = @"TestData\ParentContoller.json";
                string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

                var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
                var parent = JsonConvert.DeserializeObject<Parent>(jsonText);
                yield return parent;
            }
        }

        public static IEnumerable GetTestDataControllerByID
        {
            get
            {
                string FileLoc = @"TestData\ParentControllerByID.json";
                string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

                var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
                var parent = JsonConvert.DeserializeObject<Parent>(jsonText);
                yield return parent;
            }
        }


        [Test]        
        public void GetTasks()
        {
            //test get
            ParentController p = new ParentController();
            p.Request = new HttpRequestMessage();
            p.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            p.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage _http;
            _http = p.Get();
            Assert.AreEqual(HttpStatusCode.OK, _http.StatusCode);                     
        }
        [Test, TestCaseSource("GetTestDataControllerByID")]
        public void GetTasksByID(Parent _task)
        {
            //tets get by id
            ParentController p = new ParentController();
            p.Request = new HttpRequestMessage();
            p.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            p.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage _http;
            _http = p.Get(_task.Parent_Id);
            Assert.AreEqual(HttpStatusCode.OK, _http.StatusCode);
        }

        [Test, TestCaseSource("GetTestDataParent")]
        public void PostPost(Parent _task)
        {
            //test post
            _task.Parent_Id = 0;
            ParentController p = new ParentController();
            p.Request = new HttpRequestMessage();
            p.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            p.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage _http;
            _http = p.Post(_task);
            Assert.AreEqual(HttpStatusCode.Created, _http.StatusCode);
            Assert.GreaterOrEqual(_task.Parent_Id, 0);
            //test get by id
            _http = p.Get(_task.Parent_Id);
            Assert.AreEqual(HttpStatusCode.OK, _http.StatusCode);
            Assert.GreaterOrEqual(_task.Parent_Id, 0);
            //test delete
            _http = p.Delete(_task);
            Assert.AreEqual(HttpStatusCode.OK, _http.StatusCode);            
        }
    }
}