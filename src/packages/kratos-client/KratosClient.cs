using KratosClient.Apis;
using KratosClient.Apis.Interfaces;
using KratosClient.Core;
using KratosClient.Endpoints;
using Microsoft.Extensions.Options;

namespace KratosClient;

public class KratosClient
{
    public IIdentityApi IdentityApi { get; }

    public KratosClient(KratosClientOptions options)
    {
        IApiClient apiClient = new ApiClient(new HttpClient());
        KratosEndpoints endpoints = new KratosEndpoints(new Uri(options.PublicBaseUrl), new Uri(options.AdminBaseUrl));

        IdentityApi = new IdentityApi(apiClient, endpoints);
    }

    public KratosClient(HttpClient httpClient, IOptions<KratosClientOptions> options)
    {
        IApiClient apiClient = new ApiClient(httpClient);
        KratosClientOptions kratosOptions = options.Value;
        KratosEndpoints endpoints = new KratosEndpoints(new Uri(kratosOptions.PublicBaseUrl), new Uri(kratosOptions.AdminBaseUrl));

        IdentityApi = new IdentityApi(apiClient, endpoints);
    }
}