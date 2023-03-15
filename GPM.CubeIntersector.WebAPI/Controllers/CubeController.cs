namespace GPM.CubeIntersector.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CubeController : Controller
{

    #region methods

    [HttpGet("GetCube/{id}")]
    public async Task<IActionResult> GetCubeAsync(IServiceProvider services, string id)
    {
        IActionResult result;

        try
        {
            using Task<ICube?> getTask = CubeLogic.GetCubeAsync(services, id);

            IMapper mapper = services.GetRequiredService<IMapper>();
            ICube? cube = await getTask.ConfigureAwait(false);

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
    public async Task<IActionResult> SetCubeAsync(IServiceProvider services, string id, [FromBody] CubeDto cubeDTO)
    {
        IActionResult result;
        UpsetOperation operation = UpsetOperation.Error;

        try
        {
            IMapper mapper = services.GetRequiredService<IMapper>();
            ICube cube = mapper.Map<Cube>(cubeDTO);

            using Task<UpsetOperation> setTask = CubeLogic.SetCubeAsync(services, id, cube);
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
