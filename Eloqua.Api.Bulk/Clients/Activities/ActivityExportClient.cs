using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models.Exports;

namespace Eloqua.Api.Bulk.Clients.Activities
{
    /// <summary>
    /// Exporter for activity objects
    /// </summary>
    public class ActivityExportClient
    {
        private readonly ExportClient _exportClient;

        /// <summary>
        /// Creates an instance of this class with the provided client
        /// </summary>
        /// <param name="client">The client to be used to connect with the Bulk API</param>
        public ActivityExportClient(BaseClient client) : this(new ExportClient(client))
        {
        }

        private ActivityExportClient(ExportClient exportClient)
        {
            _exportClient = exportClient;
        }

        /// <summary>
        /// Creates an export in the resource with URI /activities/exports.
        /// </summary>
        /// <param name="export">The export object to be created</param>
        /// <returns>The newly created export object</returns>
        public async Task<Export> CreateExportAsync(Export export) =>
            await _exportClient.CreateExportAsync(export, BulkUrl.ActivityExports);
    }
}
