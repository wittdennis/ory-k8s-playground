namespace KratosClient.Core;

/// <summary>
/// Represents a URL query parameter
/// </summary>
internal record RequestParameter
{
    /// <summary>
    /// Name of the parameter
    /// </summary>
    public string Name { get; }
    /// <summary>
    /// Value of the parameter
    /// </summary>
    public string Value { get; }
    /// <summary>
    /// Type of the request parameter
    /// </summary>
    public RequestParameterType Type { get; }

    /// <summary>
    /// Creates a new <see cref="RequestParameter" />
    /// </summary>
    /// <param name="name">Name of the parameter</param>
    /// <param name="value">Value of the parameter</param>
    /// <param name="type">Type of the parameter</param>
    /// <param name="urlEncode">Flag indicating if <paramref name="value" /> should be url encoded or not</param>
    public RequestParameter(string name, object value, RequestParameterType type, bool urlEncode = true)
    {
        Name = name;
        Type = type;

        Value = urlEncode ? System.Web.HttpUtility.UrlEncode(value.ToString()!) : value.ToString()!;
    }
}

/// <summary>
/// Type of a <see cref="RequestParameter" />
/// </summary>
internal enum RequestParameterType
{
    /// <summary>
    /// Parameter should be added as url parameter
    /// </summary>
    QueryParameter = 0,
    /// <summary>
    /// Parameter is a url segment and should replace a placeholder with the same name
    /// </summary>
    UrlSegment = 1
}