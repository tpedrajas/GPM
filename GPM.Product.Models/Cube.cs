namespace GPM.Product.Models;

public interface ICube : IModel
{

}

public sealed class Cube : Model, ICube, IEquatable<Cube>
{

    #region constuctors / deconstructors / destructors

    public Cube(float x, float y, float z, float width, float height, float depth)
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

    #region methods

    public bool Equals(Cube? other)
    {
        bool isEqual = false;

        if (other is not null)
        {
            isEqual = true;

            isEqual &= Equals(X, other.X) && Equals(Y, other.Y) && Equals(Z, other.Z);
            isEqual &= Equals(Width, other.Width) && Equals(Height, other.Height) && Equals(Depth, other.Depth);
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
        int hashCode = 0;

        hashCode ^= X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        hashCode ^= Width.GetHashCode() ^ Height.GetHashCode() ^ Depth.GetHashCode();

        return hashCode;
    }

    #endregion

}
