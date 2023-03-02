using System.Text.Json.Serialization;

namespace KratosClient.Types;

/// <summary>
/// Credentials that can be used with a <see cref="Identity" />
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(IdentityPasswordCredentials), typeDiscriminator: "password")]
public record IdentityCredentials
{
    /// <summary>
    /// Config for the credential
    /// </summary>
    [JsonPropertyName("config")]
    public object? Config { get; init; } = default;

    /// <summary>
    /// When the credentials were created
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// Identifiers represents a list of unique identifiers this credential type matches.
    /// </summary>    
    [JsonPropertyName("identifiers")]
    public IReadOnlyCollection<string> Identifiers { get; init; } = new List<string>();

    /// <summary>
    /// Gets or Sets Type
    /// </summary>
    [JsonPropertyName("type")]
    public IdentityCredentialsType Type { get; init; }

    /// <summary>
    /// When the credentials where last updated.
    /// </summary>    
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; init; }

    /// <summary>
    /// Version refers to the version of the credential. Useful when changing the config schema.
    /// </summary>    
    [JsonPropertyName("version")]
    public long Version { get; init; }

    /// <summary>
    /// Gets or Sets additional properties
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties { get; init; } = new Dictionary<string, object>();
}