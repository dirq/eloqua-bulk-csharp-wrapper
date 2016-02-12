namespace Eloqua.Api.Bulk.Models.Syncs
{
    public class SyncAction
    {
        public SyncActionType? Action { get; set; }
        public string DestinationUri { get; set; }
    }
}
