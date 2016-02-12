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

        public Sync CreateSync(Sync sync)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = "/syncs",
                RequestFormat = DataFormat.Json
            };

            request.AddBody(sync);

            return _client.Execute<Sync>(request).Data;
        }

        public Sync GetSync(int syncId)
        {
            var request = new RestRequest(Method.GET) {Resource = $"/syncs/{syncId}"};

            return _client.Execute<Sync>(request).Data;
        }
    }
}
