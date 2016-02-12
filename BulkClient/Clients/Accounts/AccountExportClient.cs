using System.Threading.Tasks;
using Eloqua.Api.Bulk.Clients.Base;
using RestSharp;
using Eloqua.Api.Bulk.Models.Exports;

namespace Eloqua.Api.Bulk.Clients.Accounts
{
    /// <summary>
    /// Exporter for account objects (untested)
    /// </summary>
    public class AccountExportClient : ExportClient
    {
        /// <summary>
        /// Creates an instance of this class with the provided client
        /// </summary>
        /// <param name="client">The client to be used to connect with the Bulk API</param>
        public AccountExportClient(BaseClient client) : base(client)
        {
        }

        /// <summary>
        /// Creates an export in the resource with URI /account/export. Please note that this has not been tested in
        /// the Bulk API version 2.
        /// </summary>
        /// <param name="export">The export object to be created</param>
        /// <returns>The newly created export object</returns>
        public async Task<Export> CreateExportAsync(Export export)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = "/account/export",
                RequestFormat = DataFormat.Json
            };

            request.AddBody(export);

            IRestResponse<Export> exportResponse = await Client.ExecuteTaskAsync<Export>(request);

            return exportResponse.Data;
        }
    }
}
