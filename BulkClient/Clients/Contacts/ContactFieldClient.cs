using RestSharp;
using Eloqua.Api.Bulk.Models;

namespace Eloqua.Api.Bulk.Clients.Contacts
{
    public class ContactFieldClient
    {
        readonly BaseClient _client;

        public ContactFieldClient(BaseClient client)
        {
            _client = client;
        }

        public SearchResponse<Field> Search(string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = $"/contact/fields?search={searchTerm}&page={page}&pageSize={pageSize}"
            };

            return _client.Execute<SearchResponse<Field>>(request).Data;
        }
    }
}