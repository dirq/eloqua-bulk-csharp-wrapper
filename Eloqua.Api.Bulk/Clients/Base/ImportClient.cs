using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models;
using Eloqua.Api.Bulk.Models.Imports;
using Eloqua.Api.Bulk.Models.Syncs;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients.Base
{
    public abstract class ImportClient
    {
        protected readonly BaseClient Client;

        protected ImportClient(BaseClient client)
        {
            Client = client;
        }

        public virtual async Task<Import> CreateImportAsync(Import import, string resourceName)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = $"/{resourceName}/import",
                RequestFormat = DataFormat.Json,
                RootElement = "import"
            };

            request.AddBody(import);

            IRestResponse<Import> importResponse = await Client.ExecuteTaskAsync<Import>(request);

            return importResponse.Data;
        }

        public async Task<SearchResponse<SyncResult>> CheckSyncResultAsync(string syncUri)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = $"{syncUri}/results",
                RequestFormat = DataFormat.Json
            };

            IRestResponse<SearchResponse<SyncResult>> restResponse =
                await Client.ExecuteTaskAsync<SearchResponse<SyncResult>>(request);

            return restResponse.Data;
        }
    }
}
