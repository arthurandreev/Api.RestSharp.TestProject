using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Newtonsoft.Json;

namespace Api.RestSharp.TestFramework.Tests
{
    [TestClass()]
    public class ApiClientTests
    {
        private ApiClient apiClient = new ApiClient();

        [TestMethod(), TestCategory("CRUD")]
        public void TestGetEndpoint_HappyPath200()
        {
            var response = apiClient.GetRequestAsync();
            Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode);
            Assert.IsTrue(response.Result.Server == "cloudflare");
            Assert.IsTrue(response.Result.ContentType.Equals("application/json; charset=utf-8"));
        }

        [TestMethod(), TestCategory("CRUD")]
        public void TestGetByIdEndpoint_HappyPath200()
        {
            var response = apiClient.GetByIdRequestAsync(1);
            var jsonResponse = response.Result.Content.ToString();
            ToDoItemPOCOWithId responsePOCO = JsonConvert.DeserializeObject<ToDoItemPOCOWithId>(jsonResponse);
            Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode);
            Assert.IsTrue(response.Result.Server == "cloudflare");
            Assert.IsTrue(response.Result.ContentType.Equals("application/json; charset=utf-8"));
            Assert.AreEqual("delectus aut autem", responsePOCO.Title);
            Assert.IsFalse(responsePOCO.Completed);
            Assert.AreEqual(1, responsePOCO.Id);
        }

        [TestMethod(), TestCategory("CRUD")]
        public void TestGetByIdEndpoint_UnhappyPath404()
        {
            var response = apiClient.GetByIdRequestAsync(123456789);
            var jsonResponse = response.Result.Content.ToString();
            ToDoItemPOCOWithId responsePOCO = JsonConvert.DeserializeObject<ToDoItemPOCOWithId>(jsonResponse);
            Assert.AreEqual(HttpStatusCode.NotFound, response.Result.StatusCode);
            Assert.IsTrue(response.Result.Server == "cloudflare");
            Assert.IsTrue(response.Result.ContentType.Equals("application/json; charset=utf-8"));
        }

        [TestMethod(), TestCategory("CRUD")]
        public void TestPostEndpoint_HappyPath201()
        {
            var toDoItem = new ToDoItemPOCOWithoutId { Title = "Water plants", Completed = true, UserId = 1 };
            var response = apiClient.PostRequestAsync(toDoItem);
            var jsonResponse = response.Result.Content.ToString();
            ToDoItemPOCOWithId responsePOCO = JsonConvert.DeserializeObject<ToDoItemPOCOWithId>(jsonResponse);
            Assert.AreEqual(HttpStatusCode.Created, response.Result.StatusCode);
            Assert.IsTrue(response.Result.Server == "cloudflare");
            Assert.IsTrue(response.Result.ContentType.Equals("application/json; charset=utf-8"));
            Assert.AreEqual("Water plants", responsePOCO.Title);
            Assert.IsTrue(responsePOCO.Completed);
            Assert.AreEqual(1, responsePOCO.UserId);
        }

        [TestMethod(), TestCategory("CRUD")]
        public void TestPutEndpoint_HappyPath200()
        {
            var toDoItemPOCO = new ToDoItemPOCOWithId { UserId = 1, Id = 1, Completed = true, Title = "Go for a jog" };
            var response = apiClient.PutRequestAsync(1, toDoItemPOCO);
            var jsonResponse = response.Result.Content.ToString();
            ToDoItemPOCOWithId responsePOCO = JsonConvert.DeserializeObject<ToDoItemPOCOWithId>(jsonResponse);
            Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode);
            Assert.IsTrue(response.Result.Server == "cloudflare");
            Assert.AreEqual("Go for a jog", responsePOCO.Title);
            Assert.IsTrue(responsePOCO.Completed);
            Assert.AreEqual(1, responsePOCO.UserId);
            Assert.AreEqual(1, responsePOCO.Id);
        }

        [TestMethod(), TestCategory("CRUD")]
        public void TestDeleteEndpoint_HappyPath200()
        {
            var response = apiClient.DeleteByIdRequestAsync(1);
            Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode);
            Assert.IsTrue(response.Result.Server == "cloudflare");
        }
    }
}