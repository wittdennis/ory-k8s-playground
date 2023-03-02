using System.Net;
using System.Net.Http.Headers;

namespace KratosClient.Core;

internal interface IResponse : IDisposable
{
    bool IsSuccessStatusCode { get; }

    HttpStatusCode StatusCode { get; }

    string ReasonPhrase { get; }

    long? ContentLength { get; }

    MediaTypeHeaderValue? ContentType { get; }

    HttpResponseHeaders Headers { get; }

    HttpContentHeaders ContentHeaders { get; }

    /// <summary>
    /// Http message version
    /// </summary>
    Version Version { get; }

    /// <summary>
    /// The request that caused the <see cref="IResponse" />
    /// </summary>
    Request Request { get; }

    /// <summary>
    /// Serializes the content and reads it as stream
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel the operation</param>
    /// <returns></returns>
    Task<Stream> ReadContentAsStreamAsync(CancellationToken cancellationToken = default);
}