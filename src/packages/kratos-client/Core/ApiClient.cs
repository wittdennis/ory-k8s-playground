namespace KratosClient.Core;

internal class ApiClient : IApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IResponse> ExecuteAsync(Request request, CancellationToken cancellationToken = default)
    {
        HttpRequestMessage requestMessage = HttpRequestBuilder.Create(request);
        HttpResponseMessage responseMessage = await _httpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

        return ResponseBuilder.Create(responseMessage, request);
    }
}