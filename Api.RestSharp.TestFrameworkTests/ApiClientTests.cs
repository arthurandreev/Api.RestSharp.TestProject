﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;

namespace Api.RestSharp.TestFramework.Tests
{
    [TestClass()]
    public class ApiClientTests
    {
        ApiClient apiClient = new ApiClient();

        [TestMethod(), TestCategory("CRUD")]
        public void TestGetEndpoint()
        {
            var response = apiClient.GetRequestAsync();
            Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode);
            Assert.IsTrue(response.Result.Server == "cloudflare");
            Assert.IsTrue(response.Result.ContentType.Equals("application/json; charset=utf-8"));
        }

        [TestMethod(), TestCategory("CRUD")]
        public void TestGetByIdEndpoint()
        {
            var response = apiClient.GetByIdRequestAsync(1);
            var jsonResponse = response.Result.Content.ToString();
            ToDoItemPOCO responsePOCO = Newtonsoft.Json.JsonConvert.DeserializeObject<ToDoItemPOCO>(jsonResponse);
            Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode);
            Assert.IsTrue(response.Result.Server == "cloudflare");
            Assert.IsTrue(response.Result.ContentType.Equals("application/json; charset=utf-8"));
            Assert.AreEqual("delectus aut autem", responsePOCO.Title);
            Assert.IsFalse(responsePOCO.Completed);
            Assert.AreEqual(1, responsePOCO.Id);

        }

        [TestMethod(), TestCategory("CRUD")]
        public void TestPostEndpoint()
        {
            var toDoItem = new ToDoItem { Title = "Water plants", Completed = true, UserId = 1 };
            var response = apiClient.PostRequestAsync(toDoItem);
            var jsonResponse = response.Result.Content.ToString();
            ToDoItemPOCO responsePOCO = Newtonsoft.Json.JsonConvert.DeserializeObject<ToDoItemPOCO>(jsonResponse);
            Assert.AreEqual(HttpStatusCode.Created, response.Result.StatusCode);
            Assert.IsTrue(response.Result.Server == "cloudflare");
            Assert.IsTrue(response.Result.ContentType.Equals("application/json; charset=utf-8"));
            Assert.AreEqual("Water plants", responsePOCO.Title);
            Assert.IsTrue(responsePOCO.Completed);
            Assert.AreEqual(1, responsePOCO.UserId);
        }

        [TestMethod(), TestCategory("CRUD")]
        public void TestDeleteEndpoint()
        {
            var response = apiClient.DeleteById(1);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(response.Server == "cloudflare");
        }
    }
}