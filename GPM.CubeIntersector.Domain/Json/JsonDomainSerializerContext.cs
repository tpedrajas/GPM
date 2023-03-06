namespace GPM.CubeIntersector.Domain.Json;

[JsonSourceGenerationOptions(WriteIndented = true, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(CubeDto))]
[JsonSerializable(typeof(UpsetOperation))]
public partial class JsonDomainSerializerContext : JsonSerializerContext
{

}
