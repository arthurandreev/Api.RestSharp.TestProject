using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Program
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await MakeRequest();
        }

        private static async Task MakeRequest()
        {
            //var httpClient = new HttpClient();
            //var response = await httpClient.GetAsync(new Uri("https://en0ia1md79e1w6.x.pipedream.net"));
            //var body = await response.Content.ReadAsStringAsync();
            var client = new RestClient("https://enctb0wvfhqy9.x.pipedream.net");
            //client.Authenticator = new HttpBasicAuthenticator("binary_byron", "SvotBrot$87$");

            var request = new RestRequest();

           // var response = client.Get(request);
            var response = await client.GetAsync<PipeDreamResponse>(request);

            Console.WriteLine(response.ResponseStatus, response.StatusCode);
            Assert.AreEqual(response.ResponseStatus.ToString(), "OK");
            Assert.IsTrue(response.StatusCode.ToString() == "200");
        }
}
}
