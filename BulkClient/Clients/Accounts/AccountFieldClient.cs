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

        public SearchResponse<Field> Search(string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = $"/account/fields?search={searchTerm}&page={page}&pageSize={pageSize}"
            };

            return _client.Execute<SearchResponse<Field>>(request).Data;
        }
    }
}
