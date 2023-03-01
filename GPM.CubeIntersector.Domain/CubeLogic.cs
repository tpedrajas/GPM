namespace GPM.CubeIntersector.Domain;

public static class CubeLogic
{

    #region methods

    public static Cube? GetCube(string id, IServiceProvider provider)
    {
        Cube? resultCube;

        using (IServiceScope scope = provider.CreateScope())
        {
            using (ICubeIntersectorDBContext dbContext = scope.ServiceProvider.GetRequiredService<ICubeIntersectorDBContext>())
            {
                IMapper mapper = provider.GetRequiredService<IMapper>();

                CubeEntity? cubeEntity = dbContext.CubeEntities.SingleOrDefault(cube => cube.Id == id);
                resultCube = mapper.Map<Cube?>(cubeEntity);
            }
        }

        return resultCube;
    }

    public static void SetCube(string id, Cube cube, IServiceProvider provider)
    {
        using (IServiceScope scope = provider.CreateScope())
        {
            using (ICubeIntersectorDBContext dbContext = scope.ServiceProvider.GetRequiredService<ICubeIntersectorDBContext>())
            {
                IMapper mapper = provider.GetRequiredService<IMapper>();

                CubeEntity cubeEntity = mapper.Map<CubeEntity>(cube);
                cubeEntity.Id = id;

                dbContext.CubeEntities.Update(cubeEntity);
                dbContext.SaveChanges();
            }
        }
    }

    #endregion

}
