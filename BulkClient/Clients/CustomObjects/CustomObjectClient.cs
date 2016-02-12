using System.Threading.Tasks;
using RestSharp;
using Eloqua.Api.Bulk.Models;
using Eloqua.Api.Bulk.Models.CustomObjects;

namespace Eloqua.Api.Bulk.Clients.CustomObjects
{
    public class CustomObjectClient
    {
        private readonly BaseClient _client;

        public CustomObjectClient(BaseClient client)
        {
            _client = client;
        }

        public async Task<SearchResponse<CustomObjectSearchResponse>> SearchCustomDataObjectsAsync(
            string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = $"/customObjects?search={searchTerm}&page={page}&pageSize={pageSize}"
            };

            IRestResponse<SearchResponse<CustomObjectSearchResponse>> customObjectSearchResponse =
                await _client.ExecuteTaskAsync<SearchResponse<CustomObjectSearchResponse>>(request);

            return customObjectSearchResponse.Data;
        }
    }
}
