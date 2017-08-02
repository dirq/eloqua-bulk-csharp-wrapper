using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models.Exports;
using Eloqua.Api.Bulk.Models.Login;
using NUnit.Framework;

namespace Eloqua.Api.Bulk.Tests.Contacts
{
    [TestFixture]
    public class ContactExportTests
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
        public async Task CreateExportTest()
        {
            Export export = await client.ExportClient.CreateExportAsync(new Export(), string.Empty);

            Assert.IsNotNull(export);
        }
    }
}