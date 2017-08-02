namespace Eloqua.Api.Bulk.Models.Errors
{
    public class ObjectValidationError
    {
        public ObjectKey Container { get; set; }
        public string Property { get; set; }
        public string Requirement { get; set; }
        public string Value { get; set; }
    }
}