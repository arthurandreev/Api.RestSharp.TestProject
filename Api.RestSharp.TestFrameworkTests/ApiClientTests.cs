using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Api.RestSharp.TestFramework.Tests
{
    [TestClass()]
    public class ApiClientTests
    {
        ApiClient apiClient = new ApiClient();

        [TestMethod()]
        public void TestGetRequest()
        {
            var response = apiClient.GetRequestAsync();
            Assert.AreEqual("OK", response.Result.StatusCode.ToString());
        }

        [TestMethod]
        public void TestPostRequest()
        {
            var areaCode = new AreaCode { Code = 0131, City = "Edinburgh" };
            var response = apiClient.PostRequestAsync(areaCode);
            Assert.AreEqual("OK", response.Result.StatusCode.ToString());
            Assert.IsTrue(response.Result.ContentType.Equals("application/json; charset=utf-8"));
        }
    }
}