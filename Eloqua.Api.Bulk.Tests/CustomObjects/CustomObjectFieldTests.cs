﻿using System.Threading.Tasks;
using Eloqua.Api.Bulk.Models.Login;
using NUnit.Framework;

namespace Eloqua.Api.Bulk.Tests.CustomObjects
{
    [TestFixture]
    public class CustomObjectFieldTests
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
            var fields = await client.CustomObjectFields.SearchAsync(1, "*", 1, 1);

            Assert.AreEqual(1, fields.Total);
        }
    }
}