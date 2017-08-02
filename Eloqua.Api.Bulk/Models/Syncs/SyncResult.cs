using System;

namespace Eloqua.Api.Bulk.Models.Syncs
{
    public class SyncResult
    {
        public int? Count { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Message { get; set; }
        public string SyncUri { get; set; }
    }
}