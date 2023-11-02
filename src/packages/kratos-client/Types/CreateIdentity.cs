using System.Text.Json.Serialization;
using KratosClient.JsonConverter;

namespace KratosClient.Types;

/// <summary>
///
/// </summary>
/// <param name="SchemaId">SchemaID is the ID of the JSON Schema to be used for validating the identity's traits.</param>
/// <param name="Traits">Traits represent an identity's traits. The identity is able to create, modify, and delete traits in a self-service manner. The input will always be validated against the JSON Schema defined in schema_url</param>
public record CreateIdentity([property: JsonPropertyName("schema_id")] string SchemaId,
                             [property: JsonPropertyName("traits")] IDictionary<string, object> Traits)
{
    /// <summary>
    /// Credentials represents all credentials that can be used for authenticating this identity.
    /// </summary>
    [JsonPropertyName("credentials")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, IdentityCredentials>? Credentials { get; init; } = null;

    /// <summary>
    /// Additional metadata for the identity only available from admin apis
    /// </summary>
    [JsonPropertyName("metadata_admin"), JsonConverter(typeof(UnsafeRawJsonConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MetadataAdmin { get; init; } = "";

    /// <summary>
    /// Additional metadata for the identity
    /// </summary>
    [JsonPropertyName("metadata_public"), JsonConverter(typeof(UnsafeRawJsonConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MetadataPublic { get; init; } = "";

    /// <summary>
    /// The state of the identity
    /// </summary>
    [JsonPropertyName("state")]
    public IdentityState State { get; init; } = IdentityState.Inactive;

    /// <summary>
    /// Contains all the addresses that can be used to recover an identity.
    /// </summary>
    [JsonPropertyName("recovery_addresses")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyCollection<RecoveryAddress>? RecoveryAddresses { get; init; } = new List<RecoveryAddress>();

    /// <summary>
    /// Contains all the addresses that can be verified by the user.
    /// </summary>
    [JsonPropertyName("verifiable_addresses")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyCollection<VerifiableAddress>? VerifiableAddresses { get; init; } = new List<VerifiableAddress>();
}