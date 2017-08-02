using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models;
using Eloqua.Api.Bulk.Models.CustomObjects;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients.CustomObjects
{
    public class CustomObjectClient
    {
        private readonly BaseClient client;

        public CustomObjectClient(BaseClient client)
        {
            this.client = client;
        }

        public async Task<SearchResponse<CustomObjectSearchResponse>> SearchCustomDataObjectsAsync(
            string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = $"/customObjects?search={searchTerm}&page={page}&pageSize={pageSize}"
            };

            var customObjectSearchResponse =
                await client.ExecuteTaskAsync<SearchResponse<CustomObjectSearchResponse>>(request);

            return customObjectSearchResponse.Data;
        }
    }
}