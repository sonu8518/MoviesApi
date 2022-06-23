using Movies_API.Data;
using Movies_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection ApplicationService(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddControllers();
            services.AddMvc();
            services.AddScoped<IMoviesRepositoryface, MoviesRepositoryface>();

            var connectionString = Configuration["connectionStrings:DatingDbConnectionString"];
            services.AddDbContext<DataContext>(c => c.UseSqlite(connectionString));

            return services;

        }
    }
}
