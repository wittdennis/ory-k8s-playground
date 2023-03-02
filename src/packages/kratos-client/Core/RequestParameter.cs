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
    /// Creates a new <see cref="RequestParameter" />
    /// </summary>
    /// <param name="name">Name of the parameter</param>
    /// <param name="value">Value of the parameter</param>
    /// <param name="urlEncode">Flag indicating if <paramref name="value" /> should be url encoded or not</param>
    public RequestParameter(string name, object value, bool urlEncode = true)
    {
        Name = name;

        Value = urlEncode ? System.Web.HttpUtility.UrlEncode(value.ToString()!) : value.ToString()!;
    }
}