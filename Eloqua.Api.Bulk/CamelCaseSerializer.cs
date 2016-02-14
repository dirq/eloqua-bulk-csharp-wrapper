using RestSharp;

namespace Eloqua.Api.Bulk
{
    /// <summary>
    /// Serializes property names in camelCase format rather than PascalCase
    /// </summary>
    public class CamelCaseSerializer : PocoJsonSerializerStrategy
    {
        protected override string MapClrMemberNameToJsonFieldName(string clrPropertyName) =>
            char.ToLowerInvariant(clrPropertyName[0]) + clrPropertyName.Substring(1);
    }
}
