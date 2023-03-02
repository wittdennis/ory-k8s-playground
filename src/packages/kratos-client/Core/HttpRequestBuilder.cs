using System.Net.Http.Json;

namespace KratosClient.Core;

internal static class HttpRequestBuilder
{
    public static HttpRequestMessage Create(Request request)
    {
        HttpRequestMessage requestMessage = new(request.Method, request.Endpoint);

        if (request.Body != null)
        {
            requestMessage.Content = CreateContent(request);
        }

        return requestMessage;
    }

    private static HttpContent CreateContent(Request request) => request.Body!.Format switch
    {
        _ => JsonContent.Create(request.Body.Value)
    };
}