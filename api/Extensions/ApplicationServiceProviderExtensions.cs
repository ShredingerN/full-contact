public static class ApplicationServiceProviderExtensions
{
    public static IServiceProvider AddCustomerService(
        this IServiceProvider services,
    IConfiguration configuration)
    {

        using var scope = services.CreateScope();

        var initializer = scope.ServiceProvider.GetRequiredService<IInitializer>();
        initializer.Initialize();
            
        return services;
    }
}