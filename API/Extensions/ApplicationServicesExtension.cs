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
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
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

        return services;
    }
}