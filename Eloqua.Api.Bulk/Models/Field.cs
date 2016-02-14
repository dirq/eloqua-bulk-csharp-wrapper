namespace Eloqua.Api.Bulk.Models
{
    public class Field
    {
        public string DefaultValue { get; set; }
        public string InternalName { get; set; }
        public bool? HasReadOnlyConstraint { get; set; }
        public bool? HasNotNullConstraint { get; set; }
        public bool? HasUniquenessConstraint { get; set; }
        public string Name { get; set; }
        public string Statement { get; set; }
    }
}
