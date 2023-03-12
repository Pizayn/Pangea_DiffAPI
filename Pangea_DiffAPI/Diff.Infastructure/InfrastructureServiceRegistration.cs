using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Diff.Application.Contracts.Persistence;
using Diff.Infrastructure.Persistence;
using Diff.Infrastructure.Repositories;

namespace Diff.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DiffContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DiffConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IDiffRepository, DiffRepository>();

            return services;
        }
    }
}