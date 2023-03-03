using KratosClient.Types;
using Microsoft.AspNetCore.Mvc;

namespace AuthProxyApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private readonly KratosClient.KratosClient _kratosClient;

    public AdminController(KratosClient.KratosClient kratosClient)
    {
        _kratosClient = kratosClient;
    }

    [HttpGet]
    [Route("identities")]
    public async Task<ActionResult> ListIdentities([FromQuery] int? perPage = null, [FromQuery] int? page = null)
    {
        IResult<IReadOnlyCollection<Identity>, KratosError> listResult = await _kratosClient.Identity.ListAsync(perPage: perPage, page: page);

        return listResult.IsSuccess ? Ok(listResult.Target) : StatusCode((int)listResult.Error!.Code, listResult.Error);
    }

    [HttpDelete]
    [Route("identities/{id}")]
    public async Task<ActionResult> DeleteIdentity(string id)
    {
        IEmptyResult<KratosError> deleteResult = await _kratosClient.Identity.DeleteAsync(id);

        return deleteResult.IsSuccess ? NoContent() : StatusCode((int)deleteResult.Error!.Code, deleteResult.Error);
    }

    [HttpGet]
    [Route("identities/{id}")]
    public async Task<ActionResult> GetIdentity(string id, [FromQuery] IEnumerable<string>? includeCredentials = null)
    {
        IResult<Identity, KratosError> getResult = await _kratosClient.Identity.GetAsync(id, includeCredentials);

        return getResult.IsSuccess ? Ok(getResult.Target) : StatusCode((int)getResult.Error!.Code, getResult.Error);
    }
}