using System.Net;

namespace KratosClient.Core;

internal interface IResponse
{
    bool IsSuccessStatusCode { get; }

    HttpStatusCode StatusCode { get; }
}