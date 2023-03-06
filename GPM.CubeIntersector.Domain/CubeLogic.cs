namespace GPM.CubeIntersector.Domain;

public static class CubeLogic
{

    #region methods

    public static async Task<Cube?> GetCube(string id, IServiceProvider provider)
    {
        Cube? resultCube;

        AsyncServiceScope scope = provider.CreateAsyncScope();
        await using (scope.ConfigureAwait(false))
        {
            ICubeIntersectorDBContext dbContext = scope.ServiceProvider.GetRequiredService<ICubeIntersectorDBContext>();
            await using (dbContext.ConfigureAwait(false))
            {
                IMapper mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                CubeSet? cubeEntity = dbContext.CubeEntities.SingleOrDefault(cube => cube.Id == id);
                resultCube = mapper.Map<Cube?>(cubeEntity);

                return resultCube;
            }
        }
    }

    public static async Task<UpsetOperation> SetCube(string id, Cube cube, IServiceProvider provider)
    {
        UpsetOperation operation = UpsetOperation.Error;

        AsyncServiceScope scope = provider.CreateAsyncScope();
        await using (scope.ConfigureAwait(false))
        {
            ICubeIntersectorDBContext dbContext = scope.ServiceProvider.GetRequiredService<ICubeIntersectorDBContext>();
            await using (dbContext.ConfigureAwait(false))
            {
                IMapper mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                CubeSet cubeEntity = mapper.Map<CubeSet>(cube);
                cubeEntity.Id = id;

                if (!dbContext.CubeEntities.Any(cube => cube.Id == id))
                {
                    dbContext.CubeEntities.Add(cubeEntity);
                    operation = UpsetOperation.Add;
                }
                else
                {
                    dbContext.CubeEntities.Update(cubeEntity);
                    operation = UpsetOperation.Update;
                }

                using Task<int> saveTask = dbContext.SaveChangesAsync();
                await saveTask.ConfigureAwait(false);

                return operation;
            }
        }
    }

    #endregion

}
