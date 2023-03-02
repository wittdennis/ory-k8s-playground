using KratosClient.Core;

namespace KratosClient.Apis;

internal abstract class BaseApi
{
    private readonly IApiClient _apiClient;

    public BaseApi(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    protected virtual Task<IResponse> ExecuteRequestAsync(Request request, CancellationToken cancellationToken = default)
        => _apiClient.ExecuteAsync(request, cancellationToken);
}