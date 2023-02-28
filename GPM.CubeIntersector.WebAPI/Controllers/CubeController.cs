namespace GPM.CubeIntersector.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CubeController : Controller
{

    #region methods

    [HttpGet("GetCube/{id}")]
    public async Task<CubeDto?> GetCube(string id, IMapper mapper)
    {
        Cube? cube = await Task.Run(() => CubeLogic.GetCube(id)).ConfigureAwait(false);
        CubeDto? result = mapper.Map<CubeDto?>(cube);

        return result;
    }

    [HttpPost("SetCube/{id}")]
    public async void SetCube(string id, [FromBody] CubeDto cubeDTO, IMapper mapper)
    {
        Cube cube = mapper.Map<Cube>(cubeDTO);
        await Task.Run(() => CubeLogic.SetCube(id, cube)).ConfigureAwait(false);
    }

    #endregion

}
