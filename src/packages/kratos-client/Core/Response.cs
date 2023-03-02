using System.Net;

namespace KratosClient.Core;

internal class Response : IResponse
{
    public bool IsSuccessStatusCode { get; set; }

    public HttpStatusCode StatusCode { get; set; }
}