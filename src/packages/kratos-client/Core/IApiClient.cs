namespace KratosClient.Core;

internal interface IApiClient
{
    Task<IResponse> ExecuteAsync(Request request, CancellationToken cancellationToken = default);
}