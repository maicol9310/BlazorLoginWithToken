﻿using Microsoft.Extensions.DependencyInjection;

namespace BlazorCRUD.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorizationCore();
        }

    }
}
