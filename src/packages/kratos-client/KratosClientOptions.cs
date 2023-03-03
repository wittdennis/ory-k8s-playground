namespace KratosClient;

/// <summary>
/// Options to configure <see cref="KratosClient" />
/// </summary>
public class KratosClientOptions
{
    /// <summary>
    /// Kratos base url for the public apis
    /// </summary>
    public string PublicBaseUrl { get; set; } = "";
    /// <summary>
    /// Kratos base url for the private apis
    /// </summary>
    public string AdminBaseUrl { get; set; } = "";
}