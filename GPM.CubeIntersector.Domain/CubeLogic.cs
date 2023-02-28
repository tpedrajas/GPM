namespace GPM.CubeIntersector.Domain;

public static class CubeLogic
{

    public static CubeDTO? GetCube(string id)
    {
        CubeDTO? resultCube;

        switch (id)
        {
            case "test1":
                resultCube = new CubeDTO(0, 1, 2, 3, 4, 5);
                break;
            case "test2":
                resultCube = new CubeDTO(6, 7, 8, 9, 0, 1);
                break;
            default:
                resultCube = null;
                break;
        }

        return resultCube;
    }

    public static void SetCube(string id, CubeDTO cube)
    {

    }

}
