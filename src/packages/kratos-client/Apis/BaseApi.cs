using System.Text.Json;
using KratosClient.Core;
using KratosClient.Types;

namespace KratosClient.Apis;

internal abstract class BaseApi
{
    private readonly IApiClient _apiClient;

    protected BaseApi(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    protected virtual Task<IResponse> ExecuteRequestAsync(Request request, CancellationToken cancellationToken = default)
        => _apiClient.ExecuteAsync(request, cancellationToken);

    protected virtual async Task<IResult<T, TError>> ExecuteRequestAsync<T, TError>(Request request, CancellationToken cancellationToken = default)
    {
        IResponse response = await ExecuteRequestAsync(request, cancellationToken).ConfigureAwait(false);

        Stream contentStream = await response.ReadContentAsStreamAsync(cancellationToken).ConfigureAwait(false);
        T? successResult = default;
        KratosErrorContainer<TError>? errorResult = default;
        if (response.IsSuccessStatusCode)
        {
            successResult = await JsonSerializer.DeserializeAsync<T>(contentStream, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        else
        {
            errorResult = await JsonSerializer.DeserializeAsync<KratosErrorContainer<TError>>(contentStream, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        if (successResult != null)
        {
            return new Result<T, TError>(successResult);
        }

        if (errorResult == null || errorResult.Error == null)
        {
            throw new JsonException("Error while trying to deserialize result");
        }

        return new Result<T, TError>(errorResult.Error);
    }

    protected virtual async Task<IEmptyResult<TError>> ExecuteRequestAsync<TError>(Request request, CancellationToken cancellationToken = default)
    {
        IResponse response = await ExecuteRequestAsync(request, cancellationToken).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            return new EmptyResult<TError>();
        }

        Stream contentStream = await response.ReadContentAsStreamAsync(cancellationToken).ConfigureAwait(false);

        KratosErrorContainer<TError>? error = await JsonSerializer.DeserializeAsync<KratosErrorContainer<TError>>(contentStream, cancellationToken: cancellationToken).ConfigureAwait(false);
        if (error == null || error.Error == null)
        {
            throw new JsonException("Error while trying to deserialize result");
        }

        return new EmptyResult<TError>(error.Error);
    }
}