using System.Threading.Tasks;
using Eloqua.Api.Bulk.Clients.Base;
using RestSharp;
using Eloqua.Api.Bulk.Models.Exports;

namespace Eloqua.Api.Bulk.Clients.Contacts
{
    /// <summary>
    /// Exporter for contacts
    /// </summary>
    public class ContactExportClient : ExportClient
    {
        /// <summary>
        /// Creates an instance of this class with the provided client
        /// </summary>
        /// <param name="client">The client to be used to connect with the Bulk API</param>
        public ContactExportClient(BaseClient client) : base(client)
        {
        }

        /// <summary>
        /// Creates an export in the resource with URI /contacts/exports.
        /// </summary>
        /// <param name="export">The export object to be created</param>
        /// <returns>The newly created export object</returns>
        public async Task<Export> CreateExportAsync(Export export)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = "/contacts/exports",
                RequestFormat = DataFormat.Json
            };

            request.AddBody(export);

            IRestResponse<Export> exportResponse = await Client.ExecuteTaskAsync<Export>(request);

            return exportResponse.Data;
        }
    }
}