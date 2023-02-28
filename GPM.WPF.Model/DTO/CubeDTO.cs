namespace GPM.WPF.Model.Dto;

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

    public float Depth { get; set; }

    public float Height { get; set; }

    public float Width { get; set; }

    public float X { get; set; }

    public float Y { get; set; }

    public float Z { get; set; }

    #endregion

}
