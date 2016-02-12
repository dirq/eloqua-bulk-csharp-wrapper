using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models.Syncs;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients.Base
{
    /// <summary>
    /// Exposes basic functionality of clients intended to export data
    /// </summary>
    public abstract class ExportClient
    {
        protected BaseClient Client { get; set; }

        protected ExportClient(BaseClient client)
        {
            Client = client;
        }

        /// <summary>
        /// Creates a <see cref="Sync"/> object through the Bulk API to be able to track progress
        /// </summary>
        /// <param name="sync">The synching object to be created</param>
        /// <returns>The newly created synching object</returns>
        public virtual async Task<Sync> CreateSyncAsync(Sync sync) => await Client.Syncs.CreateSyncAsync(sync);

        /// <summary>
        /// Exports the data from the given URI in JSON format
        /// </summary>
        /// <param name="exportUri">The URI where the data shoud be retreived from</param>
        /// <returns>A response with its data in JSON format</returns>
        public virtual async Task<IRestResponse> ExportDataAsync(string exportUri) =>
            await Client.JsonData.ExportDataAsync(exportUri);
    }
}
