using System.Collections.Generic;
using System.Threading.Tasks;
using Eloqua.Api.Bulk.Clients.Base;
using Eloqua.Api.Bulk.Models;

namespace Eloqua.Api.Bulk.Clients.Accounts
{
    public class AccountFilterClient : FilterClient
    {
        public AccountFilterClient(BaseClient client) : base(client)
        {
        }

        public async Task<List<Filter>> SearchAsync(string searchTerm, int page, int pageSize) =>
            await base.SearchAsync(searchTerm, page, pageSize, "account");
    }
}
