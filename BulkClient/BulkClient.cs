using System.Threading.Tasks;
using Eloqua.Api.Bulk.Clients;
using RestSharp;
using Eloqua.Api.Bulk.Clients.Accounts;
using Eloqua.Api.Bulk.Clients.Activities;
using Eloqua.Api.Bulk.Clients.Contacts;
using Eloqua.Api.Bulk.Clients.CustomObjects;
using Eloqua.Api.Bulk.Models.Login;

namespace Eloqua.Api.Bulk
{
    /// <summary>
    /// Entry point of the wrapper. This is the proxy point to access the available services exposed.
    /// </summary>
    public class BulkClient
    {
        private readonly BaseClient _baseClient;

        private ExportClient _exportClient;
        private ContactFieldClient _contactFieldClient;
        private ContactFilterClient _contactFilterClient;
        private ContactImportClient _contactImportClient;
        private ActivityExportClient _activityExportClient;

        private CustomObjectFieldClient _customObjectFieldClient;
        private CustomObjectExportClient _customObjectExportClient;
        private CustomObjectImportClient _customObjectImportClient;

        private AccountFieldClient _accountFieldClient;
        private AccountFilterClient _accountFilterClient;
        private AccountImportClient _accountImportClient;

        /// <summary>
        /// Creates an instance of the client to access Bulk version 2 API.
        /// </summary>
        /// <param name="site">
        /// The site for accessing Eloqua services, this is tipically the company name. This is the same used to access
        /// Eloqua website.
        /// </param>
        /// <param name="user">The username. This is the same used to access Eloqua website.</param>
        /// <param name="password">The password of the account. This is the same used to access Eloqua website.</param>
        /// <param name="baseUrl">
        /// The base URL for the requests. This is something like https://secure.p01.eloqua.com/API/Bulk/2.0/. You can
        /// get the right one for a given account with <see cref="GetAccountInfoAsync"/> method.
        /// </param>
        public BulkClient(string site, string user, string password, string baseUrl)
        {
            _baseClient = new BaseClient(site, user, password, baseUrl);
        }

        /// <summary>
        /// Returns the information for a given Eloqua account.
        /// </summary>
        /// <param name="site">
        /// The site for accessing Eloqua services, this is tipically the company name. This is the same used to access
        /// Eloqua website.
        /// </param>
        /// <param name="user">The username. This is the same used to access Eloqua website.</param>
        /// <param name="password">The password of the account. This is the same used to access Eloqua website.</param>
        /// <returns>The information for the given account. It is directly retrieved from Eloqua.</returns>
        public static async Task<AccountInfo> GetAccountInfoAsync(string site, string user, string password)
        {
            var client = new BaseClient(site, user, password, BulkUrl.Login);

            IRestResponse<AccountInfo> responseAccountInfo =
                await client.ExecuteTaskAsync<AccountInfo>(new RestRequest("id", Method.GET));

            return responseAccountInfo.Data;
        }

        /// <summary>
        /// Default <see cref="SyncClient"/>
        /// </summary>
        public SyncClient Syncs => _baseClient.Syncs;

        /// <summary>
        /// Default <see cref="Eloqua.Api.Bulk.Clients.ExportClient"/>
        /// </summary>
        public ExportClient ExportClient => _exportClient ?? (_exportClient = new ExportClient(_baseClient));

        /// <summary>
        /// Default <see cref="Eloqua.Api.Bulk.Clients.Activities.ActivityExportClient"/>
        /// </summary>
        public ActivityExportClient ActivityExportClient
            => _activityExportClient ?? (_activityExportClient = new ActivityExportClient(_baseClient));

        #region contacts

        /// <summary>
        /// Default <see cref="ContactFieldClient"/>
        /// </summary>
        public ContactFieldClient ContactFields =>
            _contactFieldClient ?? (_contactFieldClient = new ContactFieldClient(_baseClient));

        /// <summary>
        /// Default <see cref="ContactFilterClient"/>
        /// </summary>
        public ContactFilterClient ContactFilters =>
            _contactFilterClient ?? (_contactFilterClient = new ContactFilterClient(_baseClient));

        /// <summary>
        /// Default <see cref="ContactImportClient"/>
        /// </summary>
        public ContactImportClient ContactImport =>
            _contactImportClient ?? (_contactImportClient = new ContactImportClient(_baseClient));

        #endregion

        #region custom objects

        /// <summary>
        /// Default <see cref="CustomObjectFieldClient" />
        /// </summary>
        public CustomObjectFieldClient CustomObjectFields =>
            _customObjectFieldClient ?? (_customObjectFieldClient = new CustomObjectFieldClient(_baseClient));

        /// <summary>
        /// Default <see cref="CustomObjectExportClient" />
        /// </summary>
        public CustomObjectExportClient CustomObjectExport =>
            _customObjectExportClient ?? (_customObjectExportClient = new CustomObjectExportClient(_baseClient));

        /// <summary>
        /// Default <see cref="CustomObjectImportClient" />
        /// </summary>
        public CustomObjectImportClient CustomObjectImport =>
            _customObjectImportClient ?? (_customObjectImportClient = new CustomObjectImportClient(_baseClient));

        #endregion

        #region accounts

        /// <summary>
        /// Default <see cref="AccountFieldClient" />
        /// </summary>
        public AccountFieldClient AccountFields =>
            _accountFieldClient ?? (_accountFieldClient = new AccountFieldClient(_baseClient));

        /// <summary>
        /// Default <see cref="AccountFilterClient" />
        /// </summary>
        public AccountFilterClient AccountFilters =>
            _accountFilterClient ?? (_accountFilterClient = new AccountFilterClient(_baseClient));

        /// <summary>
        /// Default <see cref="AccountImportClient" />
        /// </summary>
        public AccountImportClient AccountImport =>
            _accountImportClient ?? (_accountImportClient = new AccountImportClient(_baseClient));

        #endregion
    }
}