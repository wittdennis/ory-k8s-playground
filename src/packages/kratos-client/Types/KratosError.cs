using System.Text.Json.Serialization;

namespace KratosClient.Types;

/// <summary>
/// Represents a generic kratos error
/// </summary>
public record KratosError
{
    /// <summary>
    /// The status code
    /// </summary>
    [JsonPropertyName("code")]
    public long Code { get; init; }

    /// <summary>
    /// Debug information
    /// 
    /// <para>This field is often not exposed to protect against leaking sensitive information.</para>
    /// </summary>
    [JsonPropertyName("debug")]
    public string Debug { get; init; } = "";

    /// <summary>
    /// The error ID
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; } = "";

    /// <summary>
    /// Error message
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; init; } = "";

    /// <summary>
    /// A human-readable reason for the error
    /// </summary>
    [JsonPropertyName("reason")]
    public string Reason { get; init; } = "";

    /// <summary>
    /// The request ID
    /// 
    /// <para>The request ID is often exposed internally in order to trace errors across service architectures. This is often a UUID.</para>
    /// </summary>
    [JsonPropertyName("request")]
    public string Request { get; init; } = "";

    /// <summary>
    /// The status description
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; init; } = "";

    /// <summary>
    /// Further error details
    /// </summary>
    [JsonPropertyName("details")]
    public object? Details { get; init; } = default;
}