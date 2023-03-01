namespace GPM.CubeIntersector.Domain;

public static class CubeLogic
{

    #region methods

    public static async Task<Cube?> GetCube(string id, IServiceProvider provider)
    {
        Cube? resultCube;

        await using AsyncServiceScope scope = provider.CreateAsyncScope();
        await using ICubeIntersectorDBContext dbContext = scope.ServiceProvider.GetRequiredService<ICubeIntersectorDBContext>();
        
        IMapper mapper = provider.GetRequiredService<IMapper>();

        CubeEntity? cubeEntity = dbContext.CubeEntities.SingleOrDefault(cube => cube.Id == id);
        resultCube = mapper.Map<Cube?>(cubeEntity);

        return resultCube;
    }

    public static async Task SetCube(string id, Cube cube, IServiceProvider provider)
    {
        await using AsyncServiceScope scope = provider.CreateAsyncScope();
        await using ICubeIntersectorDBContext dbContext = scope.ServiceProvider.GetRequiredService<ICubeIntersectorDBContext>();
        
        IMapper mapper = provider.GetRequiredService<IMapper>();

        CubeEntity cubeEntity = mapper.Map<CubeEntity>(cube);
        cubeEntity.Id = id;

        if (!dbContext.CubeEntities.Any(cube => cube.Id == id))
        {
            dbContext.CubeEntities.Add(cubeEntity);
        }
        else
        {
            dbContext.CubeEntities.Update(cubeEntity);
        }
                
        await dbContext.SaveChangesAsync().ConfigureAwait(false);
    }

    #endregion

}
