namespace KratosClient.Core;

internal class Request
{
    private List<RequestParameter> _parameters = new();
    private RequestBody? _body = null;

    public HttpMethod Method { get; set; } = HttpMethod.Get;
    public Uri Endpoint { get; set; }
    public IReadOnlyCollection<RequestParameter> Parameters => _parameters;
    public RequestBody? Body { get { return _body; } }

    public Request(Uri endpoint)
    {
        Endpoint = endpoint;
    }

    public static Request New(string url) => New(new Uri(url), HttpMethod.Get);
    public static Request New(Uri url) => New(url, HttpMethod.Get);
    public static Request New(string url, HttpMethod method) => New(new Uri(url), method);

    public static Request New(Uri url, HttpMethod method) => new Request(url)
    {
        Method = method
    };

    public Request AddJsonBody<T>(T data) where T : notnull
    {
        _body = new RequestBody(data, DataFormat.Json);
        return this;
    }

    public Request AddParameter(string parameter, string value)
        => AddParameter(parameter, value, RequestParameterType.QueryParameter);

    public Request AddParameter(string parameter, int value)
        => AddParameter(parameter, value, RequestParameterType.QueryParameter);

    public Request AddParameter(string parameter, long value)
        => AddParameter(parameter, value, RequestParameterType.QueryParameter);

    public Request AddParameter(string parameter, IEnumerable<string> value)
    {
        foreach (string entry in value)
        {
            AddParameter(parameter, entry, RequestParameterType.QueryParameter);
        }

        return this;
    }

    public Request AddUrlSegment(string placeholderName, string value)
        => AddParameter(placeholderName, value, RequestParameterType.UrlSegment);

    public Request AddUrlSegment(string placeholderName, int value)
        => AddParameter(placeholderName, value, RequestParameterType.UrlSegment);

    public Request AddUrlSegment(string placeholderName, long value)
        => AddParameter(placeholderName, value, RequestParameterType.UrlSegment);


    private Request AddParameter(string parameter, object value, RequestParameterType type, bool urlEncode = true)
    {
        _parameters.Add(new RequestParameter(parameter, value, type, urlEncode));

        return this;
    }

}