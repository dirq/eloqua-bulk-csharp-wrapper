using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models;
using Eloqua.Api.Bulk.Models.Login;
using NUnit.Framework;

namespace Eloqua.Api.Bulk.Tests.Contacts
{
    [TestFixture]
    public class ContactFieldTests
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
            SearchResponse<Field> fields = await _client.ContactFields.SearchAsync("*", 1, 1);

            Assert.AreEqual(1, fields.Total);
        }
    }
}
