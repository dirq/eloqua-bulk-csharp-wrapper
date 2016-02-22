using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models;
using Eloqua.Api.Bulk.Models.Exports;
using Eloqua.Api.Bulk.Models.Syncs;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients
{
    /// <summary>
    /// Exposes basic functionality of clients intended to export data
    /// </summary>
    public class ExportClient
    {
        protected BaseClient Client;

        /// <summary>
        /// Initializes a client for exporting with the given client.
        /// </summary>
        /// <param name="client">The client to be used to interact with the Bulk API.</param>
        public ExportClient(BaseClient client)
        {
            Client = client;
        }

        /// <summary>
        /// Creates a <see cref="Sync"/> object through the Bulk API to be able to track progress
        /// </summary>
        /// <param name="sync">The synching object to be created</param>
        /// <returns>The newly created synching object</returns>
        public virtual async Task<Sync> CreateSyncAsync(Sync sync)
        {
            return await Client.Syncs.CreateSyncAsync(sync);
        }

        /// <summary>
        /// Exports the data from the given URI in JSON format
        /// </summary>
        /// <param name="exportUri">The URI where the data shoud be retreived from</param>
        /// <returns>A response with its data in JSON format</returns>
        public virtual async Task<IRestResponse<T>> ExportDataAsync<T>(string exportUri)
        {
            return await Client.JsonData.ExportDataAsync<T>(exportUri);
        }

        /// <summary>
        /// Issues an <see cref="Export"/> object and returns the object that can be used to know its state.
        /// </summary>
        /// <param name="exportToBeIssued">The export that is going to be processed</param>
        /// <param name="exportUri">The URI of the export. Some of these are available at <see cref="BulkUrl"/></param>
        /// <returns>An object that lets you know if the export is done</returns>
        public virtual async Task<Sync> IssueExport(Export exportToBeIssued, string exportUri)
        {
            Export issuedExport = await CreateExportAsync(exportToBeIssued, exportUri);

            var issuedExportSync = new Sync
            {
                Status = SyncStatus.Pending,
                SyncedInstanceUri = issuedExport.Uri
            };

            return await CreateSyncAsync(issuedExportSync);
        }

        /// <summary>
        /// Returns the export result of the export related to a iven <see cref="Sync"/> if the processing is finished.
        /// If the processing is not finished yet, <code>null</code> is returned.
        /// </summary>
        /// <typeparam name="T">
        /// The expected inner type of the export result in which the response should be serialized to
        /// </typeparam>
        /// <param name="syncId">The id of the <see cref="Sync"/> that is related to the target export</param>
        /// <returns>
        /// The export result of the export related to the given <see cref="Sync"/> if the processing of the export
        /// is done. If the processing is not done yet, <code>null</code> is returned.
        /// </returns>
        public virtual async Task<ExportResult<T>> GetExportResultIfFinished<T>(int syncId)
        {
            Sync sync = await Client.Syncs.GetSyncAsync(syncId);

            if (sync.Status == SyncStatus.Success)
            {
                IRestResponse<ExportResult<T>> exportResponse =
                    await ExportDataAsync<ExportResult<T>>(sync.SyncedInstanceUri);

                return exportResponse.Data;
            }

            return null;
        }

        /// <summary>
        /// Creates an export in the resource with the specified URI
        /// </summary>
        /// <param name="export">The export object to be created</param>
        /// <param name="resourceUri">The URI of the export object</param>
        /// <returns>The newly created export object</returns>
        public async Task<Export> CreateExportAsync(Export export, string resourceUri)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = resourceUri,
                RequestFormat = DataFormat.Json
            };

            request.AddBody(export);

            IRestResponse<Export> exportResponse = await Client.ExecuteTaskAsync<Export>(request);

            return exportResponse.Data;
        }
    }
}
