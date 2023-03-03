using System.Net.Http.Json;

namespace KratosClient.Core;

internal static class HttpRequestBuilder
{
    public static HttpRequestMessage Create(Request request)
    {
        HttpRequestMessage requestMessage = new(request.Method, BuildUri(request));

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

    private static Uri BuildUri(Request request)
    {
        if (request.Parameters.Count == 0)
        {
            return request.Endpoint;
        }

        string query = MergeQueryParameters(request);
        string path = ReplaceUrlSegmentPlaceholder(request);

        UriBuilder uriBuilder = new(request.Endpoint);
        uriBuilder.Query = query;
        uriBuilder.Path = path;

        return uriBuilder.Uri;
    }

    private static string MergeQueryParameters(Request request)
    {
        RequestParameter[] queryParameters = request.Parameters.Where(p => p.Type == RequestParameterType.QueryParameter).ToArray();
        if (queryParameters.Length == 0)
        {
            return request.Endpoint.Query;
        }

        string separator = request.Endpoint.Query.Contains("?") ? "&" : "?";
        string query = $"{request.Endpoint.Query}{separator}{string.Join('&', queryParameters.Select(p => $"{p.Name}={p.Value}"))}";

        return query;
    }

    private static string ReplaceUrlSegmentPlaceholder(Request request)
    {
        RequestParameter[] urlSegmentParameters = request.Parameters.Where(p => p.Type == RequestParameterType.UrlSegment).ToArray();
        if (urlSegmentParameters.Length == 0)
        {
            return request.Endpoint.LocalPath;
        }

        string path = request.Endpoint.LocalPath;
        for (int i = 0; i < urlSegmentParameters.Length; i++)
        {
            path = path.Replace($"{{{urlSegmentParameters[i].Name}}}", urlSegmentParameters[i].Value);
        }

        return path;
    }
}