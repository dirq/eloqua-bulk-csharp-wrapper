﻿namespace Eloqua.Api.Bulk.Models.Exports
{
    public class ExportFilter
    {
        public string comparisonValue { get; set; }
        public FilterRuleType? filterRule { get; set; }
        public string membershipUri { get; set; }
        public string value { get; set; }
    }
}
