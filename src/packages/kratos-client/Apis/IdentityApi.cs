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
        => ExecuteRequestAsync<KratosError>(_identityEndpoints.Delete(id), cancellationToken);

    /// <inheritdoc>
    public Task<IResult<Identity, KratosError>> GetAsync(string id, IEnumerable<string>? includeCredentials = null, CancellationToken cancellationToken = default)
        => ExecuteRequestAsync<Identity, KratosError>(_identityEndpoints.Get(id, includeCredentials), cancellationToken);

    /// <inheritdoc>
    public Task<IResult<IReadOnlyCollection<Identity>, KratosError>> ListAsync(int? perPage = null, int? page = null, CancellationToken cancellationToken = default)
        => ExecuteRequestAsync<IReadOnlyCollection<Identity>, KratosError>(_identityEndpoints.List(perPage, page), cancellationToken);

}