namespace Microsoft.Extensions.DependencyInjection;
public static partial class ServiceCollectionExtension
{
    public static void AddHttpRequest(this IServiceCollection services)
        => services.AddHttpClient<RequestHandler>();
}