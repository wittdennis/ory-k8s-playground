using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace KratosClient.Types;

/// <summary>
/// and so on.
/// </summary>
/// <value>and so on.</value>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IdentityCredentialsType
{
    /// <summary>
    /// Enum Password for value: password
    /// </summary>
    [EnumMember(Value = "password")]
    Password = 1,

    /// <summary>
    /// Enum Totp for value: totp
    /// </summary>
    [EnumMember(Value = "totp")]
    Totp = 2,

    /// <summary>
    /// Enum Oidc for value: oidc
    /// </summary>
    [EnumMember(Value = "oidc")]
    Oidc = 3,

    /// <summary>
    /// Enum Webauthn for value: webauthn
    /// </summary>
    [EnumMember(Value = "webauthn")]
    Webauthn = 4,

    /// <summary>
    /// Enum LookupSecret for value: lookup_secret
    /// </summary>
    [EnumMember(Value = "lookup_secret")]
    LookupSecret = 5

}
