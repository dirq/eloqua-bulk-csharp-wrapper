using RestSharp;
using System.Collections.Generic;
using Eloqua.Api.Bulk.Models;
using Eloqua.Api.Bulk.Models.Contacts;

namespace Eloqua.Api.Bulk.Clients.Contacts
{
    public class ContactFilterClient
    {
        private readonly BaseClient _client;

        public ContactFilterClient(BaseClient client)
        {
            _client = client;
        }

        public List<ContactFilter> Search(string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = $"/contact/fields?search={searchTerm}&page={page}&pageSize={pageSize}"
            };

            IRestResponse<SearchResponse<ContactFilter>> response =
                _client.Get<SearchResponse<ContactFilter>>(request);

            return response.Data.elements;
        }
    }
}