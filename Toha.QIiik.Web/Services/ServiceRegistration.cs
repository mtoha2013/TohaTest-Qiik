using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toha.QIiik.Web.Interfaces;

namespace Toha.QIiik.Web.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITriangleService, TriangleService>();
            services.AddScoped<IFibonacciService, FibonacciService>();
            services.AddScoped<IReverseWordService, ReverseWordService>();
            services.AddScoped<IAlgorithmService, AlgorithmService>();

            return services;
        }
    }
}
