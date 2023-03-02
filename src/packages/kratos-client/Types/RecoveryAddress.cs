using System.Text.Json.Serialization;

namespace KratosClient.Types;

/// <summary>
/// Address information for identity recovery
/// </summary>
public record RecoveryAddress
{
    /// <summary>
    /// When the address was created
    /// </summary>    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// Id of the address
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; } = "";

    /// <summary>
    /// When the address was last updated.
    /// </summary>    
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; init; }

    /// <summary>
    /// The address to send the recovery information to
    /// </summary>
    [JsonPropertyName("value")]
    public string Address { get; init; } = "";

    /// <summary>
    /// The method to send the recovery information with
    /// </summary>
    [JsonPropertyName("via")]
    public string Via { get; init; } = "";

    /// <summary>
    /// Additional properties 
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties { get; init; } = new Dictionary<string, object>();
}