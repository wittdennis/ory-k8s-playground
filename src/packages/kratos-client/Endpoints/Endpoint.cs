namespace KratosClient.Endpoints;

/// <summary>
/// Rest API endpoint
/// </summary>
internal struct Endpoint
{
    /// <summary>
    /// The url of the endpoint
    /// </summary>
    public Uri Url { get; }

    /// <summary>
    /// The <see cref="HttpMethod"/> for the request
    /// </summary>
    public HttpMethod Method { get; }

    /// <summary>
    /// Initializes a new <see cref="Endpoint"/> 
    /// </summary>
    /// <param name="baseUrl">The base url of the request</param>
    /// <param name="uri">The relative uri for the endpoint</param>
    /// <param name="method">The http method to use for the request</param>
    /// <param name="authentication">The authentication method to use</param>
    public Endpoint(Uri baseUrl, string uri, HttpMethod method) :
        this(!baseUrl.OriginalString.EndsWith("/") ? new Uri(new Uri(baseUrl.OriginalString + "/"), uri.TrimStart('/')) : new Uri(baseUrl, uri.TrimStart('/')), method)
    { }

    /// <summary>
    /// Initializes a new <see cref="Endpoint"/>
    /// </summary>
    /// <param name="url">The absolute url of the enpoint</param>
    /// <param name="method">The HTTP method to use for the request</param>
    /// <param name="authentication">The authentication method to use</param>
    public Endpoint(Uri url, HttpMethod method)
    {
        Url = url;
        Method = method;
    }
}