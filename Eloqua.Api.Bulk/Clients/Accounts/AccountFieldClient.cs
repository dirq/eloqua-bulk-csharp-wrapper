using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients.Accounts
{
    public class AccountFieldClient
    {
        private readonly BaseClient client;

        public AccountFieldClient(BaseClient client)
        {
            this.client = client;
        }

        public async Task<SearchResponse<Field>> SearchAsync(string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = $"/account/fields?search={searchTerm}&page={page}&pageSize={pageSize}"
            };

            var fieldSearchResponse =
                await client.ExecuteTaskAsync<SearchResponse<Field>>(request);

            return fieldSearchResponse.Data;
        }
    }
}