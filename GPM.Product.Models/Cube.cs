namespace GPM.Product.Models;

public sealed class Cube : Model, ICube, IEquatable<Cube>
{

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

    public IParameterizedService Fill(object parameter, params object[] parameters)
    {
        X = (float)parameter;
        Y = (float)parameters[0];
        Z = (float)parameters[1];
        Width = (float)parameters[2];
        Height = (float)parameters[3];
        Width = (float)parameters[4];

        return this;
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
