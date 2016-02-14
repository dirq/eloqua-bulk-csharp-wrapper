namespace Eloqua.Api.Bulk.Models
{
    public class RestObject : IIdentifiable
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
