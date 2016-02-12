using Eloqua.Api.Bulk.Models;
using Eloqua.Api.Bulk.Models.Imports;
using Eloqua.Api.Bulk.Models.Syncs;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients
{
    public abstract class ImportClient
    {
        protected readonly BaseClient Client;

        protected ImportClient(BaseClient client)
        {
            Client = client;
        }

        public virtual Import CreateImport(Import import, string resourceName)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = $"/{resourceName}/import",
                RequestFormat = DataFormat.Json,
                RootElement = "import"
            };

            request.AddBody(import);

            return Client.Execute<Import>(request).Data;
        }

        public SearchResponse<SyncResult> CheckSyncResult(string syncUri)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = syncUri + "/results",
                RequestFormat = DataFormat.Json
            };

            return Client.Execute<SearchResponse<SyncResult>>(request).Data;
        }
    }
}
