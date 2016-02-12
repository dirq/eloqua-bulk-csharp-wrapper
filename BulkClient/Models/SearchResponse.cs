using System.Collections.Generic;

namespace Eloqua.Api.Bulk.Models
{
    public class SearchResponse<T>
    {
        public List<T> Elements { get; set; }
        public int Total { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
