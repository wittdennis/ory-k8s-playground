using System.Text.Json.Serialization;

namespace KratosClient.Types;

/// <summary>
/// Address information that can be verified
/// </summary>
public record VerifiableAddress
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
    /// When the address was verified.
    /// </summary>    
    [JsonPropertyName("verified_at")]
    public DateTime? VerifiedAt { get; init; }

    /// <summary>
    /// Indicates if the address has already been verified
    /// </summary>
    [JsonPropertyName("verified")]
    public bool Verified { get; init; }

    /// <summary>
    /// Status message for the <see cref="VerifiableAddress" />. Must not exceed 16 characters.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; init; } = "";

    /// <summary>
    /// Additional properties 
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties { get; init; } = new Dictionary<string, object>();
}