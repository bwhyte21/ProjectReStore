using API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API;

public class Startup
{
    /// <summary>
    /// Private configuration member.
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Startup Ctor.
    /// </summary>
    /// <param name="configuration"></param>
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// This method gets called by the runtime. Use this method to add services to the container. (Dependency Injection
    /// Container)
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        #region Controller Services

        services.AddControllers();

        #endregion

        #region Application Services

        services.AddApplicationServices(_configuration);

        #endregion
    }

    /// <summary>
    /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline. (Middleware)
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.AddApplicationMiddleware(env);
    }
}