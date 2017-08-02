using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients.Contacts
{
    public class ContactFieldClient
    {
        readonly BaseClient client;

        public ContactFieldClient(BaseClient client)
        {
            this.client = client;
        }

        public async Task<SearchResponse<Field>> SearchAsync(string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = $"/contact/fields?search={searchTerm}&page={page}&pageSize={pageSize}"
            };

            var fieldSearchResponse =
                await client.ExecuteTaskAsync<SearchResponse<Field>>(request);

            return fieldSearchResponse.Data;
        }
    }
}