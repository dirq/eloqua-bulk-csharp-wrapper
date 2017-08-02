using System.Threading.Tasks;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients
{
    public class JsonDataClient
    {
        readonly RestClient client;

        public JsonDataClient(RestClient client)
        {
            this.client = client;
        }

        public async Task<IRestResponse<T>> ExportDataAsync<T>(string exportUri)
        {
            var request = new RestRequest
            {
                Resource = $"{exportUri}/data",
                RequestFormat = DataFormat.Json
            };

            return await client.ExecuteTaskAsync<T>(request);
        }
    }
}