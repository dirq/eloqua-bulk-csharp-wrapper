using System;
using Eloqua.Api.Bulk.Models.Exports;

namespace Eloqua.Api.Bulk.Models.Syncs
{
    /// <summary>
    /// Serves to know the state of a process being made, like a <see cref="Export"/> being processed.
    /// </summary>
    public class Sync
    {
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public SyncStatusType? Status { get; set; }
        public string SyncedInstanceUri { get; set; }
        public DateTime? SyncEndedAt { get; set; }
        public DateTime? SyncStartedAt { get; set; }
        public string Uri { get; set; }

        /// <summary>
        /// Returns the id of this sync taking it out from the <see cref="Uri"/>
        /// </summary>
        /// <returns>The unique identifier of this sync extracted from the <see cref="Uri"/></returns>
        public int? GetId()
        {
            int id;

            if (string.IsNullOrWhiteSpace(Uri) || !int.TryParse(Uri.Split('/')[2], out id))
            {
                return null;
            }

            return id;
        }
    }
}
