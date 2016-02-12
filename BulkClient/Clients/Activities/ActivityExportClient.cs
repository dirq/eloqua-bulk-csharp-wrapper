using Eloqua.Api.Bulk.Models.Exports;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients.Activities
{
    /// <summary>
    /// Exporter for activity objects
    /// </summary>
    public class ActivityExportClient : ExportClient
    {
        /// <summary>
        /// Creates an instance of this class with the provided client
        /// </summary>
        /// <param name="client">The client to be used to connect with the Bulk API</param>
        public ActivityExportClient(BaseClient client) : base(client)
        {
        }

        /// <summary>
        /// Creates an export in the resource with URI /activities/exports.
        /// </summary>
        /// <param name="export">The export object to be created</param>
        /// <returns>The newly created export object</returns>
        public Export CreateExport(Export export)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = "/activities/exports",
                RequestFormat = DataFormat.Json
            };

            request.AddBody(export);

            return Client.Execute<Export>(request).Data;
        }
    }
}
