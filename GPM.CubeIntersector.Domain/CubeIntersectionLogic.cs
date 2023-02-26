namespace GPM.CubeIntersector.Domain;

public static class CubeIntersectionLogic
{

    #region methods

    public static bool ExistsCubeIntersect(Cube cube1, Cube cube2)
    {
        bool existsIntersect = true;

        existsIntersect &= Math.Abs(cube2.Position.X - cube1.Position.X) <= (cube1.Size.X + cube2.Size.X) / 2;
        existsIntersect &= Math.Abs(cube2.Position.Y - cube1.Position.Y) <= (cube1.Size.Y + cube2.Size.Y) / 2;
        existsIntersect &= Math.Abs(cube2.Position.Z - cube1.Position.Z) <= (cube1.Size.Z + cube2.Size.Z) / 2;

        return existsIntersect;
    }

    public static bool ExistsCubeIntersect(Vector3 positionCube1, Vector3 dimensionCube1, Vector3 positionCube2, Vector3 dimensionCube2)
    {
        Cube cube1 = new(positionCube1, dimensionCube1);
        Cube cube2 = new(positionCube2, dimensionCube2);

        return ExistsCubeIntersect(cube1, cube2);
    }

    public static bool ExistsCubeIntersect(float xPositionCube1, float yPositionCube1, float zPositionCube1, float widthCube1, float heightCube1, float depthCube1,
                                           float xPositionCube2, float yPositionCube2, float zPositionCube2, float widthCube2, float heightCube2, float depthCube2)
    {
        Cube cube1 = new(xPositionCube1, yPositionCube1, zPositionCube1, widthCube1, heightCube1, depthCube1);
        Cube cube2 = new(xPositionCube2, yPositionCube2, zPositionCube2, widthCube2, heightCube2, depthCube2);

        return ExistsCubeIntersect(cube1, cube2);
    }

    private static float GetAxisCubeIntersect(float axisPositionCube1, float axisDimensionCube1, float axisPositionCube2, float axisDimensionCube2)
    {
        float intersectAxisResult = Math.Min(axisDimensionCube1, axisDimensionCube2);
        float positionDifference = axisPositionCube2 - axisPositionCube1;

        if (positionDifference != 0)
        {
            if (positionDifference > 0)
            {
                intersectAxisResult = (axisPositionCube1 + axisDimensionCube1 / 2) - (axisPositionCube2 - axisDimensionCube2 / 2);
            }
            else
            {
                intersectAxisResult = (axisPositionCube2 + axisDimensionCube2 / 2) - (axisPositionCube1 - axisDimensionCube1 / 2);
            }
        }

        return intersectAxisResult;
    }

    public static Cube? GetCubeIntersect(Cube cube1, Cube cube2)
    {
        Cube? intersectCubeResult = null;
        float width, height, depth;

        if (ExistsCubeIntersect(cube1, cube2))
        {
            width = GetAxisCubeIntersect(cube1.Position.X, cube1.Size.X, cube2.Position.X, cube2.Size.X);
            height = GetAxisCubeIntersect(cube1.Position.Y, cube1.Size.Y, cube2.Position.Y, cube2.Size.Y);
            depth = GetAxisCubeIntersect(cube1.Position.Z, cube1.Size.Z, cube2.Position.Z, cube2.Size.Z);

            intersectCubeResult = new Cube((cube1.Position + cube2.Position) / 2, new Vector3(width, height, depth));
        }

        return intersectCubeResult;
    }

    public static Cube? GetCubeIntersect(Vector3 positionCube1, Vector3 dimensionCube1, Vector3 positionCube2, Vector3 dimensionCube2)
    {
        Cube cube1 = new(positionCube1, dimensionCube1);
        Cube cube2 = new(positionCube2, dimensionCube2);

        return GetCubeIntersect(cube1, cube2);
    }

    public static Cube? GetCubeIntersect(float xPositionCube1, float yPositionCube1, float zPositionCube1, float widthCube1, float heightCube1, float depthCube1,
                                         float xPositionCube2, float yPositionCube2, float zPositionCube2, float widthCube2, float heightCube2, float depthCube2)
    {
        Cube cube1 = new(xPositionCube1, yPositionCube1, zPositionCube1, widthCube1, heightCube1, depthCube1);
        Cube cube2 = new(xPositionCube2, yPositionCube2, zPositionCube2, widthCube2, heightCube2, depthCube2);

        return GetCubeIntersect(cube1, cube2);
    }

    #endregion

}
