namespace GPM.CubeIntersector.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CubeController : Controller
{

    #region methods

    [HttpGet("GetCube/{id}")]
    public async Task<IActionResult> GetCube(string id, IServiceProvider provider)
    {
        IActionResult result;

        try
        {
            using Task<Cube?> getTask = CubeLogic.GetCube(id, provider);

            IMapper mapper = provider.GetRequiredService<IMapper>();
            Cube? cube = await getTask.ConfigureAwait(false);

            if (cube is not null)
            {
                CubeDto cubeDto = mapper.Map<CubeDto>(cube);
                result = Ok(cubeDto);
            }
            else
            {
                result = NoContent();
            }
        }
        catch
        {
            result = StatusCode(500);
        }

        return result;
    }

    [HttpPost("SetCube/{id}")]
    public async Task<IActionResult> SetCube(string id, [FromBody] CubeDto cubeDTO, IServiceProvider provider)
    {
        IActionResult result;
        UpsetOperation operation = UpsetOperation.Error;

        try
        {
            IMapper mapper = provider.GetRequiredService<IMapper>();
            Cube cube = mapper.Map<Cube>(cubeDTO);

            using Task<UpsetOperation> setTask = CubeLogic.SetCube(id, cube, provider);
            operation = await setTask.ConfigureAwait(false);

            result = Ok(operation);
        }
        catch
        {
            result = StatusCode(500, operation);
        }
        
        return result;
    }

    #endregion

}
