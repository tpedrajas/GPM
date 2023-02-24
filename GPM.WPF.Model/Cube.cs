namespace GPM.WPF.Model;

public class Cube : IEquatable<Cube>
{

    #region constuctors / deconstructors / destructors

    public Cube(Vector3 position, Vector3 dimension)
    {
        Position = position;
        Dimension = dimension;
    }

    public Cube(float x, float y, float z, float width, float height, float depth) : this(new Vector3(x, y, z), new Vector3(width, height, depth))
    {
        
    }

    #endregion

    #region properties

    public Vector3 Dimension { get; set; }

    public Vector3 Position { get; set; }

    #endregion

    #region methods

    public bool Equals(Cube? other)
    {
        bool isEqual = other is not null;

        if (isEqual)
        {
            isEqual &= Position.Equals(other!.Position);
            isEqual &= Dimension.Equals(other!.Dimension);
        }

        return isEqual;
    }

    public override bool Equals(object? obj)
    {
        return obj switch
        {
            null => false,
            Cube value => Equals(value),
            _ => false
        };
    }

    public override int GetHashCode()
    {
        return Position.GetHashCode() ^ Dimension.GetHashCode();
    }

    #endregion

}
