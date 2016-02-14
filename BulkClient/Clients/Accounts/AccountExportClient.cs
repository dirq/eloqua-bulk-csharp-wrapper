using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models.Exports;

namespace Eloqua.Api.Bulk.Clients.Accounts
{
    /// <summary>
    /// Exporter for account objects (untested)
    /// </summary>
    public class AccountExportClient 
    {
        private readonly ExportClient _exportClient;

        /// <summary>
        /// Creates an instance of this class with the provided client
        /// </summary>
        /// <param name="client">The client to be used to connect with the Bulk API</param>
        public AccountExportClient(BaseClient client) : this(new ExportClient(client))
        {
        }

        private AccountExportClient(ExportClient exportClient)
        {
            _exportClient = exportClient;
        }

        /// <summary>
        /// Creates an export in the resource with URI /account/export. Please note that this has not been tested in
        /// the Bulk API version 2.
        /// </summary>
        /// <param name="export">The export object to be created</param>
        /// <returns>The newly created export object</returns>
        public async Task<Export> CreateExportAsync(Export export) =>
            await _exportClient.CreateExportAsync(export, BulkUrl.AccountExports);
    }
}
