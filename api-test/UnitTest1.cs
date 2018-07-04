using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using apiassignment.api.Controllers;
using System.Net.Http;

namespace api_test
{
    [TestFixture]
    public class ProjectControllerTest
    {
        //public static IEnumerable TestDataProject
        //{
        //    get
        //    {
        //        string FileLoc = @"TestData\Project.json";
        //        string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

        //        var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
        //        var project = JsonConvert.DeserializeObject<ProjectModel>(jsonText);
        //        yield return project;
        //    }
        //}
        //public static UserModel GetTestDataUser()
        //{
        //    string FileLoc = @"TestData\User.json";
        //    string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

        //    var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
        //    var testUser = JsonConvert.DeserializeObject<UserModel>(jsonText);
        //    return testUser;

        //}

        [Test]
        public void TestProject()
        {
            ParentController oController = new ParentController();



            HttpResponseMessage res = oController.Get();
            string message = pResult.status.Message;
            Assert.AreEqual("Project added successfully", message);
            testProject.Project_ID = pResult.project.Project_ID;
            Assert.AreEqual("Project updated successfully", oController.Post(testProject).status.Message);
            Assert.IsNotNull(oController.Get());

        }
        public UserUpdateResult AddUser()
        {
            UserController oController = new UserController();
            UserUpdateResult uResult = new UserUpdateResult();
            uResult = oController.Post(GetTestDataUser());
            string message = uResult.status.Message;
            Assert.AreEqual("User added successfully", message);
            return uResult;
        }

    }
}
