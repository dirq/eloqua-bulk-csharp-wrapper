using System;
using System.Collections.Generic;
using Eloqua.Api.Bulk.Models.Syncs;

namespace Eloqua.Api.Bulk.Models.Exports
{
    /// <summary>
    /// Represents data that is retrieved from the Bulk API. It can be for example, the result of an activity.
    /// </summary>
    public class Export
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Dictionary<string, string> Fields { get; set; }
        public string Filter { get; set; }
        public long? KbUsed { get; set; }
        public string Name { get; set; }
        public int? SecondsToAutoDelete { get; set; }
        public int? SecondsToRetainData { get; set; }
        public List<SyncAction> SyncActions { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Uri { get; set; }
    }
}
