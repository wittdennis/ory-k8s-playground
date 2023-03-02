using System.Net;
using System.Net.Http.Headers;

namespace KratosClient.Core;

internal record Response : IResponse
{
    private readonly HttpResponseMessage _responseMessage;
    private bool _disposed = false;

    public bool IsSuccessStatusCode { get; init; } = false;

    public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.InternalServerError;

    public Version Version { get; init; } = new Version();

    public Request Request { get; }

    public long? ContentLength { get; init; } = null;

    public string ReasonPhrase { get; init; } = "";

    public MediaTypeHeaderValue? ContentType { get; init; } = null;

    public HttpResponseHeaders Headers { get; init; }

    public HttpContentHeaders ContentHeaders { get; init; }

    public Response(Request causingRequest, HttpResponseMessage responseMessage)
    {
        Request = causingRequest;
        _responseMessage = responseMessage;
        Headers = responseMessage.Headers;
        ContentHeaders = responseMessage.Content.Headers;
    }

    public Task<Stream> ReadContentAsStreamAsync(CancellationToken cancellationToken = default)
        => _responseMessage.Content.ReadAsStreamAsync(cancellationToken);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _responseMessage.Dispose();
        }

        _disposed = true;
    }
}