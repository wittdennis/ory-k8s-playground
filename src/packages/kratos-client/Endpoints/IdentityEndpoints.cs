namespace KratosClient.Endpoints;

internal sealed class IdentityEndpoints
{
    private readonly Uri _baseUrl;

    public IdentityEndpoints(Uri baseUrl)
    {
        _baseUrl = baseUrl;
    }

    public Endpoint List() => new Endpoint(_baseUrl, "/admin/identities", HttpMethod.Get);

    public Endpoint Delete() => new Endpoint(_baseUrl, "/admin/identities/{id}", HttpMethod.Delete);

    public Endpoint Get() => new Endpoint(_baseUrl, "/admin/identities/{id}", HttpMethod.Get);
}