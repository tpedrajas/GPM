namespace GPM.CubeIntersector.Domain.WebAPI;

public static class CubeLogic
{

    #region methods

    public static async Task<ICube?> GetCubeAsync(IServiceProvider services, string id)
    {
        ICube? resultCube;

        AsyncServiceScope scope = services.CreateAsyncScope();
        await using (scope.ConfigureAwait(false))
        {
            ICubeIntersectorDBContext dbContext = scope.ServiceProvider.GetRequiredService<ICubeIntersectorDBContext>();
            await using (dbContext.ConfigureAwait(false))
            {
                IMapper mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                var cubeEntity = dbContext.CubeEntities.SingleOrDefault(cube => cube.Id == id);
                resultCube = mapper.Map<Cube?>(cubeEntity);

                return resultCube;
            }
        }
    }

    public static async Task<UpsetOperation> SetCubeAsync(IServiceProvider services, string id, ICube cube)
    {
        UpsetOperation operation = UpsetOperation.Error;

        AsyncServiceScope scope = services.CreateAsyncScope();
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
