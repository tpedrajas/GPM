namespace GPM.CubeIntersector.Domain.Desktop;

public static class CubeIntersectionLogic
{

    #region methods

    public static bool ExistsCubeIntersect(ICube cube1, ICube cube2)
    {
        bool existsIntersect = true;

        existsIntersect &= Math.Abs(cube2.X - cube1.X) <= (cube1.Width + cube2.Width) / 2;
        existsIntersect &= Math.Abs(cube2.Y - cube1.Y) <= (cube1.Height + cube2.Height) / 2;
        existsIntersect &= Math.Abs(cube2.Z - cube1.Z) <= (cube1.Depth + cube2.Depth) / 2;

        return existsIntersect;
    }

    public static bool ExistsCubeIntersect(IServiceProvider services, float xCube1, float yCube1, float zCube1, float widthCube1, float heightCube1, float depthCube1,
                                           float xCube2, float yCube2, float zCube2, float widthCube2, float heightCube2, float depthCube2)
    {

        ICube cube1 = services.GetRequiredService<ICube>(xCube1, yCube1, zCube1, widthCube1, heightCube1, depthCube1);
        ICube cube2 = services.GetRequiredService<ICube>(xCube2, yCube2, zCube2, widthCube2, heightCube2, depthCube2);

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

    public static ICube? GetCubeIntersect(IServiceProvider services, ICube cube1, ICube cube2)
    {
        ICube? intersectCubeResult = null;
        float x, y, z, width, height, depth;

        if (ExistsCubeIntersect(cube1, cube2))
        {
            x = (cube1.X + cube2.X) / 2;
            y = (cube1.Y + cube2.Y) / 2;
            z = (cube1.Z + cube2.Z) / 2;

            width = GetAxisCubeIntersect(cube1.X, cube1.Width, cube2.X, cube2.Width);
            height = GetAxisCubeIntersect(cube1.Y, cube1.Height, cube2.Y, cube2.Height);
            depth = GetAxisCubeIntersect(cube1.Z, cube1.Depth, cube2.Z, cube2.Depth);

            intersectCubeResult = services.GetRequiredService<ICube>(x, y, z, width, height, depth);
        }

        return intersectCubeResult;
    }

    public static ICube? GetCubeIntersect(IServiceProvider services, float xCube1, float yCube1, float zCube1, float widthCube1, float heightCube1, float depthCube1,
                                          float xCube2, float yCube2, float zCube2, float widthCube2, float heightCube2, float depthCube2)
    {
        ICube cube1 = services.GetRequiredService<ICube>(xCube1, yCube1, zCube1, widthCube1, heightCube1, depthCube1);
        ICube cube2 = services.GetRequiredService<ICube>(xCube2, yCube2, zCube2, widthCube2, heightCube2, depthCube2);

        return GetCubeIntersect(services, cube1, cube2);
    }

    #endregion

}
