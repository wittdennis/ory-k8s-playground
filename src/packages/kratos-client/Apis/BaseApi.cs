using System.Text.Json;
using KratosClient.Core;
using KratosClient.Types;

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

    protected virtual async Task<IResult<T, TError>> ExecuteRequestAsync<T, TError>(Request request, CancellationToken cancellationToken = default)
    {
        IResponse response = await ExecuteRequestAsync(request, cancellationToken).ConfigureAwait(false);

        Stream contentStream = await response.ReadContentAsStreamAsync(cancellationToken).ConfigureAwait(false);
        T? successResult = default(T);
        TError? errorResult = default(TError);
        if (response.IsSuccessStatusCode)
        {
            successResult = await JsonSerializer.DeserializeAsync<T>(contentStream, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        else
        {
            errorResult = await JsonSerializer.DeserializeAsync<TError>(contentStream, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        if (errorResult == null && successResult == null)
        {
            throw new JsonException();
        }

        return successResult != null ? new Result<T, TError>(successResult) : new Result<T, TError>(errorResult!);
    }
}