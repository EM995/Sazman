using Sazman.API.Dao;
using Sazman.API.Filters;
using Sazman.DataModels.Models;

namespace Sazman.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddDaoServices(this IServiceCollection services)
        {
            services.AddScoped((_) => new SazmanContext("SazmanDB"));

            services.AddScoped<IDaoWrapper, DaoWrapper>();

            services.AddMvc(config => 
            {
                config.Filters.Add(typeof(APIExceptionHandler));
            });
        }
    }
}
