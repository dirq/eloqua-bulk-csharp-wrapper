using System.Threading.Tasks;
using NUnit.Framework;
using Eloqua.Api.Bulk.Models.Exports;
using Eloqua.Api.Bulk.Models.Login;

namespace Eloqua.Api.Bulk.Tests.Contacts
{
    [TestFixture]
    public class ContactExportTests
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
        public async Task CreateExportTest()
        {
            Export export = await _client.ContactExport.CreateExportAsync(new Export());

            Assert.IsNotNull(export);
        }
    }
}
