using System.Threading.Tasks;
using Eloqua.Api.Bulk.Clients.Base;
using Eloqua.Api.Bulk.Models.Imports;

namespace Eloqua.Api.Bulk.Clients.Contacts
{
    public class ContactImportClient : ImportCsvClient
    {
        public ContactImportClient(BaseClient client) : base(client)
        {
        }

        public async Task<Import> CreateImportAsync(Import import) => await base.CreateImportAsync(import, "contact");
    }
}
