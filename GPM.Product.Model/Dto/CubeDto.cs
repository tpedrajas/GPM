namespace GPM.Product.Model.Dto;

public sealed record CubeDto
{

    #region constructors / deconstructors / destructors

    [JsonConstructor]
    public CubeDto(float x, float y, float z, float width, float height, float depth)
    {
        X = x;
        Y = y;
        Z = z;

        Width = width;
        Height = height;
        Depth = depth;
    }

    #endregion

    #region properties

    public float Depth { get; init; }

    public float Height { get; init; }

    public float Width { get; init; }

    public float X { get; init; }

    public float Y { get; init; }

    public float Z { get; init; }

    #endregion

}
