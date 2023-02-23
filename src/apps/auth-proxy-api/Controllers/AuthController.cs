using Microsoft.AspNetCore.Mvc;
using Ory.Kratos.Client.Api;
using Ory.Kratos.Client.Client;
using Ory.Kratos.Client.Model;

namespace AuthProxyApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost]
    [Route("add")]
    public async Task<KratosIdentity?> AddIdentity([FromBody] string email)
    {
        Configuration config = new();
        config.BasePath = "http://localhost:4434";

        IdentityApi identityApi = new(config);

        var test = await identityApi.GetIdentitySchemaAsync("default");

        var client = new HttpClient();

        var resutl = await client.PostAsJsonAsync("http://localhost:4434/admin/identities", new
        {
            schema_id = "default",
            traits = new Dictionary<string, string>()
            {
                { "email", "admin@mail.com"}
            }
        });

        var result = await identityApi.CreateIdentityAsync(new KratosCreateIdentityBody
        {
            SchemaId = "default",
            Traits = new Dictionary<string, string>()
            {
                { "email", email },
                { "password", "test" }
            },
        });

        return result;
    }
}