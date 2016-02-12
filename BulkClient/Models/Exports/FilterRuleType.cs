namespace Eloqua.Api.Bulk.Models.Exports
{
    public enum FilterRuleType
    {
        Member = 0,
        PendingMember = 1,
        ActiveMember = 2,
        SubscribedMember = 3,
        UnsubscribedMember = 4,
        ValueEqualsComparisonValue,
        ValueDoesNotEqualComparisonValue,
        ValueGreaterThanComparisonValue,
        ValueGreaterThanOrEqualToComparisonValue,
        ValueLessThanComparisonValue,
        ValueLessThanOrEqualToComparisonValue
    }
}