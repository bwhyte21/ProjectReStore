﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace API.Extensions;

public static class ApplicationMiddlewareExtension
{
    public static IApplicationBuilder AddApplicationMiddleware(this IApplicationBuilder app, IWebHostEnvironment env, string corsPolicy)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectReStore v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        // CORS for api calls.
        app.UseCors(corsPolicy);

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        return app;
    }
}