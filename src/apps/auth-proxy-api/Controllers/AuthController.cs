using Microsoft.AspNetCore.Mvc;

namespace AuthProxyApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    // [HttpPost]
    // [Route("add")]
    // public async Task<KratosIdentity?> AddIdentity([FromBody] string email)
    // {
    //     Configuration config = new();
    //     config.BasePath = "http://localhost:4434";

    //     IdentityApi identityApi = new(config);
    //     var test = await identityApi.GetIdentitySchemaAsync("default");

    //     var client = new HttpClient();

    //     var result = await client.PostAsJsonAsync("http://localhost:4434/admin/identities", new
    //     {
    //         schema_id = "default",
    //         traits = new Dictionary<string, string>()
    //         {
    //             { "email", email}
    //         }
    //     });

    //     return await result.Content.ReadFromJsonAsync<KratosIdentity?>();
    // }

    [HttpGet]
    [Route("list")]
    public async Task ListIdentities()
    {
        KratosClient.KratosClient kratosClient = new KratosClient.KratosClient(new KratosClient.KratosClientOptions
        {
            AdminBaseUrl = "http://localhost:4434",
            PublicBaseUrl = "http://localhost:4433"
        });

        await kratosClient.IdentityApi.ListAsync();
    }
}