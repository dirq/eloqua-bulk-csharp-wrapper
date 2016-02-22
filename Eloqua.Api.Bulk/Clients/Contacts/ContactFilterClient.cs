using System.Collections.Generic;
using System.Threading.Tasks;
using Eloqua.Api.Bulk.Clients.Base;
using Eloqua.Api.Bulk.Models;

namespace Eloqua.Api.Bulk.Clients.Contacts
{
    public class ContactFilterClient : FilterClient
    {
        public ContactFilterClient(BaseClient client) : base(client)
        {
        }

        public async Task<List<Filter>> SearchAsync(string searchTerm, int page, int pageSize)
        {
            return await base.SearchAsync(searchTerm, page, pageSize, "contact");
        }
    }
}