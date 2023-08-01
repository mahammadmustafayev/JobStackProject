

namespace JobStack.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddMediatR(Assembly.GetExecutingAssembly());

        //services.AddNewtonsoftJson.Include(p => p.CityId).Include(p => p.CountryId).AsNoTracking();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //services.AddFluentValidationAutoValidation();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        // Behaviours 
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationExceptionBehaviour<,>));

        return services;
    }
}
