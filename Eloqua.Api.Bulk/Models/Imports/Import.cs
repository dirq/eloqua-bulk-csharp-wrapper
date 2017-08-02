using System.Collections.Generic;
using Eloqua.Api.Bulk.Models.Syncs;

namespace Eloqua.Api.Bulk.Models.Imports
{
    public class Import
    {
        public Dictionary<string, string> Fields { get; set; }
        public string ImportPriorityUri { get; set; }
        public string IdentifierFieldName { get; set; }
        public bool IsSyncTriggeredOnImport { get; set; }
        public long? KbUsed { get; set; }
        public string Name { get; set; }
        public int? SecondsToRetainData { get; set; }
        public int? SecondsToAutoDelete { get; set; }
        public List<SyncAction> SyncActions { get; set; }
        public RuleType? UpdateRule { get; set; }
        public string Uri { get; set; }
    }
}