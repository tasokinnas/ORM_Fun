// <copyright file="ServiceExtensions.cs" company="Allata, LLC">
// Copyright (c) Allata, LLC. All rights reserved.
// </copyright>

namespace DapperSample.Extensions
{



    using Microsoft.AspNetCore.Builder;
    using Dapper;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;


    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }
    
    }
}
