namespace Emtec.EmBilling.Forecast.Shared.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;

    public static class MapperConfigBase
    {
        public static void AddMapper(this IServiceCollection services, params string[] assemblyNamesToProbe)
        {
            var profileList = new List<Type>();

            assemblyNamesToProbe.ToList().ForEach(assemblyName =>
            {
                var profiles = Assembly.Load(assemblyName)
                                       .GetTypes()
                                       .Where(t => typeof(Profile).IsAssignableFrom(t));

                profileList.AddRange(profiles);
            });

            var mapperconfig = new MapperConfiguration(
              cfg =>
              {
                  foreach (var profile in profileList)
                  {
                      cfg.AddProfile((Profile)Activator.CreateInstance(profile));
                  }
              });

            services.AddSingleton(x => mapperconfig.CreateMapper());
        }
    }
}
