using RestSharp;
using System.Collections.Generic;
using Eloqua.Api.Bulk.Models;
using Eloqua.Api.Bulk.Models.Accounts;

namespace Eloqua.Api.Bulk.Clients.Accounts
{
    public class AccountFilterClient
    {
        private readonly BaseClient _client;

        public AccountFilterClient(BaseClient client)
        {
            _client = client;
        }

        public List<AccountFilter> Search(string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = $"/account/fields?search={searchTerm}&page={page}&pageSize={pageSize}"
            };

            IRestResponse<SearchResponse<AccountFilter>> response =
                _client.Get<SearchResponse<AccountFilter>>(request);

            return response.Data.elements;
        }
    }
}
