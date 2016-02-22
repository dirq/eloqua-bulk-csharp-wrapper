using System.Threading.Tasks;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients
{
    public class JsonDataClient
    {
        readonly RestClient _client;

        public JsonDataClient(RestClient client)
        {
            _client = client;
        }

        public async Task<IRestResponse<T>> ExportDataAsync<T>(string exportUri)
        {
            var request = new RestRequest
            {
                Resource = string.Format("{0}/data", exportUri),
                RequestFormat = DataFormat.Json
            };

            return await _client.ExecuteTaskAsync<T>(request);
        }
    }
}
