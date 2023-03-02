using System.Text.Json.Serialization;

namespace KratosClient.Types;

/// <summary>
/// Password credentials for a <see cref="Identity" />
/// </summary>
public record IdentityPasswordCredentials : IdentityCredentials
{
    /// <summary>
    /// HashedPassword is a hash-representation of the password.
    /// </summary>
    [JsonPropertyName("hashed_password")]
    public string HashedPassword { get; init; } = "";
}