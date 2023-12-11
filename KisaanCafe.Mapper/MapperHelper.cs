

using KisaanCafe.Mapper;
using Microsoft.Extensions.DependencyInjection;

    public static class MapperHelper
    {
        public static void AddMapperHelper(this IServiceCollection services)
        {
            services.AddScoped<IActionExecutor, ActionExecutor>();
            services.AddScoped<KisaanCafe.Mapper.IMapperResolver, AutoMapperResolver>();
            services.AddScoped<IMapperClient, MapperClient>();
        }
   
}
