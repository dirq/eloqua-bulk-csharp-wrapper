namespace Eloqua.Api.Bulk.Clients
{
    /// <summary>
    /// URLs used for requests to the BULK API. Please note that those that include formatting are not listed here.
    /// </summary>
    internal static class BulkUrl
    {
        internal const string Login = "https://login.eloqua.com";

        internal const string Syncs = "/syncs";

        internal const string ContactExports = "/contacts/exports";
        internal const string ActivityExports = "/activities/exports";
        internal const string AccountExports = "/account/exports";
    }
}