using RestSharp;
using System.Threading.Tasks;

namespace Api.RestSharp.TestFramework
{
    public class ApiClient
    {
        private static readonly string baseUrl = "https://jsonplaceholder.typicode.com";
        public ApiClient() {}
        public async Task<IRestResponse> GetRequestAsync()
        {
            var client = new RestClient($"{baseUrl}/todos");
            var request = new RestRequest();
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }
            
        public async Task<IRestResponse> PostRequestAsync(ToDoItemPOCOWithoutId toDoItem)
        {
            var client = new RestClient($"{baseUrl}/todos");
            var request = new RestRequest();
            request.AddJsonBody(toDoItem);
            IRestResponse response = await client.ExecutePostAsync(request);
            return response;
        }

        public async Task<IRestResponse> GetByIdRequestAsync(int id)
        {
            string toDoId = id.ToString();
            var client = new RestClient($"{baseUrl}/todos/{toDoId}");
            var request = new RestRequest();
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<IRestResponse> DeleteByIdRequestAsync(int id)
        {
            string toDoId = id.ToString();
            var client = new RestClient($"{baseUrl}/todos/{toDoId}");
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<IRestResponse> PutRequestAsync(int id, ToDoItemPOCOWithId toDoItemPOCO)
        {
            string toDoId = id.ToString();
            var client = new RestClient($"{baseUrl}/todos/{toDoId}");
            var request = new RestRequest(Method.PUT);
            request.AddJsonBody(toDoItemPOCO);
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }
    }
}