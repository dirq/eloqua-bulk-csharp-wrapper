using System.Collections.Generic;
using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients.Base
{
    public abstract class FilterClient
    {
        protected readonly BaseClient Client;

        protected FilterClient(BaseClient client)
        {
            Client = client;
        }

        protected virtual async Task<List<Filter>> SearchAsync(
            string searchTerm, int page, int pageSize, string resourceName)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = string.Format("/{0}/fields?search={1}&page={2}&pageSize={3}",
                    resourceName, searchTerm, page, pageSize)
            };

            IRestResponse<SearchResponse<Filter>> response =
                await Client.ExecuteTaskAsync<SearchResponse<Filter>>(request);

            return response.Data.Elements;
        }
    }
}
