namespace Eloqua.Api.Bulk.Clients
{
    /// <summary>
    /// URLs used for requests to the BULK API. Please note that those that include formatting are not listed here.
    /// All these paths are relative.
    /// </summary>
    public static class BulkUrl
    {
        public const string Login = "https://login.eloqua.com";

        public const string Syncs = "/syncs";

        public const string ContactExports = "/contacts/exports";
        public const string ActivityExports = "/activities/exports";
        public const string AccountExports = "/account/exports";
    }
}