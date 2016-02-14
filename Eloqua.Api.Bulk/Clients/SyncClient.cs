using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models.Syncs;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients
{
    public class SyncClient
    {
        readonly BaseClient _client;

        public SyncClient(BaseClient client)
        {
            _client = client;
        }

        public async Task<Sync> CreateSyncAsync(Sync sync)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = BulkUrl.Syncs,
                RequestFormat = DataFormat.Json
            };

            request.AddBody(sync);

            IRestResponse<Sync> syncResponse = await _client.ExecuteTaskAsync<Sync>(request);

            return syncResponse.Data;
        }

        public async Task<Sync> GetSyncAsync(int syncId)
        {
            var request = new RestRequest(Method.GET) {Resource = $"/syncs/{syncId}"};

            IRestResponse<Sync> syncResponse = await _client.ExecuteTaskAsync<Sync>(request);

            return syncResponse.Data;
        }
    }
}
