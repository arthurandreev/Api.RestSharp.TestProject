using RestSharp;
using System.Threading.Tasks;

namespace Api.RestSharp.TestFramework
{
    public class ApiClient
    {
        public ApiClient()
        {
        }
        public async Task<IRestResponse> GetRequestAsync()
        {
            var client = new RestClient("https://enctb0wvfhqy9.x.pipedream.net");
            var request = new RestRequest();
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<IRestResponse> PostRequestAsync(AreaCode areaCode)
        {
            var client = new RestClient("https://enctb0wvfhqy9.x.pipedream.net");
            var request = new RestRequest();
            request.AddJsonBody(areaCode);
            IRestResponse response = await client.ExecutePostAsync(request, cancellationToken: default);
            return response;
        }
    }
}