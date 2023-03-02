using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace KratosClient.Types;

/// <summary>
/// State of a identity
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IdentityState
{
    /// <summary>
    /// Identity is inactive
    /// </summary>
    [JsonPropertyName("inactive")]
    Inactive = 0,
    /// <summary>
    /// Identity is active
    /// </summary>
    [JsonPropertyName("active")]
    Active = 1,
}