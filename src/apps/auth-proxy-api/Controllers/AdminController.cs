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
    public async Task<ActionResult> ListIdentities()
    {
        IResult<IReadOnlyCollection<Identity>, KratosError> listResult = await _kratosClient.IdentityApi.ListAsync();

        return listResult.IsSuccess ? Ok(listResult.Target) : StatusCode((int)listResult.Error!.Code);
    }
}