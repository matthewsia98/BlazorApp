namespace BlazorApp;

public static class ServiceCollectionExtensions
{
    public static T AddAndValidateOptions<T>(this IServiceCollection services, IConfiguration config)
        where T : class
    {
        services.AddOptions<T>()
            .BindConfiguration(typeof(T).Name)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var options = config.GetSection(typeof(T).Name).Get<T>()
            ?? throw new Exception($"Could not bind configuration for {typeof(T).Name}");

        return options;
    }
}
