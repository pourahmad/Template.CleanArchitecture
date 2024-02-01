using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Persistence.Data;
using Template.CleanArchitecture.Persistence.Repositories;

namespace Template.CleanArchitecture.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                //options.UseSqlServer(configuration.GetConnectionString("SQLServerConnectionString"));
                options.UseSqlite(configuration.GetConnectionString("SQLiteConnectionString"));
            });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();

            return services;
        }
    }
}
