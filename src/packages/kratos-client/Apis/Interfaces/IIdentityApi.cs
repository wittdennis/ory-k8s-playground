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

    /// <summary>
    /// Deletes the identity with the specified id
    /// </summary>
    /// <param name="id">Id of the identity to delete</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns></returns>
    public Task<IEmptyResult<KratosError>> DeleteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns an identity by its ID
    /// </summary>
    /// <param name="id">ID of the identity to get</param>
    /// <param name="includeCredentials">Specify which credentials should be included in the response</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns></returns>
    public Task<IResult<Identity, KratosError>> GetAsync(string id, IEnumerable<string>? includeCredentials = null, CancellationToken cancellationToken = default);
}