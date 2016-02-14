namespace Eloqua.Api.Bulk.Models.Exports
{
    public class ExportFilter
    {
        public string ComparisonValue { get; set; }
        public FilterRuleType? FilterRule { get; set; }
        public string MembershipUri { get; set; }
        public string Value { get; set; }
    }
}
