using KratosClient.Apis;
using KratosClient.Apis.Interfaces;
using KratosClient.Core;
using KratosClient.Endpoints;

namespace KratosClient;

public class KratosClient
{
    public IIdentityApi IdentityApi { get; }

    public KratosClient(KratosClientOptions options)
    {
        HttpClient httpClient = new HttpClient();
        IApiClient apiClient = new ApiClient(httpClient);
        KratosEndpoints endpoints = new KratosEndpoints(new Uri(options.PublicBaseUrl), new Uri(options.AdminBaseUrl));

        IdentityApi = new IdentityApi(apiClient, endpoints);
    }
}