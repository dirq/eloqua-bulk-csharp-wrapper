using System;

namespace Eloqua.Api.Bulk.Models.CustomObjects
{
    public class CustomObjectSearchResponse
    {
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string DisplayNameFieldUri { get; set; }
        public string EmailAddressFieldUri { get; set; }
        public string Name { get; set; }
        public string UniqueFieldUri { get; set; }
        public string Uri { get; set; }
    }
}