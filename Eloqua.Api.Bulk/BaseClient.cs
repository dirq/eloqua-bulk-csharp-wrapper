using System.Threading.Tasks;
using Eloqua.Api.Bulk.Clients;
using Eloqua.Api.Bulk.Validation;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;

namespace Eloqua.Api.Bulk
{
    public class BaseClient : RestClient
    {
        private SyncClient _syncClient;
        private JsonDataClient _jsonDataClient;

        protected BaseClient() {}

        public BaseClient(string site, string user, string password, string baseUrl) : base(baseUrl)
        {
            Authenticator = new HttpBasicAuthenticator(site + "\\" + user, password);

            AddHandler("text/plain", new JsonDeserializer());
            SimpleJson.CurrentJsonSerializerStrategy = new CamelCaseSerializer();
        }

        public override async Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request)
        {
            IRestResponse<T> response = await base.ExecuteTaskAsync<T>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || (int)response.StatusCode >= 400)
            {
                throw ResponseValidator.GetExceptionFromResponse(response);
            }

            return response;
        }

        public SyncClient Syncs => _syncClient ?? (_syncClient = new SyncClient(this));

        public JsonDataClient JsonData => _jsonDataClient ?? (_jsonDataClient = new JsonDataClient(this));
    }
}