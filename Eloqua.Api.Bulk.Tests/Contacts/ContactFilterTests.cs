using System.Collections.Generic;
using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models.Login;
using NUnit.Framework;

namespace Eloqua.Api.Bulk.Tests.Contacts
{
    [TestFixture]
    public class ContactFilterTests
    {
        private BulkClient client;

        [TestFixtureSetUp]
        public async Task Init()
        {
            AccountInfo accountInfo =
                await BulkClient.GetAccountInfoAsync(Constants.Site, Constants.User, Constants.Passwd);

            client =
                new BulkClient(Constants.Site, Constants.User, Constants.Passwd, Helpers.BulkEndpoint(accountInfo));
        }

        [Test]
        public async Task GetContactFieldsTest()
        {
            var filters = await client.ContactFilters.SearchAsync("*", 1, 1);

            Assert.AreEqual(1, filters.Count);
        }
    }
}