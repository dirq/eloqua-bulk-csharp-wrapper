using System.Collections.Generic;
using System.Threading.Tasks;
using Eloqua.Api.Bulk.Clients.Base;
using Eloqua.Api.Bulk.Models.Imports;
using Eloqua.Api.Bulk.Models.Syncs;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients.CustomObjects
{
    public class CustomObjectImportClient : ImportClient
    {
        public CustomObjectImportClient(BaseClient client) : base(client)
        {
        }

        public async Task<Import> CreateImportAsync(Import import, int customObjectId)
        {
            return await base.CreateImportAsync(import, string.Format("customObject/{0}", customObjectId));
        }

        public async Task<Sync> ImportDataAsync(string importUri, List<Dictionary<string, string>> data)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = string.Format("{0}/data", importUri),
                RequestFormat = DataFormat.Json
            };

            request.AddBody(data);

            IRestResponse<Sync> syncResponse = await Client.ExecuteTaskAsync<Sync>(request);

            return syncResponse.Data;
        }
    }
}
