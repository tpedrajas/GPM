namespace GPM.CubeIntersector.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CubeController : ControllerBase
{

    #region methods

    [HttpGet("GetCube/{id}")]
    public async Task<CubeDTO?> GetCube(string id)
    {
        CubeDTO? result = await Task.Run(() => CubeLogic.GetCube(id)).ConfigureAwait(false);

        return result;
    }

    [HttpPost("SetCube/{id}")]
    public async void SetCube(string id, [FromBody] CubeDTO cube)
    {
        await Task.Run(() => CubeLogic.SetCube(id, cube)).ConfigureAwait(false);
    }

    #endregion

}
