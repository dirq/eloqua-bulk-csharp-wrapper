using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models.Syncs;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients
{
    public class SyncClient
    {
        readonly BaseClient client;

        public SyncClient(BaseClient client)
        {
            this.client = client;
        }

        public async Task<Sync> CreateSyncAsync(Sync sync)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = BulkUrl.Syncs,
                RequestFormat = DataFormat.Json
            };

            request.AddBody(sync);

            var syncResponse = await client.ExecuteTaskAsync<Sync>(request);

            return syncResponse.Data;
        }

        public async Task<Sync> GetSyncAsync(int syncId)
        {
            var request = new RestRequest(Method.GET) {Resource = $"/syncs/{syncId}"};

            var syncResponse = await client.ExecuteTaskAsync<Sync>(request);

            return syncResponse.Data;
        }
    }
}