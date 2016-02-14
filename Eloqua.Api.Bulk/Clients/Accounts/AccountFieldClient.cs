using System.Threading.Tasks;
using RestSharp;
using Eloqua.Api.Bulk.Models;

namespace Eloqua.Api.Bulk.Clients.Accounts
{
    public class AccountFieldClient
    {
        private readonly BaseClient _client;

        public AccountFieldClient(BaseClient client)
        {
            _client = client;
        }

        public async Task<SearchResponse<Field>> SearchAsync(string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = $"/account/fields?search={searchTerm}&page={page}&pageSize={pageSize}"
            };

            IRestResponse<SearchResponse<Field>> fieldSearchResponse =
                await _client.ExecuteTaskAsync<SearchResponse<Field>>(request);

            return fieldSearchResponse.Data;
        }
    }
}
