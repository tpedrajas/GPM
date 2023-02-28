namespace GPM.CubeIntersector.Domain;

public static class CubeLogic
{

    public static CubeDTO? GetCube(string id)
    {
        CubeDTO? resultCube;

        switch (id)
        {
            case "test1":
                resultCube = new CubeDTO(1, 1, 1, 1, 1, 1);
                break;
            case "test2":
                resultCube = new CubeDTO(0, 0, 0, 1, 1, 1);
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
