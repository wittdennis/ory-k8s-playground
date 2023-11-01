using KratosClient.Core;

namespace KratosClient.Endpoints;

internal sealed class IdentityEndpoints
{
    private readonly Uri _baseUrl;

    public IdentityEndpoints(Uri baseUrl)
    {
        _baseUrl = baseUrl;
    }

    /// <summary>
    /// Endpoint to list all identities in the system
    /// </summary>
    /// <param name="perPage">Number of items per page. Must be between 1 and 1000</param>
    /// <param name="page">Page to retrieve. Must be greater or equal to one</param>
    /// <returns>The <see cref="Request"/> to be used to call the api</returns>
    /// <exception cref="ArgumentException">When <paramref name="perPage"/> is not between 1 and 1000 or <paramref name="page"/> is smaller 1.</exception>
    public Request List(int? perPage = null, int? page = null)
    {
        if (perPage != null && (perPage < 1 || perPage > 1000))
        {
            throw new ArgumentException("Must be between 1 and 1000", nameof(perPage));
        }
        if (page != null && page < 1)
        {
            throw new ArgumentException("Must be equal or greater 1", nameof(page));
        }

        Request listRequest = Request.New(EndpointUrlBuilder.Build(_baseUrl, "/admin/identities"), HttpMethod.Get);
        if (perPage.HasValue)
        {
            listRequest.AddParameter("per_page", perPage.Value);
        }
        if (page.HasValue)
        {
            listRequest.AddParameter("page", page.Value);
        }

        return listRequest;
    }

    /// <summary>
    /// Endpoint to delete the identity with the specified id.
    /// </summary>
    /// <param name="id">Id that should be deleted.</param>
    /// <returns>The <see cref="Request"/> to be used to call the api</returns>
    /// <exception cref="ArgumentException">When <paramref name="id"/> is null or empty</exception>
    public Request Delete(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"{nameof(id)} can't be null or empty");
        }

        return Request.New(EndpointUrlBuilder.Build(_baseUrl, "/admin/identities/{id}"), HttpMethod.Delete).AddUrlSegment("id", id);
    }

    /// <summary>
    /// Endpoint to retrieve a specific identity
    /// </summary>
    /// <param name="id">The id of the identity</param>
    /// <param name="includeCredentials">Specify which credentials should be included in the response</param>
    /// <returns>The <see cref="Request"/> to be used to call the api</returns>
    /// <exception cref="ArgumentException">When <paramref name="id"/> is null or empty</exception>
    public Request Get(string id, IEnumerable<string>? includeCredentials = null)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"{nameof(id)} can't be null or empty");
        }

        Request getRequest = Request.New(EndpointUrlBuilder.Build(_baseUrl, "/admin/identities/{id}"), HttpMethod.Get).AddUrlSegment("id", id);
        if (includeCredentials != null && includeCredentials.Any())
        {
            getRequest.AddParameter("include_credentials", includeCredentials);
        }

        return getRequest;
    }
}