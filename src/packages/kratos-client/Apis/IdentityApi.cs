using KratosClient.Apis.Interfaces;
using KratosClient.Core;
using KratosClient.Endpoints;
using KratosClient.Types;

namespace KratosClient.Apis;

internal class IdentityApi : BaseApi, IIdentityApi
{
    private readonly IdentityEndpoints _identityEndpoints;

    public IdentityApi(IApiClient apiClient, KratosEndpoints endpoints) : base(apiClient)
    {
        _identityEndpoints = endpoints.IdentityEndpoints;
    }

    /// <inheritdoc>
    public Task<IEmptyResult<KratosError>> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"{nameof(id)} can't be null or empty", id);
        }

        Endpoint deleteEndpoint = _identityEndpoints.Delete();
        Request deleteRequest = Request.New(deleteEndpoint.Url, deleteEndpoint.Method)
                                        .AddUrlSegment("id", id);

        return ExecuteRequestAsync<KratosError>(deleteRequest, cancellationToken);
    }

    /// <inheritdoc>
    public Task<IResult<Identity, KratosError>> GetAsync(string id, IEnumerable<string>? includeCredentials = null, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"{nameof(id)} can't be null or empty");
        }

        Endpoint getEndpoint = _identityEndpoints.Get();
        Request getRequest = Request.New(getEndpoint.Url, getEndpoint.Method)
                                    .AddUrlSegment("id", id);

        if (includeCredentials != null && includeCredentials.Any())
        {
            getRequest.AddParameter("include_credentials", includeCredentials);
        }

        return ExecuteRequestAsync<Identity, KratosError>(getRequest, cancellationToken);
    }

    /// <inheritdoc>
    public Task<IResult<IReadOnlyCollection<Identity>, KratosError>> ListAsync(int? perPage, int? page, CancellationToken cancellationToken = default)
    {
        if (perPage != null && (perPage < 1 || perPage > 1000))
        {
            throw new ArgumentException("Must be between 1 and 1000", nameof(perPage));
        }
        if (page != null && page < 1)
        {
            throw new ArgumentException("Must be equal or greater 1", nameof(page));
        }

        Endpoint listEndpoint = _identityEndpoints.List();
        Request listRequest = Request.New(listEndpoint.Url, listEndpoint.Method);
        if (perPage.HasValue)
        {
            listRequest.AddParameter("per_page", perPage.Value);
        }
        if (page.HasValue)
        {
            listRequest.AddParameter("page", page.Value);
        }

        return ExecuteRequestAsync<IReadOnlyCollection<Identity>, KratosError>(listRequest, cancellationToken);
    }
}