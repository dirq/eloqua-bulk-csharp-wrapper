using Eloqua.Api.Bulk.Models.Syncs;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients
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
        public virtual Sync CreateSync(Sync sync) => Client.Syncs.CreateSync(sync);

        /// <summary>
        /// Exports the data from the given URI in JSON format
        /// </summary>
        /// <param name="exportUri">The URI where the data shoud be retreived from</param>
        /// <returns>A response with its data in JSON format</returns>
        public virtual IRestResponse ExportData(string exportUri) => Client.JsonData.ExportData(exportUri);
    }
}
