namespace KratosClient.Core;

internal static class ResponseBuilder
{
    public static IResponse Create(HttpResponseMessage responseMessage, Request causingRequest)
    {
        Response response = new(causingRequest, responseMessage)
        {
            IsSuccessStatusCode = responseMessage.IsSuccessStatusCode,
            StatusCode = responseMessage.StatusCode,
            Version = responseMessage.Version,
            ContentLength = responseMessage.Content.Headers.ContentLength,
            ReasonPhrase = responseMessage.ReasonPhrase ?? "",
            ContentType = responseMessage.Content.Headers.ContentType,
            Headers = responseMessage.Headers,
            ContentHeaders = responseMessage.Content.Headers
        };

        return response;
    }
}