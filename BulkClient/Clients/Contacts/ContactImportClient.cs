using Eloqua.Api.Bulk.Models.Imports;

namespace Eloqua.Api.Bulk.Clients.Contacts
{
    public class ContactImportClient : ImportCsvClient
    {
        public ContactImportClient(BaseClient client) : base(client)
        {
        }

        public Import CreateImport(Import import) => base.CreateImport(import, "contact");
    }
}
