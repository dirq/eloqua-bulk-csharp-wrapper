﻿using System.Collections.Generic;

namespace Eloqua.Api.Bulk.Models
{
    public class SearchResponse<T>
    {
        public List<T> elements { get; set; }
        public int total { get; set; }
        public int pageSize { get; set; }
        public int page { get; set; }
    }
}
