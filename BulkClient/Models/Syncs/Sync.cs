using System;

namespace Eloqua.Api.Bulk.Models.Syncs
{
    public class Sync
    {
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public SyncStatusType? Status { get; set; }
        public string SyncedInstanceUri { get; set; }
        public DateTime? SyncEndedAt { get; set; }
        public DateTime? SyncStartedAt { get; set; }
        public string Uri { get; set; }
    }
}
