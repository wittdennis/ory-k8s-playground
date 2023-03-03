using KratosClient;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class KratosClientServiceCollectionExtensions
{
    public static IServiceCollection AddKratosClient(this IServiceCollection serviceCollection, Action<KratosClientOptions> configureAction)
    {
        serviceCollection.AddHttpClient<KratosClient.KratosClient>();
        serviceCollection.Configure<KratosClientOptions>(configureAction);

        return serviceCollection;
    }

    public static IServiceCollection AddKratosClient(this IServiceCollection serviceCollection, Action<IServiceProvider, KratosClientOptions> configureAction)
    {
        serviceCollection.AddHttpClient<KratosClient.KratosClient>();
        serviceCollection.AddSingleton<IConfigureOptions<KratosClientOptions>>(services =>
        {
            return new ConfigureOptions<KratosClientOptions>((opt) => configureAction(services, opt));
        });

        return serviceCollection;
    }
}