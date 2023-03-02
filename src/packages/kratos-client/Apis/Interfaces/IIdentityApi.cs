using KratosClient.Types;

namespace KratosClient.Apis.Interfaces;

/// <summary>
/// Kratos identity api
/// </summary>
public interface IIdentityApi
{
    /// <summary>
    /// Lists all identities in the system
    /// </summary>
    /// <param name="perPage">Number of items per page. Must be between 1 and 1000</param>
    /// <param name="page">Page to retrieve. Must be greater or equal to one</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns></returns>
    public Task<IResult<IReadOnlyCollection<Identity>, KratosError>> ListAsync(int? perPage = null, int? page = null, CancellationToken cancellationToken = default);
}