
namespace KratosClient.Endpoints;

/// <summary>
/// Url builder to ensure proper build urls
/// </summary>
internal static class EndpointUrlBuilder
{
    public static Uri Build(Uri baseUri, string endpoint)
        => new Uri(new Uri($"{baseUri.OriginalString.TrimEnd('/')}/"), endpoint.TrimStart('/'));
}