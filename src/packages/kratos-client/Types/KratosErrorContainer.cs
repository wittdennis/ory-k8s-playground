using System.Text.Json.Serialization;

namespace KratosClient.Types;

internal record KratosErrorContainer<TError>
{
    [JsonPropertyName("error")]
    public TError? Error { get; init; } = default(TError);
}