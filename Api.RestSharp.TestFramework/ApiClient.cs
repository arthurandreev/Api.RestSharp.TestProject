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
            var client = new RestClient("https://jsonplaceholder.typicode.com/todos");
            var request = new RestRequest();
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }
            
        public async Task<IRestResponse> PostRequestAsync(ToDoItem toDoItem)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/todos");
            var request = new RestRequest();
            request.AddJsonBody(toDoItem);
            IRestResponse response = await client.ExecutePostAsync(request, cancellationToken: default);
            return response;
        }

        public async Task<IRestResponse> GetByIdRequestAsync(int id)
        {
            string toDoId = id.ToString();
            var client = new RestClient($"https://jsonplaceholder.typicode.com/todos/{toDoId}");
            var request = new RestRequest();
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        public IRestResponse DeleteByIdRequest(int id)
        {
            string toDoId = id.ToString();
            var client = new RestClient($"https://jsonplaceholder.typicode.com/todos/{toDoId}");
            var request = new RestRequest();
            IRestResponse response = client.Delete(request);
            return response;
        }

        public IRestResponse PutRequest(int id, ToDoItemPOCO toDoItemPOCO)
        {
            string toDoId = id.ToString();
            var client = new RestClient($"https://jsonplaceholder.typicode.com/todos/{toDoId}");
            var request = new RestRequest();
            request.AddJsonBody(toDoItemPOCO);
            IRestResponse response = client.Put(request);
            return response;
        }
    }
}