using System;

namespace Eloqua.Api.Bulk.Models
{
    public class Filter
    {
        public int? Count { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Name { get; set; }
        public DateTime? ExecutedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Uri { get; set; }
    }
}