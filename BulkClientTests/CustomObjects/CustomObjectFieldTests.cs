using System.Threading.Tasks;
using NUnit.Framework;
using Eloqua.Api.Bulk.Models;
using Eloqua.Api.Bulk.Models.Login;


namespace Eloqua.Api.Bulk.Tests.CustomObjects
{
    [TestFixture]
    public class CustomObjectFieldTests
    {
        private BulkClient _client;

        [TestFixtureSetUp]
        public async Task Init()
        {
            AccountInfo accountInfo =
                await BulkClient.GetAccountInfoAsync(Constants.Site, Constants.User, Constants.Passwd);

            _client =
                new BulkClient(Constants.Site, Constants.User, Constants.Passwd, Helpers.BulkEndpoint(accountInfo));
        }

        [Test]
        public async Task GetContactFieldsTest()
        {
            SearchResponse<Field> fields = await _client.CustomObjectFields.SearchAsync(1, "*", 1, 1);

            Assert.AreEqual(1, fields.Total);
        }
    }
}
