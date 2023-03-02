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
    public async Task<IResult<IReadOnlyCollection<Identity>, KratosError>> ListAsync(int? perPage, int? page, CancellationToken cancellationToken = default)
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

        return await ExecuteRequestAsync<IReadOnlyCollection<Identity>, KratosError>(listRequest, cancellationToken).ConfigureAwait(false);
    }
}