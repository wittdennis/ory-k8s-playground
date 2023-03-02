namespace KratosClient.Core;

internal static class ResponseBuilder
{
    public static IResponse Create(HttpResponseMessage responseMessage)
    {
        Response response = new()
        {
            IsSuccessStatusCode = responseMessage.IsSuccessStatusCode,
            StatusCode = responseMessage.StatusCode
        };

        return response;
    }
}