﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Modules;
using Microsoft.AspNetCore.Nancy.Modules;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Orchard.Nancy
{
    public class Startup : StartupBase
    {
        private readonly IServiceProvider _applicationServices;

        public Startup(IServiceProvider applicationServices)
        {
            _applicationServices = applicationServices;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddNancyModules(_applicationServices);
        }

        public override void Configure(IApplicationBuilder app, IRouteBuilder routes, IServiceProvider serviceProvider)
        {
            app.ConfigureModules(apb =>
            {
                apb.UseNancyModules();
                apb.UseStaticFilesModules();
            });
        }
    }
}
