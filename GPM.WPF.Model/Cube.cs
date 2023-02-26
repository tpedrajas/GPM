﻿namespace GPM.WPF.Model;

public class Cube : IEquatable<Cube>
{

    #region constuctors / deconstructors / destructors

    public Cube(Vector3 position, Vector3 size)
    {
        Position = position;
        Size = size;
    }

    public Cube(float x, float y, float z, float width, float height, float depth) : this(new Vector3(x, y, z), new Vector3(width, height, depth))
    {
        
    }

    public Cube(float[] position, float[] size) : this(new Vector3(position[0], position[1], position[2]), new Vector3(size[0], size[1], size[2]))
    {

    }

    #endregion

    #region properties

    public Vector3 Size { get; set; }

    public Vector3 Position { get; set; }

    #endregion

    #region methods

    public bool Equals(Cube? other)
    {
        bool isEqual = other is not null;

        if (isEqual)
        {
            isEqual &= Position.Equals(other!.Position);
            isEqual &= Size.Equals(other!.Size);
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
        return Position.GetHashCode() ^ Size.GetHashCode();
    }

    #endregion

}
