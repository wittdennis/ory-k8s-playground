using System.Text.Json.Serialization;
using KratosClient.JsonConverter;

namespace KratosClient.Types;

public record Identity
{
    /// <summary>
    /// ID is the identity's unique identifier.
    ///
    /// <para>The Identity ID can not be changed and can not be chosen. The Identity ID can not be changed and can not be chosen.</para>
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; } = "";

    /// <summary>
    /// When the identity was created
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// Credentials represents all credentials that can be used for authenticating this identity.
    /// </summary>
    [JsonPropertyName("credentials")]
    public Dictionary<string, IdentityCredentials> Credentials { get; init; } = new();

    /// <summary>
    /// Additional metadata for the identity only available from admin apis
    /// </summary>
    [JsonPropertyName("metadata_admin"), JsonConverter(typeof(UnsafeRawJsonConverter))]
    public string? MetadataAdmin { get; init; } = "";

    /// <summary>
    /// Additional metadata for the identity
    /// </summary>
    [JsonPropertyName("metadata_public"), JsonConverter(typeof(UnsafeRawJsonConverter))]
    public string? MetadataPublic { get; init; } = "";

    /// <summary>
    /// SchemaID is the ID of the JSON Schema to be used for validating the identity's traits.
    /// </summary>
    [JsonPropertyName("schema_id")]
    public string SchemaId { get; init; } = "";

    /// <summary>
    /// SchemaURL is the URL of the endpoint where the identity's traits schema can be fetched from.
    /// </summary>
    [JsonPropertyName("schema_url")]
    public string SchemaUrl { get; init; } = "";

    /// <summary>
    /// The state of the identity
    /// </summary>
    [JsonPropertyName("state")]
    public IdentityState State { get; init; } = IdentityState.Inactive;

    /// <summary>
    /// Contains all the addresses that can be used to recover an identity.
    /// </summary>
    [JsonPropertyName("recovery_addresses")]
    public IReadOnlyCollection<RecoveryAddress> RecoveryAddresses { get; init; } = new List<RecoveryAddress>();

    /// <summary>
    /// Contains all the addresses that can be verified by the user.
    /// </summary>
    [JsonPropertyName("verifiable_addresses")]
    public IReadOnlyCollection<VerifiableAddress> VerifiableAddresses { get; init; } = new List<VerifiableAddress>();

    /// <summary>
    /// The time the <see cref="State" /> last changed
    /// </summary>
    [JsonPropertyName("state_changed_at")]
    public DateTime? StateChangedAt { get; init; }

    /// <summary>
    /// The time the identity was last updated
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; init; }

    /// <summary>
    /// Traits represent an identity's traits. The identity is able to create, modify, and delete traits in a self-service manner. The input will always be validated against the JSON Schema defined in <see cref="schema_url" />
    /// </summary>
    [JsonPropertyName("traits")]
    public IDictionary<string, object> Traits { get; init; } = new Dictionary<string, object>();

    /// <summary>
    /// Gets or Sets additional properties
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties { get; init; } = new Dictionary<string, object>();
}