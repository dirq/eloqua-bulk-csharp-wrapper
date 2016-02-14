using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models.Exports;

namespace Eloqua.Api.Bulk.Clients.CustomObjects
{
    /// <summary>
    /// Exporter for custom objects (untested)
    /// </summary>
    public class CustomObjectExportClient
    {
        private readonly ExportClient _exportClient;

        /// <summary>
        /// Creates an instance of this class with the default <see cref="ExportClient"/>
        /// </summary>
        public CustomObjectExportClient(BaseClient client) : this(new ExportClient(client))
        {
        }

        private CustomObjectExportClient(ExportClient exportClient)
        {
            _exportClient = exportClient;
        }

        /// <summary>
        /// Creates an export in the resource with URI /customObject/<see cref="customObjectId"/>/export. Please note
        /// that this has not been tested in the Bulk API version 2.
        /// </summary>
        /// <param name="export">The export object to be created</param>
        /// <param name="customObjectId">The unique identifier of the custom object</param>
        /// <returns>The newly created export object</returns>
        public async Task<Export> CreateExportAsync(Export export, int customObjectId) =>
            await _exportClient.CreateExportAsync(export, $"/customObject/{customObjectId}/export");
    }
}