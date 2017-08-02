using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients.CustomObjects
{
    public class CustomObjectFieldClient
    {
        readonly BaseClient client;

        public CustomObjectFieldClient(BaseClient client)
        {
            this.client = client;
        }

        public async Task<SearchResponse<Field>> SearchAsync(int customObjectId, string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource =
                    $"/customObject/{customObjectId}/fields??search={searchTerm}&page={page}&pageSize={pageSize}"
            };

            var fieldSearchResponse =
                await client.ExecuteTaskAsync<SearchResponse<Field>>(request);

            return fieldSearchResponse.Data;
        }
    }
}