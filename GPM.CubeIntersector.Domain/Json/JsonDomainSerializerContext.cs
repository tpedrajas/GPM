namespace GPM.CubeIntersector.Domain.Json;

[JsonSourceGenerationOptions(WriteIndented = true, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(CubeDto))]
public partial class JsonDomainSerializerContext : JsonSerializerContext
{

}
