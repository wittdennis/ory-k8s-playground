namespace KratosClient.Endpoints;

internal sealed class KratosEndpoints
{
    public IdentityEndpoints IdentityEndpoints { get; }

    public KratosEndpoints(Uri kratosPublicBaseUrl, Uri kratosPrivateBaseUrl)
    {
        IdentityEndpoints = new IdentityEndpoints(kratosPrivateBaseUrl);
    }
}