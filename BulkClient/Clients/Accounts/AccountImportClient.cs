using Eloqua.Api.Bulk.Models.Imports;

namespace Eloqua.Api.Bulk.Clients.Accounts
{
    public class AccountImportClient : ImportCsvClient
    {
        public AccountImportClient(BaseClient client) : base(client)
        {
        }

        public Import CreateImport(Import import) => base.CreateImport(import, "account");
    }
}
