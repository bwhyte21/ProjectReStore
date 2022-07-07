using API.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions;

/// <summary>
/// Extension class for Startup.cs Services.
/// </summary>
public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration, string corsPolicy)
    {
        #region Swagger

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ProjectReStore",
                Version = "v1"
            });
        });

        #endregion

        #region DBContext

        services.AddDbContext<StoreContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        #endregion

        #region CORS Policy

        // Allow only the client app to access this API for sending/receiving requests/responses.
        services.AddCors(options =>
        {
            options.AddPolicy(name: corsPolicy, policy =>
            {
                policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
            });
        });

        #endregion

        return services;
    }
}