namespace Toha.QIiik.UnitTest
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class DependencyResolver
    {
        private readonly IWebHost _webHost;

        public DependencyResolver(IWebHost WebHost)
        {
            _webHost = WebHost;
        }

        public T GetService<T>()
        {
            using (var serviceScope = _webHost.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var scopedService = services.GetRequiredService<T>();
                    return scopedService;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
