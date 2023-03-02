namespace KratosClient.Core;

/// <summary>
/// Data type of a <see cref="RequestBody" />
/// </summary>
internal enum DataFormat
{
    /// <summary>
    /// No data type specified. Defaults to <see cref="DataFormat.Json" />
    /// </summary>
    None = 0,
    /// <summary>
    /// Data should be formatted as json data
    /// </summary>
    Json = 1
}