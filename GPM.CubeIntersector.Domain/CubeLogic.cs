namespace GPM.CubeIntersector.Domain;

public static class CubeLogic
{

    public static Cube? GetCube(string id)
    {
        Cube? resultCube;

        switch (id)
        {
            case "test1":
                resultCube = new Cube(0, 1, 2, 3, 4, 5);
                break;
            case "test2":
                resultCube = new Cube(6, 7, 8, 9, 0, 1);
                break;
            default:
                resultCube = null;
                break;
        }

        return resultCube;
    }

    public static void SetCube(string id, Cube cube)
    {
        string newId = id;

    }

}
