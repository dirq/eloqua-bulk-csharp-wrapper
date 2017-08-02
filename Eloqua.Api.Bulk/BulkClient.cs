using System.Threading.Tasks;
using Eloqua.Api.Bulk.Clients;
using Eloqua.Api.Bulk.Clients.Accounts;
using Eloqua.Api.Bulk.Clients.Activities;
using Eloqua.Api.Bulk.Clients.Contacts;
using Eloqua.Api.Bulk.Clients.CustomObjects;
using Eloqua.Api.Bulk.Models.Login;
using RestSharp;

namespace Eloqua.Api.Bulk
{
    /// <summary>
    ///     Entry point of the wrapper. This is the proxy point to access the available services exposed.
    /// </summary>
    public class BulkClient
    {
        private readonly BaseClient baseClient;

        private ExportClient exportClient;

        private ContactExportClient contactExportClient;
        private ContactFieldClient contactFieldClient;
        private ContactFilterClient contactFilterClient;
        private ContactImportClient contactImportClient;
        private ActivityExportClient activityExportClient;

        private CustomObjectFieldClient customObjectFieldClient;
        private CustomObjectExportClient customObjectExportClient;
        private CustomObjectImportClient customObjectImportClient;

        private AccountFieldClient accountFieldClient;
        private AccountFilterClient accountFilterClient;
        private AccountImportClient accountImportClient;

        /// <summary>
        ///     Creates an instance of the client to access Bulk version 2 API.
        /// </summary>
        /// <param name="site">
        ///     The site for accessing Eloqua services, this is tipically the company name. This is the same used to access
        ///     Eloqua website.
        /// </param>
        /// <param name="user">The username. This is the same used to access Eloqua website.</param>
        /// <param name="password">The password of the account. This is the same used to access Eloqua website.</param>
        /// <param name="baseUrl">
        ///     The base URL for the requests. This is something like https://secure.p01.eloqua.com/API/Bulk/2.0/. You can
        ///     get the right one for a given account with <see cref="GetAccountInfoAsync" /> method.
        /// </param>
        public BulkClient(string site, string user, string password, string baseUrl)
        {
            baseClient = new BaseClient(site, user, password, baseUrl);
        }

        /// <summary>
        ///     Returns the information for a given Eloqua account.
        /// </summary>
        /// <param name="site">
        ///     The site for accessing Eloqua services, this is tipically the company name. This is the same used to access
        ///     Eloqua website.
        /// </param>
        /// <param name="user">The username. This is the same used to access Eloqua website.</param>
        /// <param name="password">The password of the account. This is the same used to access Eloqua website.</param>
        /// <returns>The information for the given account. It is directly retrieved from Eloqua.</returns>
        public static async Task<AccountInfo> GetAccountInfoAsync(string site, string user, string password)
        {
            var client = new BaseClient(site, user, password, BulkUrl.Login);

            var responseAccountInfo =
                await client.ExecuteTaskAsync<AccountInfo>(new RestRequest("id", Method.GET));

            return responseAccountInfo.Data;
        }

        /// <summary>
        ///     Default <see cref="SyncClient" />
        /// </summary>
        public SyncClient Syncs => baseClient.Syncs;

        /// <summary>
        ///     Default <see cref="Eloqua.Api.Bulk.Clients.ExportClient" />
        /// </summary>
        public ExportClient ExportClient => exportClient ?? (exportClient = new ExportClient(baseClient));

        /// <summary>
        ///     Default <see cref="Eloqua.Api.Bulk.Clients.Activities.ActivityExportClient" />
        /// </summary>
        public ActivityExportClient ActivityExportClient
            => activityExportClient ?? (activityExportClient = new ActivityExportClient(baseClient));

        #region contacts

        /// <summary>
        ///     Default <see cref="ContactFieldClient" />
        /// </summary>
        public ContactFieldClient ContactFields =>
            contactFieldClient ?? (contactFieldClient = new ContactFieldClient(baseClient));

        /// <summary>
        ///     Default <see cref="ContactExportClient" />
        /// </summary>
        public ContactExportClient ContactExport =>
            contactExportClient ?? (contactExportClient = new ContactExportClient(baseClient));

        /// <summary>
        ///     Default <see cref="ContactFilterClient" />
        /// </summary>
        public ContactFilterClient ContactFilters =>
            contactFilterClient ?? (contactFilterClient = new ContactFilterClient(baseClient));

        /// <summary>
        ///     Default <see cref="ContactImportClient" />
        /// </summary>
        public ContactImportClient ContactImport =>
            contactImportClient ?? (contactImportClient = new ContactImportClient(baseClient));

        #endregion

        #region custom objects

        /// <summary>
        ///     Default <see cref="CustomObjectFieldClient" />
        /// </summary>
        public CustomObjectFieldClient CustomObjectFields =>
            customObjectFieldClient ?? (customObjectFieldClient = new CustomObjectFieldClient(baseClient));

        /// <summary>
        ///     Default <see cref="CustomObjectExportClient" />
        /// </summary>
        public CustomObjectExportClient CustomObjectExport =>
            customObjectExportClient ?? (customObjectExportClient = new CustomObjectExportClient(baseClient));

        /// <summary>
        ///     Default <see cref="CustomObjectImportClient" />
        /// </summary>
        public CustomObjectImportClient CustomObjectImport =>
            customObjectImportClient ?? (customObjectImportClient = new CustomObjectImportClient(baseClient));

        #endregion

        #region accounts

        /// <summary>
        ///     Default <see cref="AccountFieldClient" />
        /// </summary>
        public AccountFieldClient AccountFields =>
            accountFieldClient ?? (accountFieldClient = new AccountFieldClient(baseClient));

        /// <summary>
        ///     Default <see cref="AccountFilterClient" />
        /// </summary>
        public AccountFilterClient AccountFilters =>
            accountFilterClient ?? (accountFilterClient = new AccountFilterClient(baseClient));

        /// <summary>
        ///     Default <see cref="AccountImportClient" />
        /// </summary>
        public AccountImportClient AccountImport =>
            accountImportClient ?? (accountImportClient = new AccountImportClient(baseClient));

        #endregion
    }
}