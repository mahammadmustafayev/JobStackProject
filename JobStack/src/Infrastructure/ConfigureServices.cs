﻿



namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("vacancyDb"),
            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<ApplicationDbContextInitializer>();



        services.AddIdentity<ApplicationUser, AppRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        //services.AddIdentityCore<ApplicationUser>()
        //    .AddRoles<AppRole>()
        //    .AddEntityFrameworkStores<ApplicationDbContext>();

        //services.AddScoped<RoleManager<AppRole>>();

        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddTransient<IDateTime, DateTimeService>();


        return services;
    }


}

