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

        public async Task<IRestResponse> ExportDataAsync(string exportUri)
        {
            var request = new RestRequest
            {
                Resource = exportUri + "/data",
                RequestFormat = DataFormat.Json
            };

            return await _client.ExecuteTaskAsync(request);
        }
    }
}
