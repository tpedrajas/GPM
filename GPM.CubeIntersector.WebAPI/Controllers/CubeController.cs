namespace GPM.CubeIntersector.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CubeController : Controller
{

    #region methods

    [HttpGet("GetCube/{id}")]
    public async Task<CubeDto?> GetCube(string id, IServiceProvider provider)
    {
        Cube? cube = await CubeLogic.GetCube(id, provider).ConfigureAwait(false);

        IMapper mapper = provider.GetRequiredService<IMapper>();
        CubeDto? result = mapper.Map<CubeDto?>(cube);

        return result;
    }

    [HttpPost("SetCube/{id}")]
    public async void SetCube(string id, [FromBody] CubeDto cubeDTO, IServiceProvider provider)
    {
        IMapper mapper = provider.GetRequiredService<IMapper>();
        Cube cube = mapper.Map<Cube>(cubeDTO);

        await CubeLogic.SetCube(id, cube, provider).ConfigureAwait(false);
    }

    #endregion

}
