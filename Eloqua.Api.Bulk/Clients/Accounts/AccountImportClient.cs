using System.Threading.Tasks;
using Eloqua.Api.Bulk.Clients.Base;
using Eloqua.Api.Bulk.Models.Imports;

namespace Eloqua.Api.Bulk.Clients.Accounts
{
    public class AccountImportClient : ImportCsvClient
    {
        public AccountImportClient(BaseClient client) : base(client)
        {
        }

        public async Task<Import> CreateImportAsync(Import import) => await base.CreateImportAsync(import, "account");
    }
}