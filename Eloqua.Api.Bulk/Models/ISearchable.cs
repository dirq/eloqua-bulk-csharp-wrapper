namespace Eloqua.Api.Bulk.Models
{
    public interface ISearchable
    {
        int Page { get; set; }
        int PageSize { get; set; }
        string SearchTerm { get; set; }
    }
}
