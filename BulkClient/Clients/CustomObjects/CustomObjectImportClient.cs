using System.Collections.Generic;
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

        public Import CreateImport(Import import, int customObjectId) =>
            base.CreateImport(import, $"customObject/{customObjectId}");

        public Sync ImportData(string importUri, List<Dictionary<string, string>> data)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = $"{importUri}/data",
                RequestFormat = DataFormat.Json
            };

            request.AddBody(data);

            return Client.Execute<Sync>(request).Data;
        }
    }
}
